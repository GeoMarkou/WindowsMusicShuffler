using System;
using System.IO;
using System.Windows;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;

namespace MassFileManager
{
    /// <summary>
    /// An application designed to help shuffling files.
    /// Many programs do not have a good shuffle option (such as VLC or Audiosurf) and this app aims to solve that.
    /// 
    /// Version 1.8
    /// Authored by Georgios Markou
    /// </summary>
    public partial class MainWindow : Form
    {
        // Stored early for quick opening
        public OptionsForm optionsForm;
        public HelpForm helpForm;






        /// <summary>
        /// Constructor.
        /// Initialises any null values in the database
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            // Null inits
            if (zData.Default.LoadedFiles == null)
            {
                zData.Default.LoadedFiles = new StringCollection();
            }

            if (zData.Default.FilesChosen == null)
            {
                zData.Default.FilesChosen = new StringCollection();
            }

            if (zData.Default.ExtensionList == null)
            {
                zData.Default.ExtensionList = new StringCollection();
            }

            if (zData.Default.ExtensionListRegex == "")
            {
                updateExtensionListRegex();
            }

            if (zData.Default.ExtensionList.Count < 1)
            {
                resetExtensions();
            }

            if (zData.Default.SortedLoadedFiles == null)
            {
                zData.Default.SortedLoadedFiles = new StringCollection();
            }


            // Order here is important to avoid nulls
            helpForm = new HelpForm();
            optionsForm = new OptionsForm(this);



            // Display helpful message if nothing has been loaded yet
            if (zData.Default.LoadedFiles.Count < 1 || zData.Default.LoadedFiles[0].Length < 1)
            {
                TBLastShuffledFileData.Text = "\r\n\tDrag + drop files here to load them.";
            }

            // Tool tips
            ToolTip toolTipPlayMusic = new ToolTip();
            toolTipPlayMusic.SetToolTip(buttonPlayMusic, "Sends the list of files to VLC as a playlist");

            ToolTip toolTipShuffle = new ToolTip();
            toolTipShuffle.SetToolTip(buttonShuffle, "Shuffles the files");

            ToolTip toolTipRevert = new ToolTip();
            toolTipRevert.SetToolTip(buttonRevert, "Reverts the files to their original names");

            ToolTip toolTipFileList = new ToolTip();
            toolTipFileList.SetToolTip(labelCurentShuffleFile, "These are the files that will be shuffled / fixed / played when the respective button is pressed.");

            ToolTip toolTipProgressBar = new ToolTip();
            toolTipProgressBar.SetToolTip(progressBar, "Approximate status of the current action");

            // Init the list of files
            if (zData.Default.LoadedFiles.Count > 0)
            {
                TBLastShuffledFileData.Text = formattedList();
            }

            // Allows scrolling the list
            MouseWheel += new MouseEventHandler(this_MouseWheel);

            // Set size and progress bar
            this.Size = zData.Default.Size;
            progressBar.Value = 0;

            // Update the colours of this control
            optionsForm.ColourAllControls(this);

            // Scrollbar experiment
            //TBLastShuffledFileData.ScrollBars = ScrollBars.None;
            //MyScrollBar test = new MyScrollBar();
            //test.TextBox = TBLastShuffledFileData;

            // Make the images look nice
            //buttonShuffle.Image = buttonShuffle.Height - 10;





            MainWindow_Resize(null, null);
        }




        /// <summary>
        /// Scales font to window size
        /// </summary>
        public void scaleFont()
        {
            if (zData.Default.Scale)
            {
                double heightScale = ((double)((double)this.Width - (double)this.MinimumSize.Width) / 100.0) + 9.0;
                double widthScale = (((double)(double)this.Height - (double)this.MinimumSize.Height) / 100.0) + 9.0;
                float fontScale = Convert.ToSingle((heightScale > widthScale) ? widthScale : heightScale);

                this.Font = new Font("Arial", fontScale, FontStyle.Regular);
                menuStrip.Font = this.Font = new Font("Arial", fontScale, FontStyle.Regular);
            }
            else
            {
                this.Font = new Font("Arial", (float)9, FontStyle.Regular);
                menuStrip.Font = new Font("Arial", (float)9, FontStyle.Regular);
            }
        }




        /// <summary>
        /// Adds an extension to the list of supported extensions
        /// </summary>
        /// <param name="ext">Extension to add</param>
        public void addExtension(string ext)
        {
            if (!ext.StartsWith("."))
            {
                ext = "." + ext;
            }
            zData.Default.ExtensionList.Add(ext);
            updateExtensionListRegex();
        }




        /// <summary>
        /// Resets the list of supported extensions to a list of popular formats
        /// </summary>
        public void resetExtensions()
        {
            zData.Default.ExtensionList.Clear();
            addExtension(".3gp");
            addExtension(".act");
            addExtension(".aiff");
            addExtension(".aac");
            addExtension(".au");
            addExtension(".flac");
            addExtension(".iklax");
            addExtension(".m4a");
            addExtension(".m4p");
            addExtension(".mmf");
            addExtension(".mp3");
            addExtension(".mpc");
            addExtension(".msv");
            addExtension(".ogg");
            addExtension(".oga");
            addExtension(".opus");
            addExtension(".ra");
            addExtension(".rm");
            addExtension(".raw");
            addExtension(".sln");
            addExtension(".tta");
            addExtension(".vox");
            addExtension(".wav");
            addExtension(".wma");
            addExtension(".wv");
        }




        /// <summary>
        /// Get a formatted version of the list of files
        /// </summary>
        /// <param name="forVLC">
        /// 'true' means the result will be in the style of
        /// "c:/program files" "d:/music" "c:/"
        /// this is designed so command line arguments are seperated properly when sending to VLC
        /// 
        /// 'false' means it will be unformatted, so in the style of
        /// c:/program files
        /// d:/music
        /// designed for displaying the songs in the program list
        /// </param>
        /// <returns>A list of files, depending on the paramater</returns>
        public string formattedList()
        {
            string result = "";

            try
            {
                StringCollection doneFolders = new StringCollection();
                int depthCount = 0;
                string[] folderList = null;
                bool startedMusic = false;
                string tabGap = "            ";

                // This one is grouped automatically
                SortedSet<string> loadedFilesSorted = new SortedSet<string>();
                foreach (string current in zData.Default.LoadedFiles)
                {
                    loadedFilesSorted.Add(current);
                }

                foreach (string current in loadedFilesSorted)
                {
                    // Group by parent folder
                    depthCount = 0;
                    folderList = Regex.Split(current, "\\\\");
                    foreach (string currentFolder in folderList)
                    {
                        if (!doneFolders.Contains(currentFolder) && !currentFolder.Equals(folderList[folderList.Length - 1]))
                        {
                            doneFolders.Add(currentFolder);

                            if (startedMusic)
                            {
                                result += "\r\n\r\n";
                            }
                            else
                            {
                                result += "\r\n";
                            }

                            for (int tab = 0; tab < depthCount; tab++)
                            {
                                result += tabGap;
                            }

                            result += currentFolder + "\\";
                        }

                        depthCount++;
                    }

                    result += "\r\n";
                    for (int tab = 0; tab < depthCount; tab++)
                    {
                        result += tabGap;
                    }
                    result += current.Substring(current.LastIndexOf("\\") + 1);
                    startedMusic = true;

                    progressBar.PerformStep();
                }
                result = result.Substring(2);
            }
            catch 
            {
                Console.WriteLine("Failed to display a file");
            }
            return result;
        }




        /// <summary>
        /// Sorts the list of files so that VLC plays them in the correct order
        /// </summary>
        public void sortLoadedFiles()
        {
            SortedList loadedFilesSorted = new SortedList();
            zData.Default.SortedLoadedFiles.Clear();

            foreach (string current in zData.Default.LoadedFiles)
            {
                string key = current.Substring(current.LastIndexOf("\\") + 1);
                // Remove duplicates so we don't cause exceptions
                if (!loadedFilesSorted.ContainsKey(key))
                {
                    // Key of the title only, value of the full path
                    loadedFilesSorted.Add(key, current);
                }
            }
            for (int loop = 0; loop < loadedFilesSorted.Count; loop++)
            {
                zData.Default.SortedLoadedFiles.Add((string)loadedFilesSorted.GetByIndex(loop));
            }
        }






        /// <summary>
        /// Selecting a folder manually using the dialog. Doesn't allow selecting multiple folders because it's the compatibility option.
        /// </summary>
        public void selectFile()
        {
            if (zData.Default.LoadedFiles.Count > 0)
            {
                folderBrowserDialog.SelectedPath = zData.Default.LoadedFiles[0];
            }
            if (folderBrowserDialog.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            setSelectedFiles(new string[] { folderBrowserDialog.SelectedPath });

            // Save the selected files for later re shuffling
            zData.Default.FilesChosen.Clear();
            zData.Default.FilesChosen.Add(folderBrowserDialog.SelectedPath);

            TBLastShuffledFileData.Text = formattedList();

            progressBar.Value = 0;
        }



        /// <summary>
        /// Sets the selected files list to a supplied string array
        /// </summary>
        /// <param name="files"></param>
        public void setSelectedFiles(string[] files)
        {
            // Awkward shifting data types to accomodate turning off recursive searching
            zData.Default.LoadedFiles.Clear();
            StringCollection temp = new StringCollection();
            temp.AddRange(files);
            zData.Default.LoadedFiles = getFileList(temp);
        }





        /// <summary>
        /// Gets the location of program files
        /// </summary>
        /// <returns></returns>
        string getProgramFiles()
        {
            if (8 == IntPtr.Size || (!String.IsNullOrEmpty(Environment.GetEnvironmentVariable("PROCESSOR_ARCHITEW6432"))))
            {
                return Environment.GetEnvironmentVariable("ProgramFiles(x86)");
            }

            return Environment.GetEnvironmentVariable("ProgramFiles");
        }




        /// <summary>
        /// Opens VLC and pastes the current URL of the selected file
        /// </summary>
        private void runVLC()
        {
            if (!File.Exists(zData.Default.VLCLoc))
            {
                string guessedFile = getProgramFiles() + "\\VideoLAN\\VLC\\vlc.exe";

                // Try the default directory before asking for user input
                if (File.Exists(guessedFile))
                {
                    zData.Default.VLCLoc = guessedFile;
                }
                else
                {
                    if (MessageBox.Show(this, "Couldn't find Windows Media Player. Is it installed?", "Alert", MessageBoxButtons.YesNo) == DialogResult.Cancel)
                    {
                        MessageBox.Show(this, "Please install VLC or select Windows Media Player as the preferred player instead.", "Alert", MessageBoxButtons.OK);
                        return;
                    }
                    if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                    {
                        return;
                    }
                    zData.Default.VLCLoc = openFileDialog.FileName;
                }
            }

            playerRunner.StartInfo.FileName = zData.Default.VLCLoc;
            playerRunner.StartInfo.Arguments = createPlaylist("VLC");
            playerRunner.Start();
        }




        /// <summary>
        /// Runs windows media player with the selected files
        /// </summary>
        public void runWindowsMediaPlayer()
        {
            if (!File.Exists(zData.Default.WMPLoc))
            {
                string guessedFile = getProgramFiles() + "\\Windows Media Player\\wmplayer.exe";

                // Try the default directory before asking for user input
                if (File.Exists(guessedFile))
                {
                    zData.Default.WMPLoc = guessedFile;
                }
                else
                {
                    if (MessageBox.Show(this, "Couldn't find Windows Media Player. Is it installed?", "Alert", MessageBoxButtons.YesNo) == DialogResult.Cancel)
                    {
                        MessageBox.Show(this, "Please install Windows Media Player or select VLC as the preferred player instead.", "Alert", MessageBoxButtons.OK);
                        return;
                    }
                    if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                    {
                        return;
                    }
                    zData.Default.WMPLoc = openFileDialog.FileName;
                }
            }

            playerRunner.StartInfo.FileName = zData.Default.WMPLoc;
            playerRunner.StartInfo.Arguments = "/play " + createPlaylist("Windows Media Player");
            playerRunner.Start();
        }



        /// <summary>
        /// Creates a playlist containing all the songs in <see cref="zData.Default.LoadedFiles"/>
        /// </summary>
        /// <param name="player">
        /// Valid options:
        /// "VLC"
        /// "Windows Media Player"
        /// </param>
        /// <returns>The location of the playlist</returns>
        public string createPlaylist(string player)
        {
            string playlistLoc = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\MusicShufflerPlaylist";
            if (!Directory.Exists(playlistLoc))
            {
                Directory.CreateDirectory(playlistLoc);
            }

            XmlTextWriter myWriter = null;
            int loop = 0;

            if (player == "VLC")
            {
                playlistLoc += "\\musicShufflerPlaylist.xspf";

                myWriter = new XmlTextWriter(@playlistLoc, Encoding.UTF8);
                myWriter.WriteStartDocument();

                myWriter.WriteWhitespace("\r\n");
                myWriter.WriteStartElement("playlist");
                myWriter.WriteStartAttribute("xmlns");
                myWriter.WriteString("http://xspf.org/ns/0/");
                myWriter.WriteEndAttribute();

                myWriter.WriteStartAttribute("xmlns:vlc");
                myWriter.WriteString("http://www.videolan.org/vlc/playlist/ns/0/");
                myWriter.WriteEndAttribute();

                myWriter.WriteStartAttribute("version");
                myWriter.WriteString("1");
                myWriter.WriteEndAttribute();

                myWriter.WriteWhitespace("\r\n\t");
                myWriter.WriteStartElement("title");
                myWriter.WriteString("Playlist");
                myWriter.WriteEndElement();

                myWriter.WriteWhitespace("\r\n\t");
                myWriter.WriteStartElement("trackList");

                foreach (string currentFile in zData.Default.SortedLoadedFiles)
                {
                    myWriter.WriteWhitespace("\r\n\t\t");
                    myWriter.WriteStartElement("track");

                    myWriter.WriteWhitespace("\r\n\t\t\t");
                    myWriter.WriteStartElement("location");
                    myWriter.WriteString("file:///" + currentFile);
                    myWriter.WriteEndElement();

                    myWriter.WriteWhitespace("\r\n\t\t\t");
                    myWriter.WriteStartElement("title");
                    myWriter.WriteString(currentFile.Substring(currentFile.LastIndexOf("\\") + 1));
                    myWriter.WriteEndElement();

                    myWriter.WriteWhitespace("\r\n\t\t\t");
                    myWriter.WriteStartElement("duration");
                    myWriter.WriteEndElement();

                    myWriter.WriteWhitespace("\r\n\t\t\t");
                    myWriter.WriteStartElement("album");
                    myWriter.WriteEndElement();

                    myWriter.WriteWhitespace("\r\n\t\t\t");
                    myWriter.WriteStartElement("extension");
                    myWriter.WriteStartAttribute("application");
                    myWriter.WriteString("http://www.videolan.org/vlc/playlist/0");
                    myWriter.WriteEndAttribute();

                    myWriter.WriteWhitespace("\r\n\t\t\t\t");
                    myWriter.WriteStartElement("vlc:id");
                    myWriter.WriteValue(loop++);
                    myWriter.WriteEndElement();

                    myWriter.WriteWhitespace("\r\n\t\t\t");
                    myWriter.WriteEndElement();

                    myWriter.WriteWhitespace("\r\n\t\t");
                    myWriter.WriteEndElement();
                }

                myWriter.WriteEndElement();

                myWriter.WriteWhitespace("\r\n\t");
                myWriter.WriteStartElement("extension");
                myWriter.WriteStartAttribute("application");
                myWriter.WriteString("http://www.videolan.org/vlc/playlist/0");
                myWriter.WriteWhitespace("\r\n\t");

                for (int loop2 = 0; loop2 < loop; loop2++)
                {
                    myWriter.WriteWhitespace("\r\n\t\t");
                    myWriter.WriteStartElement("vlc:item");
                    myWriter.WriteStartAttribute("tid");
                    myWriter.WriteValue(loop2);
                    myWriter.WriteEndAttribute();
                    myWriter.WriteEndElement();
                }
                myWriter.WriteWhitespace("\r\n\t");
                myWriter.WriteEndElement();
                myWriter.WriteWhitespace("\r\n");
                myWriter.WriteEndElement();
            }





            else if (player == "Windows Media Player")
            {
                playlistLoc += "\\musicShufflerPlaylist.wpl";

                myWriter = new XmlTextWriter(@playlistLoc, Encoding.UTF8);
                myWriter.WriteRaw("<?wpl version=\"1.0\"?>");

                myWriter.WriteWhitespace("\r\n");
                myWriter.WriteStartElement("smil");

                myWriter.WriteWhitespace("\r\n\t");
                myWriter.WriteStartElement("head");

                myWriter.WriteWhitespace("\r\n\t\t");
                myWriter.WriteStartElement("meta");
                myWriter.WriteStartAttribute("name");
                myWriter.WriteString("Generator");
                myWriter.WriteEndAttribute();
                myWriter.WriteStartAttribute("content");
                myWriter.WriteString("Mass File Manager");
                myWriter.WriteEndAttribute();
                myWriter.WriteEndElement();

                myWriter.WriteWhitespace("\r\n\t\t");
                myWriter.WriteStartElement("meta");
                myWriter.WriteStartAttribute("name");
                myWriter.WriteString("IsNetworkFeed");
                myWriter.WriteEndAttribute();
                myWriter.WriteStartAttribute("content");
                myWriter.WriteString("0");
                myWriter.WriteEndAttribute();
                myWriter.WriteEndElement();

                myWriter.WriteWhitespace("\r\n\t\t");
                myWriter.WriteStartElement("meta");
                myWriter.WriteStartAttribute("name");
                myWriter.WriteString("ItemCount");
                myWriter.WriteEndAttribute();
                myWriter.WriteStartAttribute("content");
                myWriter.WriteValue(zData.Default.SortedLoadedFiles.Count);
                myWriter.WriteEndAttribute();
                myWriter.WriteEndElement();

                myWriter.WriteWhitespace("\r\n\t\t");
                myWriter.WriteStartElement("meta");
                myWriter.WriteStartAttribute("name");
                myWriter.WriteString("IsFavorite");
                myWriter.WriteEndAttribute();
                myWriter.WriteEndElement();

                myWriter.WriteWhitespace("\r\n\t\t");
                myWriter.WriteStartElement("meta");
                myWriter.WriteStartAttribute("name");
                myWriter.WriteString("ContentPartnerListID");
                myWriter.WriteEndAttribute();
                myWriter.WriteEndElement();

                myWriter.WriteWhitespace("\r\n\t\t");
                myWriter.WriteStartElement("meta");
                myWriter.WriteStartAttribute("name");
                myWriter.WriteString("ContentPartnerNameType");
                myWriter.WriteEndAttribute();
                myWriter.WriteEndElement();

                myWriter.WriteWhitespace("\r\n\t\t");
                myWriter.WriteStartElement("meta");
                myWriter.WriteStartAttribute("name");
                myWriter.WriteString("ContentPartnerName");
                myWriter.WriteEndAttribute();
                myWriter.WriteEndElement();

                myWriter.WriteWhitespace("\r\n\t\t");
                myWriter.WriteStartElement("meta");
                myWriter.WriteStartAttribute("name");
                myWriter.WriteString("Subtitle");
                myWriter.WriteEndAttribute();
                myWriter.WriteEndElement();

                myWriter.WriteWhitespace("\r\n\t\t");
                myWriter.WriteStartElement("author");
                myWriter.WriteEndElement();

                myWriter.WriteWhitespace("\r\n\t\t");
                myWriter.WriteRaw("<title>Playlist</title>");

                myWriter.WriteWhitespace("\r\n\t");
                myWriter.WriteEndElement();

                myWriter.WriteWhitespace("\r\n\t");
                myWriter.WriteStartElement("body");


                myWriter.WriteWhitespace("\r\n\t\t");
                myWriter.WriteStartElement("seq");

                foreach (string currentFile in zData.Default.SortedLoadedFiles)
                {
                    myWriter.WriteWhitespace("\r\n\t\t\t");
                    myWriter.WriteStartElement("media");
                    myWriter.WriteStartAttribute("src");
                    myWriter.WriteString(currentFile);
                    myWriter.WriteEndAttribute();
                    myWriter.WriteEndElement();
                }

                myWriter.WriteWhitespace("\r\n\t\t");
                myWriter.WriteEndElement();

                myWriter.WriteWhitespace("\r\n\t");
                myWriter.WriteEndElement();

                myWriter.WriteWhitespace("\r\n");
                myWriter.WriteEndElement();
            }

            myWriter.Close();
            return playlistLoc;
        }


        /// <summary>
        /// Recursively fetch contents of folders to include in the shuffle
        /// </summary>
        /// <param name="chosenFiles">List of folders to search / files to include</param>
        /// <returns>List of files including the contents of folders</returns>
        public StringCollection getFileList(StringCollection chosenFiles)
        {
            StringCollection temp = new StringCollection();
            return getFileListHelper(chosenFiles, temp, true);
        }
        private StringCollection getFileListHelper(StringCollection currentFiles, StringCollection fileList, bool first)
        {
            foreach (string file in currentFiles)
            {
                // Current file is a directory, recurse (if chosen)
                if (File.GetAttributes(@file).HasFlag(FileAttributes.Directory) && (first || zData.Default.Recurse == true))
                {
                    StringCollection temp = new StringCollection();
                    temp.AddRange(Directory.GetDirectories(file));
                    temp.AddRange(Directory.GetFiles(file));
                    getFileListHelper(temp, fileList, false);
                }

                // Current file is a song, add to list
                else
                {
                    if (zData.Default.Filter)
                    {
                        if (isMusic(Path.GetExtension(file)))
                        {
                            fileList.Add(file);
                        }
                    }
                    else
                    {
                        fileList.Add(file);
                    }
                }
            }

            return fileList;
        }




        /// <summary>
        /// Checks if an extension matches any common music extensions
        /// </summary>
        /// <param name="fileExtension">Extension to check</param>
        /// <returns>True if it matches any of the listed extension regexes</returns>
        public bool isMusic(string fileExtension)
        {
            return Regex.IsMatch(fileExtension, zData.Default.ExtensionListRegex);
        }



        /// <summary>
        /// Loop through all available extensions and format them as regexes
        /// </summary>
        public void updateExtensionListRegex()
        {
            bool virgin = true;
            zData.Default.ExtensionListRegex = "(";
            foreach (string item in zData.Default.ExtensionList)
            {
                if (!virgin)
                {
                    zData.Default.ExtensionListRegex += "|";
                }
                else
                {
                    virgin = false;
                }

                zData.Default.ExtensionListRegex += item;
            }
            zData.Default.ExtensionListRegex += ")";
        }




        /// <summary>
        /// Reverts the files to their original names
        /// </summary>
        /// <param name="chosenFiles">Files to revert</param>
        public void revert(StringCollection chosenFiles)
        {
            int length = chosenFiles.Count;
            string name = "";
            string path = "";

            if (length == 0)
            {
                return;
            }

            // Main loop
            progressBar.Value = 0;
            progressBar.Maximum = length;

            for (int mainLoop = 0; mainLoop < length; mainLoop++)
            {
                path = chosenFiles[mainLoop].Substring(0, chosenFiles[mainLoop].LastIndexOf("\\") + 1);
                name = chosenFiles[mainLoop].Substring(chosenFiles[mainLoop].LastIndexOf("\\") + 1);
                string newname = "";

                Match myMatch = Regex.Match(name, "\\[\\d+\\]");
                if (myMatch.Success)
                {
                    newname = name.Substring(myMatch.Index + myMatch.Length + 3);

                    try
                    {
                        File.Move(chosenFiles[mainLoop], path + newname);
                    }
                    catch
                    {
                        Console.WriteLine("File failed to clean");
                        zData.Default.FileNotFound = true;
                    }

                    // Update internal file references
                    int selectedFileIndex = zData.Default.LoadedFiles.IndexOf(path + name);
                    if (selectedFileIndex >= 0)
                    {
                        zData.Default.LoadedFiles[selectedFileIndex] = path + newname;
                    }

                    selectedFileIndex = zData.Default.FilesChosen.IndexOf(path + name);
                    if (selectedFileIndex >= 0)
                    {
                        zData.Default.FilesChosen[selectedFileIndex] = path + newname;
                    }
                }

                progressBar.PerformStep();
            }

            zData.Default.LoadedFiles = getFileList(zData.Default.FilesChosen);
            sortLoadedFiles();

            TBLastShuffledFileData.Text = formattedList();
            progressBar.Value = 0;

            if (zData.Default.FileNotFound)
            {
                MessageBox.Show(this, "One or more files were not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                zData.Default.FileNotFound = false;
            }

            zData.Default.Save();
        }





        /// <summary>
        /// Shuffles the files
        /// </summary>
        /// <param name="chosenFiles">Files to shuffle</param>
        public void shuffle(StringCollection chosenFiles)
        {
            // Automatically cleans the numbers for repeated shuffling
            revert(chosenFiles);

            Random rand = new Random();
            int length = chosenFiles.Count;
            int randomNo = 0;
            int originalRandomNo = 0; ;
            int[] numberList = new int[length];
            int step = rand.Next(0, 2);

            string name = "";
            string newName = "";
            string numHolder = "";
            string translator = length + "";
            string checker = "";

            bool foundDupe = false;

            if (length == 0)
            {
                return;
            }

            // Random number gen
            for (int loop = 0; loop < length; loop++)
            {
                numberList[loop] = -1;
            }

            numberList[0] = rand.Next(0, length);

            for (int loop = 0; loop < length; loop++)
            {
                originalRandomNo = randomNo = rand.Next(0, length);

                // Makes sure the number is not a duplicate
                for (; ; )
                {
                    // Different efficient number finder depending on a random pattern chosen
                    if (step == 0)
                    {
                        if (randomNo >= length)
                        {
                            step = rand.Next(0, 2);
                            randomNo = originalRandomNo;
                        }
                    }


                    else
                    {
                        if (randomNo < 0)
                        {
                            step = rand.Next(0, 2);
                            randomNo = originalRandomNo;
                        }
                    }


                    // Checks if the num already exists
                    foundDupe = false;
                    for (int loop2 = 0; loop2 <= loop; loop2++)
                    {
                        if (randomNo == numberList[loop2])
                        {
                            foundDupe = true;
                            break;
                        }
                    }

                    if (!foundDupe)
                    {
                        break;
                    }

                    // Increments or decrements by 1 if a dupe exists
                    else
                    {
                        if (step == 0)
                        {
                            randomNo++;
                        }

                        else
                        {
                            randomNo--;
                        }
                    }
                }

                // Adds the # to the array
                numberList[loop] = randomNo;
            }

            // Renames the files, adding '0's to the beginning until the lengths are consistent
            progressBar.Value = 0;
            progressBar.Maximum = length;

            string path = "";
            for (int loop = 0; loop < length; loop++)
            {
                numHolder = "";
                checker = numberList[loop] + "";

                // While the number has less length than the highest number, add a 0 to the name
                while (checker.Length < translator.Length)
                {
                    numHolder += '0';
                    checker += '0';
                }

                name = chosenFiles[loop].Substring(chosenFiles[loop].LastIndexOf("\\") + 1);
                newName = "[" + numHolder + "" + numberList[loop] + "" + "] - " + name;
                path = Path.Combine(Directory.GetParent(chosenFiles[loop]).FullName, newName);

                try
                {
                    File.Move(chosenFiles[loop], path);
                }
                catch
                {
                    Console.WriteLine("File failed to shuffle");
                    zData.Default.FileNotFound = true;
                }

                // Update internal file references
                int selectedFileIndex = zData.Default.LoadedFiles.IndexOf(Path.Combine(Directory.GetParent(chosenFiles[loop]).FullName, name));
                if (selectedFileIndex >= 0)
                {
                    zData.Default.LoadedFiles[selectedFileIndex] = path;
                }

                selectedFileIndex = zData.Default.FilesChosen.IndexOf(Path.Combine(Directory.GetParent(chosenFiles[loop]).FullName, name));
                if (selectedFileIndex >= 0)
                {
                    zData.Default.FilesChosen[selectedFileIndex] = path;
                }

                progressBar.PerformStep();
            }

            if (zData.Default.FileNotFound)
            {
                MessageBox.Show(this, "One or more files were not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                zData.Default.FileNotFound = false;
            }

            zData.Default.LoadedFiles = getFileList(zData.Default.FilesChosen);
            sortLoadedFiles();

            TBLastShuffledFileData.Text = formattedList();
            progressBar.Value = 0;
            zData.Default.Save();
        }
        
        
        
        
        /// <summary>
        /// Sets all the contols' back and fore colours to the specified color.
        /// </summary>
        /// <param name="back"></param>
        /// <param name="fore"></param>
        public void setControlColor(Color back, Color fore)
        {
            foreach (Control curr in Controls)
            {
                setControlColorHelper(back, fore, curr);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="back"></param>
        /// <param name="fore"></param>
        /// <param name="parent"></param>
        private void setControlColorHelper(Color back, Color fore, Control parent)
        {
            parent.BackColor = back;
            parent.ForeColor = fore;

            foreach (Control curr in parent.Controls)
            {
                curr.BackColor = back;
                curr.ForeColor = fore;

                foreach (Control child in curr.Controls)
                {
                    setControlColorHelper(back, fore, child);
                }
            }
        }





        #region "Events, buttons and controls"



        /// <summary>
        /// Reverts the file names
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRevert_Click(object sender, EventArgs e)
        {
            revert(zData.Default.LoadedFiles);
        }






        /// <summary>
        /// Shuffle button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonShuffle_Click(object sender, EventArgs e)
        {
            shuffle(zData.Default.LoadedFiles);
        }




        /// <summary>
        /// Makes any mouse wheel action scroll the list of songs for ease of use
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void this_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            int numberOfTextLinesToMove = e.Delta * SystemInformation.MouseWheelScrollLines / 120;

            // Throws a lot of exceptions for some reason
            if (numberOfTextLinesToMove < 0)
            {
                numberOfTextLinesToMove = SystemInformation.MouseWheelScrollLines;
            }

            try
            {
                TBLastShuffledFileData.Focus();
                TBLastShuffledFileData.SelectionStart += numberOfTextLinesToMove;
                TBLastShuffledFileData.SelectionLength = 0;
                TBLastShuffledFileData.ScrollToCaret();
                this.Focus();
            }
            catch 
            {
                Console.WriteLine("Mousewheel thing fucked up again");
            }
        }





        /// <summary>
        /// Save before closing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            zData.Default.Size = this.Size;
            zData.Default.Save();
        }





        /// <summary>
        /// Dragging a file into the panel, changes effect to let the user know the file won't be deleted
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panelDropFile_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }





        /// <summary>
        /// Dropping into the panel, loads the file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panelDropFile_DragDrop(object sender, DragEventArgs e)
        {
            string[] data = (string[])e.Data.GetData(DataFormats.FileDrop);
            setSelectedFiles(data);

            // Save the selected files for later re shuffling
            zData.Default.FilesChosen.Clear();
            zData.Default.FilesChosen.AddRange(data);

            TBLastShuffledFileData.Text = formattedList();
            progressBar.Value = 0;
        }




        /// <summary>
        /// Play music with VLC
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonPlayMusic_Click(object sender, EventArgs e)
        {
            for (; ; )
            {
                try
                {
                    if (zData.Default.PreferredPlayer == "VLC")
                    {
                        runVLC();
                    }
                    else if (zData.Default.PreferredPlayer == "Windows Media Player")
                    {
                        runWindowsMediaPlayer();
                    }
                    break;
                }
                catch (FileNotFoundException)
                {
                    DialogResult tempDialogResult = MessageBox.Show(this, "The chosen player was not found.", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    if (tempDialogResult != DialogResult.Retry)
                    {
                        return;
                    }
                }
                catch (Exception exc)
                {
                    DialogResult tempDialogResult = MessageBox.Show(this, "Unknown error: " + exc.Message, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    if (tempDialogResult != DialogResult.Retry)
                    {
                        return;
                    }
                }
            }
        }





        /// <summary>
        /// Resizes the window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                return;
            }

            if (zData.Default.Scale)
            {
                scaleFont();
            }
            else
            {
                this.Font = new Font("Arial", (float)9, FontStyle.Regular);
            }
        }








        /// <summary>
        /// Help
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            helpForm.ShowDialog(this);
        }




        /// <summary>
        /// Options
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            optionsForm.StartPosition = FormStartPosition.Manual;
            optionsForm.Location = this.Location;
            optionsForm.ShowDialog(this);
        }



        /// <summary>
        /// Open
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectFile();
        }




        /// <summary>
        /// Exit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        private void MainWindow_Move(object sender, EventArgs e)
        {
        }
    }
}