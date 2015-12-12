namespace MassFileManager
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.playerRunner = new System.Diagnostics.Process();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.splitContainerBase = new System.Windows.Forms.SplitContainer();
            this.splitContainerExtraButtons = new System.Windows.Forms.SplitContainer();
            this.panelBottoms = new System.Windows.Forms.Panel();
            this.TBLastShuffledFileData = new System.Windows.Forms.TextBox();
            this.labelCurentShuffleFile = new System.Windows.Forms.Label();
            this.panelProgressBar = new System.Windows.Forms.Panel();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.audiosurfRunner = new System.Diagnostics.Process();
            this.buttonPlayMusic = new System.Windows.Forms.Button();
            this.buttonRevert = new System.Windows.Forms.Button();
            this.buttonShuffle = new System.Windows.Forms.Button();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerBase)).BeginInit();
            this.splitContainerBase.Panel1.SuspendLayout();
            this.splitContainerBase.Panel2.SuspendLayout();
            this.splitContainerBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerExtraButtons)).BeginInit();
            this.splitContainerExtraButtons.Panel1.SuspendLayout();
            this.splitContainerExtraButtons.Panel2.SuspendLayout();
            this.splitContainerExtraButtons.SuspendLayout();
            this.panelBottoms.SuspendLayout();
            this.panelProgressBar.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // playerRunner
            // 
            this.playerRunner.StartInfo.Domain = "";
            this.playerRunner.StartInfo.FileName = "C:\\Program Files (x86)\\VideoLAN\\VLC\\vlc.exe";
            this.playerRunner.StartInfo.LoadUserProfile = false;
            this.playerRunner.StartInfo.Password = null;
            this.playerRunner.StartInfo.StandardErrorEncoding = null;
            this.playerRunner.StartInfo.StandardOutputEncoding = null;
            this.playerRunner.StartInfo.UserName = "";
            this.playerRunner.SynchronizingObject = this;
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "VLC|*.exe";
            // 
            // splitContainerBase
            // 
            this.splitContainerBase.AllowDrop = true;
            this.splitContainerBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerBase.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerBase.IsSplitterFixed = true;
            this.splitContainerBase.Location = new System.Drawing.Point(5, 29);
            this.splitContainerBase.Name = "splitContainerBase";
            this.splitContainerBase.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerBase.Panel1
            // 
            this.splitContainerBase.Panel1.AllowDrop = true;
            this.splitContainerBase.Panel1.Controls.Add(this.buttonPlayMusic);
            this.splitContainerBase.Panel1.Controls.Add(this.splitContainerExtraButtons);
            this.splitContainerBase.Panel1.DragDrop += new System.Windows.Forms.DragEventHandler(this.panelDropFile_DragDrop);
            this.splitContainerBase.Panel1.DragEnter += new System.Windows.Forms.DragEventHandler(this.panelDropFile_DragEnter);
            this.splitContainerBase.Panel1MinSize = 100;
            // 
            // splitContainerBase.Panel2
            // 
            this.splitContainerBase.Panel2.AllowDrop = true;
            this.splitContainerBase.Panel2.Controls.Add(this.panelBottoms);
            this.splitContainerBase.Panel2.DragDrop += new System.Windows.Forms.DragEventHandler(this.panelDropFile_DragDrop);
            this.splitContainerBase.Panel2.DragEnter += new System.Windows.Forms.DragEventHandler(this.panelDropFile_DragEnter);
            this.splitContainerBase.Panel2MinSize = 100;
            this.splitContainerBase.Size = new System.Drawing.Size(1134, 504);
            this.splitContainerBase.SplitterDistance = 100;
            this.splitContainerBase.TabIndex = 0;
            this.splitContainerBase.TabStop = false;
            this.splitContainerBase.DragDrop += new System.Windows.Forms.DragEventHandler(this.panelDropFile_DragDrop);
            this.splitContainerBase.DragEnter += new System.Windows.Forms.DragEventHandler(this.panelDropFile_DragEnter);
            // 
            // splitContainerExtraButtons
            // 
            this.splitContainerExtraButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitContainerExtraButtons.IsSplitterFixed = true;
            this.splitContainerExtraButtons.Location = new System.Drawing.Point(0, 53);
            this.splitContainerExtraButtons.Name = "splitContainerExtraButtons";
            // 
            // splitContainerExtraButtons.Panel1
            // 
            this.splitContainerExtraButtons.Panel1.Controls.Add(this.buttonRevert);
            // 
            // splitContainerExtraButtons.Panel2
            // 
            this.splitContainerExtraButtons.Panel2.Controls.Add(this.buttonShuffle);
            this.splitContainerExtraButtons.Size = new System.Drawing.Size(1134, 47);
            this.splitContainerExtraButtons.SplitterDistance = 567;
            this.splitContainerExtraButtons.TabIndex = 14;
            // 
            // panelBottoms
            // 
            this.panelBottoms.BackColor = System.Drawing.SystemColors.Control;
            this.panelBottoms.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelBottoms.Controls.Add(this.TBLastShuffledFileData);
            this.panelBottoms.Controls.Add(this.labelCurentShuffleFile);
            this.panelBottoms.Controls.Add(this.panelProgressBar);
            this.panelBottoms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBottoms.Location = new System.Drawing.Point(0, 0);
            this.panelBottoms.Name = "panelBottoms";
            this.panelBottoms.Padding = new System.Windows.Forms.Padding(5);
            this.panelBottoms.Size = new System.Drawing.Size(1134, 400);
            this.panelBottoms.TabIndex = 0;
            // 
            // TBLastShuffledFileData
            // 
            this.TBLastShuffledFileData.AllowDrop = true;
            this.TBLastShuffledFileData.BackColor = System.Drawing.SystemColors.ControlLight;
            this.TBLastShuffledFileData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TBLastShuffledFileData.Location = new System.Drawing.Point(5, 20);
            this.TBLastShuffledFileData.Multiline = true;
            this.TBLastShuffledFileData.Name = "TBLastShuffledFileData";
            this.TBLastShuffledFileData.ReadOnly = true;
            this.TBLastShuffledFileData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TBLastShuffledFileData.Size = new System.Drawing.Size(1120, 351);
            this.TBLastShuffledFileData.TabIndex = 0;
            this.TBLastShuffledFileData.TabStop = false;
            this.TBLastShuffledFileData.WordWrap = false;
            this.TBLastShuffledFileData.DragDrop += new System.Windows.Forms.DragEventHandler(this.panelDropFile_DragDrop);
            this.TBLastShuffledFileData.DragEnter += new System.Windows.Forms.DragEventHandler(this.panelDropFile_DragEnter);
            // 
            // labelCurentShuffleFile
            // 
            this.labelCurentShuffleFile.AutoSize = true;
            this.labelCurentShuffleFile.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelCurentShuffleFile.Location = new System.Drawing.Point(5, 5);
            this.labelCurentShuffleFile.Name = "labelCurentShuffleFile";
            this.labelCurentShuffleFile.Size = new System.Drawing.Size(86, 15);
            this.labelCurentShuffleFile.TabIndex = 0;
            this.labelCurentShuffleFile.Text = "Selected files: ";
            // 
            // panelProgressBar
            // 
            this.panelProgressBar.Controls.Add(this.progressBar);
            this.panelProgressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelProgressBar.Location = new System.Drawing.Point(5, 371);
            this.panelProgressBar.Name = "panelProgressBar";
            this.panelProgressBar.Size = new System.Drawing.Size(1120, 20);
            this.panelProgressBar.TabIndex = 4;
            this.panelProgressBar.Tag = "NoBorder";
            // 
            // progressBar
            // 
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBar.Location = new System.Drawing.Point(0, 0);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(1120, 20);
            this.progressBar.Step = 1;
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 0;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(5, 5);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1134, 24);
            this.menuStrip.TabIndex = 0;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.optionsToolStripMenuItem.Text = "&Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // audiosurfRunner
            // 
            this.audiosurfRunner.StartInfo.Domain = "";
            this.audiosurfRunner.StartInfo.LoadUserProfile = false;
            this.audiosurfRunner.StartInfo.Password = null;
            this.audiosurfRunner.StartInfo.StandardErrorEncoding = null;
            this.audiosurfRunner.StartInfo.StandardOutputEncoding = null;
            this.audiosurfRunner.StartInfo.UserName = "";
            this.audiosurfRunner.SynchronizingObject = this;
            // 
            // buttonPlayMusic
            // 
            this.buttonPlayMusic.BackColor = System.Drawing.SystemColors.Control;
            this.buttonPlayMusic.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonPlayMusic.Image = global::MassFileManager.Properties.Resources.playIconDark;
            this.buttonPlayMusic.Location = new System.Drawing.Point(0, 0);
            this.buttonPlayMusic.MinimumSize = new System.Drawing.Size(100, 29);
            this.buttonPlayMusic.Name = "buttonPlayMusic";
            this.buttonPlayMusic.Size = new System.Drawing.Size(1134, 48);
            this.buttonPlayMusic.TabIndex = 1;
            this.buttonPlayMusic.Text = "Play music";
            this.buttonPlayMusic.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonPlayMusic.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonPlayMusic.UseVisualStyleBackColor = false;
            this.buttonPlayMusic.Click += new System.EventHandler(this.buttonPlayMusic_Click);
            // 
            // buttonRevert
            // 
            this.buttonRevert.BackColor = System.Drawing.SystemColors.Control;
            this.buttonRevert.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonRevert.Image = global::MassFileManager.Properties.Resources.revertIconDark;
            this.buttonRevert.Location = new System.Drawing.Point(0, 0);
            this.buttonRevert.Name = "buttonRevert";
            this.buttonRevert.Size = new System.Drawing.Size(567, 47);
            this.buttonRevert.TabIndex = 2;
            this.buttonRevert.Text = "Fix filenames";
            this.buttonRevert.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonRevert.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonRevert.UseVisualStyleBackColor = false;
            this.buttonRevert.Click += new System.EventHandler(this.buttonRevert_Click);
            // 
            // buttonShuffle
            // 
            this.buttonShuffle.BackColor = System.Drawing.SystemColors.Control;
            this.buttonShuffle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonShuffle.Image = global::MassFileManager.Properties.Resources.shuffleIconDark;
            this.buttonShuffle.Location = new System.Drawing.Point(0, 0);
            this.buttonShuffle.Name = "buttonShuffle";
            this.buttonShuffle.Size = new System.Drawing.Size(563, 47);
            this.buttonShuffle.TabIndex = 3;
            this.buttonShuffle.Text = "Shuffle";
            this.buttonShuffle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonShuffle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonShuffle.UseVisualStyleBackColor = false;
            this.buttonShuffle.Click += new System.EventHandler(this.buttonShuffle_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
            this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // MainWindow
            // 
            this.AllowDrop = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1144, 538);
            this.Controls.Add(this.splitContainerBase);
            this.Controls.Add(this.menuStrip);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.ForeColor = System.Drawing.Color.Black;
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new System.Drawing.Size(535, 300);
            this.Name = "MainWindow";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Music Shuffler";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.panelDropFile_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.panelDropFile_DragEnter);
            this.Move += new System.EventHandler(this.MainWindow_Move);
            this.Resize += new System.EventHandler(this.MainWindow_Resize);
            this.splitContainerBase.Panel1.ResumeLayout(false);
            this.splitContainerBase.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerBase)).EndInit();
            this.splitContainerBase.ResumeLayout(false);
            this.splitContainerExtraButtons.Panel1.ResumeLayout(false);
            this.splitContainerExtraButtons.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerExtraButtons)).EndInit();
            this.splitContainerExtraButtons.ResumeLayout(false);
            this.panelBottoms.ResumeLayout(false);
            this.panelBottoms.PerformLayout();
            this.panelProgressBar.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        public System.Diagnostics.Process playerRunner;
        public System.Windows.Forms.OpenFileDialog openFileDialog;
        public System.Windows.Forms.SplitContainer splitContainerBase;
        public System.Windows.Forms.Panel panelBottoms;
        public System.Windows.Forms.Label labelCurentShuffleFile;
        public System.Windows.Forms.Panel panelProgressBar;
        public System.Windows.Forms.TextBox TBLastShuffledFileData;
        public System.Windows.Forms.MenuStrip menuStrip;
        public System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        public System.Windows.Forms.Button buttonPlayMusic;
        public System.Windows.Forms.SplitContainer splitContainerExtraButtons;
        public System.Windows.Forms.Button buttonRevert;
        public System.Windows.Forms.Button buttonShuffle;
        public System.Diagnostics.Process audiosurfRunner;
        public System.Windows.Forms.ProgressBar progressBar;

    }
}

