using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MassFileManager
{
    /// <summary>
    /// A dialog for editing the various variables of the application
    /// </summary>
    public partial class OptionsForm : Form
    {
        public readonly string ButtonImageDarkStyle = "ButtonImageDarkStyle";
        public readonly string ButtonImageLightStyle = "ButtonImageLightStyle";

        /// <summary>
        /// Reference to the main application and its methods
        /// </summary>
        MainWindow parent;


        /// <summary>
        /// Initialises and loads existing settings
        /// </summary>
        /// <param name="parent">Reference to the main application</param>
        public OptionsForm(MainWindow parent)
        {
            InitializeComponent();

            // Tool tips
            ToolTip toolTipRecurse = new ToolTip();
            toolTipRecurse.SetToolTip(checkBoxRecurse, "This means that any folders within another folder will be searched as well.");

            ToolTip toolTipScaleFont = new ToolTip();
            toolTipScaleFont.SetToolTip(checkBoxScaleFont, "As the window gets bigger, the font will get bigger as well.");

            ToolTip toolTipAddExt = new ToolTip();
            toolTipAddExt.SetToolTip(buttonAddExtension, "Add another extension to the list of filters.");

            ToolTip toolTipDefaultExt = new ToolTip();
            toolTipDefaultExt.SetToolTip(buttonResetExtensions, "Reset the filter list to a list of common file types.");

            ToolTip toolTipcheckBoxFilterFiles = new ToolTip();
            toolTipcheckBoxFilterFiles.SetToolTip(checkBoxFilterFiles, "List of file types that the program will include in its searches.");

            ToolTip toolTipExtList = new ToolTip();
            toolTipExtList.SetToolTip(listViewExtensions, "List of file types that the program will include in its searches.");

            this.parent = parent;

            updateListBox();

            checkBoxRecurse.Checked = zData.Default.Recurse;
            checkBoxScaleFont.Checked = zData.Default.Scale;
            checkBoxFilterFiles.Checked = zData.Default.Filter;

            comboBoxMusicPlayer.SelectedIndex = comboBoxMusicPlayer.Items.IndexOf(zData.Default.PreferredPlayer);
            comboBoxBGColour.SelectedIndex = comboBoxBGColour.Items.IndexOf(zData.Default.Theme);

            resize();
        }









        /// <summary>
        /// Changes the setting to recurse or not
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxRecurse_CheckedChanged(object sender, EventArgs e)
        {
            zData.Default.Recurse = checkBoxRecurse.Checked;
        }





        /// <summary>
        /// Changes whether to scale fonts or not
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxScaleFont_CheckedChanged(object sender, EventArgs e)
        {
            zData.Default.Scale = checkBoxScaleFont.Checked;
            resize();
        }




        /// <summary>
        /// Triggers when resizing the window
        /// </summary>
        public void resize()
        {
            if (zData.Default.Scale)
            {
                double heightScale = ((double)((double)this.Width - (double)this.MinimumSize.Width) / 100.0) + 9.0;
                double widthScale = (((double)(double)this.Height - (double)this.MinimumSize.Height) / 100.0) + 9.0;
                float fontScale = Convert.ToSingle((heightScale > widthScale) ? widthScale : heightScale);

                this.Font = new Font("Arial", fontScale, FontStyle.Regular);
            }
            else
            {
                this.Font = new Font("Arial", (float)9, FontStyle.Regular);
            }

            parent.scaleFont();
        }




        /// <summary>
        /// Adds the extension choices to the list view
        /// </summary>
        public void updateListBox()
        {
            listViewExtensions.Items.Clear();
            foreach (string item in zData.Default.ExtensionList)
            {
                ListViewItem tempItem = new ListViewItem();
                ListViewItem.ListViewSubItem tempSubItem = new ListViewItem.ListViewSubItem(tempItem, item);

                tempItem.ImageIndex = 1;
                tempItem.Text = "x";
                tempItem.SubItems.Add(tempSubItem);
                tempItem.UseItemStyleForSubItems = false;

                tempItem.ForeColor = Color.Red;
                tempSubItem.ForeColor = zData.Default.ButtonFore;

                listViewExtensions.Items.Add(tempItem);
            }
        }





        /// <summary>
        /// Adds another extension to the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAddExtension_Click(object sender, EventArgs e)
        {
            if (textBoxAddExtension.Text.Length <= 0)
                return;
            parent.addExtension(textBoxAddExtension.Text);
            textBoxAddExtension.Clear();
            updateListBox();
        }



        /// <summary>
        /// Resets the extensions to a list of defaults
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonResetExtensions_Click(object sender, EventArgs e)
        {
            parent.resetExtensions();
            updateListBox();
        }




        /// <summary>
        /// Checks if the X column of the list view was clicked, and if so, delete that item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listViewExtensions_Click(object sender, EventArgs e)
        {
            int pointOfListView = listViewExtensions.PointToScreen(Point.Empty).X;
            if (MousePosition.X > pointOfListView && MousePosition.X < pointOfListView + listViewExtensions.Columns[0].Width)
            {
                zData.Default.ExtensionList.RemoveAt(listViewExtensions.SelectedItems[0].Index);
                updateListBox();
            }
        }




        /// <summary>
        /// Allows you to just press enter when adding extensions
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxAddExtension_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13 && textBoxAddExtension.Text.Length > 0)
            {
                buttonAddExtension_Click(null, null);
            }
        }




        /// <summary>
        /// Whether or not to filter files by type
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxFilterFiles_CheckedChanged(object sender, EventArgs e)
        {
            zData.Default.Filter = (bool)checkBoxFilterFiles.Checked;

            buttonAddExtension.Enabled = zData.Default.Filter;
            textBoxAddExtension.Enabled = zData.Default.Filter;
            listViewExtensions.Enabled = zData.Default.Filter;
            buttonResetExtensions.Enabled = zData.Default.Filter;
        }




        /// <summary>
        /// What player to use
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxMusicPlayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            zData.Default.PreferredPlayer = comboBoxMusicPlayer.SelectedItem.ToString();
        }




        /// <summary>
        /// Changes the colour of everything to be nice looking
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxBGColour_SelectedIndexChanged(object sender, EventArgs e)
        {
            zData.Default.Theme = (string)comboBoxBGColour.Items[comboBoxBGColour.SelectedIndex];
            switch (zData.Default.Theme)
            {
                case "Midnight":
                    {
                        zData.Default.FileChooserBG = Color.Black;
                        zData.Default.FileChooserFore = Color.LightGray;

                        zData.Default.ButtonBG = Color.FromArgb(50, 50, 50);
                        zData.Default.ButtonFore = Color.LightGray;

                        zData.Default.TextBoxBG = Color.FromArgb(50, 50, 50);
                        zData.Default.TextBoxFore = Color.LightGray;

                        zData.Default.BG = Color.Black; 
                        zData.Default.TextFore = Color.LightGray;

                        zData.Default.ButtonFlatStyle = FlatStyle.Flat;
                        zData.Default.PanelBorderStyle = BorderStyle.FixedSingle;

                        zData.Default.ButtonImageStyle = ButtonImageLightStyle;
                        zData.Default.ButtonUseVisualStyles = false;

                        break;
                    }

                case "Cherry":
                    {
                        zData.Default.FileChooserBG = Color.FromArgb(76,0,0);
                        zData.Default.FileChooserFore = Color.FromArgb(200, 100, 100);

                        zData.Default.ButtonBG = Color.FromArgb(179,0,0);
                        zData.Default.ButtonFore = Color.FromArgb(255, 150, 150);

                        zData.Default.TextBoxBG = Color.FromArgb(179, 0, 0);
                        zData.Default.TextBoxFore = Color.FromArgb(225, 125, 125);

                        zData.Default.BG = Color.FromArgb(114, 0, 0);
                        zData.Default.TextFore = Color.FromArgb(225, 125, 125);

                        zData.Default.ButtonFlatStyle = FlatStyle.Flat;
                        zData.Default.PanelBorderStyle = BorderStyle.None;

                        zData.Default.ButtonImageStyle = ButtonImageLightStyle;
                        zData.Default.ButtonUseVisualStyles = false;

                        break;
                    }

                case "Wood":
                    {
                        zData.Default.FileChooserBG = Color.FromArgb(77, 46, 15);
                        zData.Default.FileChooserFore = Color.FromArgb(168, 116, 65);

                        zData.Default.ButtonBG = Color.FromArgb(77, 46, 15);
                        zData.Default.ButtonFore = Color.FromArgb(168, 116, 65);

                        zData.Default.TextBoxBG = Color.FromArgb(77, 46, 15);
                        zData.Default.TextBoxFore = Color.FromArgb(168, 116, 65);

                        zData.Default.BG = Color.FromArgb(43, 21, 0);
                        zData.Default.TextFore = Color.FromArgb(168, 116, 65);

                        zData.Default.ButtonFlatStyle = FlatStyle.Flat;
                        zData.Default.PanelBorderStyle = BorderStyle.None;

                        zData.Default.ButtonImageStyle = ButtonImageDarkStyle;
                        zData.Default.ButtonUseVisualStyles = false;

                        break;
                    }

                case "Professional":
                    {
                        zData.Default.FileChooserBG = Color.FromArgb(240, 240, 240);
                        zData.Default.FileChooserFore = Color.FromArgb(0, 0, 0);

                        zData.Default.ButtonBG = Color.FromArgb(240, 240, 240);
                        zData.Default.ButtonFore = Color.FromArgb(0, 0, 0);

                        zData.Default.TextBoxBG = Color.FromArgb(240, 240, 240);
                        zData.Default.TextBoxFore = Color.FromArgb(0, 0, 0);

                        zData.Default.BG = Color.FromArgb(250, 250, 250);
                        zData.Default.TextFore = Color.FromArgb(0, 0, 0);

                        zData.Default.ButtonFlatStyle = FlatStyle.Flat;
                        zData.Default.PanelBorderStyle = BorderStyle.None;

                        zData.Default.ButtonImageStyle = ButtonImageLightStyle;
                        zData.Default.ButtonUseVisualStyles = false;

                        break;
                    }

                default:
                    {
                        zData.Default.FileChooserBG = SystemColors.ControlLight;
                        zData.Default.FileChooserFore = SystemColors.ControlText;

                        zData.Default.ButtonBG = SystemColors.Control;
                        zData.Default.ButtonFore = SystemColors.ControlText;

                        zData.Default.TextBoxBG = SystemColors.Window;
                        zData.Default.TextBoxFore = SystemColors.ControlText;

                        zData.Default.BG = SystemColors.Control; 
                        zData.Default.TextFore = SystemColors.ControlText;

                        zData.Default.ButtonFlatStyle = FlatStyle.Standard;
                        zData.Default.PanelBorderStyle = BorderStyle.Fixed3D;

                        zData.Default.ButtonImageStyle = ButtonImageDarkStyle;
                        zData.Default.ButtonUseVisualStyles = true;
                        break;
                    }
            }

            ColourAllControls(this);
            ColourAllControls(parent);
            ColourAllControls(parent.helpForm);
        }

        /// <summary>
        /// Colours all the controls recursively stemming from a parent.
        /// </summary>
        /// <param name="parent"></param>
        public void ColourAllControls(Control parent)
        {
            this.BackColor = zData.Default.BG;
            this.parent.BackColor = zData.Default.BG;
            this.parent.helpForm.BackColor = zData.Default.BG;

            this.ForeColor = zData.Default.TextFore;
            this.parent.ForeColor = zData.Default.TextFore;
            this.parent.helpForm.ForeColor = zData.Default.TextFore;

            // Have to do the main text box and menu strips individually
            this.parent.TBLastShuffledFileData.BackColor = zData.Default.FileChooserBG;
            this.parent.TBLastShuffledFileData.ForeColor = zData.Default.FileChooserFore;
            this.parent.TBLastShuffledFileData.BorderStyle = zData.Default.PanelBorderStyle;

            this.parent.menuStrip.BackColor = zData.Default.BG;
            this.parent.menuStrip.ForeColor = zData.Default.TextFore;

            this.parent.aboutToolStripMenuItem.BackColor = zData.Default.BG;
            this.parent.aboutToolStripMenuItem.ForeColor = zData.Default.TextFore;

            this.parent.exitToolStripMenuItem.BackColor = zData.Default.BG;
            this.parent.exitToolStripMenuItem.ForeColor = zData.Default.TextFore;

            this.parent.fileToolStripMenuItem.BackColor = zData.Default.BG;
            this.parent.fileToolStripMenuItem.ForeColor = zData.Default.TextFore;

            this.parent.helpToolStripMenuItem.BackColor = zData.Default.BG;
            this.parent.helpToolStripMenuItem.ForeColor = zData.Default.TextFore;

            this.parent.openToolStripMenuItem.BackColor = zData.Default.BG;
            this.parent.openToolStripMenuItem.ForeColor = zData.Default.TextFore;

            this.parent.optionsToolStripMenuItem.BackColor = zData.Default.BG;
            this.parent.optionsToolStripMenuItem.ForeColor = zData.Default.TextFore;

            this.parent.toolsToolStripMenuItem.BackColor = zData.Default.BG;
            this.parent.toolsToolStripMenuItem.ForeColor = zData.Default.TextFore;
            
            // Loop through the controls and apply the themes
            foreach (Control c in parent.Controls)
            {
                if (c.GetType() == typeof(TextBox))
                {
                    TextBox sub = (TextBox)c;
                    sub.BackColor = zData.Default.TextBoxBG;
                    sub.ForeColor = zData.Default.TextBoxFore;
                    sub.BorderStyle = zData.Default.PanelBorderStyle;
                }

                else if (c.GetType() == typeof(Label))
                {
                    Label sub = (Label)c;
                    sub.BackColor = Color.Transparent;
                    sub.ForeColor = zData.Default.TextFore;

                    // Different image for different buttons, light/dark version depending on theme
                    if (sub.Name == "labelShuffleImage")
                    {
                        sub.Image = (zData.Default.ButtonImageStyle == ButtonImageLightStyle) ? Properties.Resources.shuffleIconLight : Properties.Resources.shuffleIconDark;
                    }
                    else if (sub.Name == "labelPlayMusicImage")
                    {
                        sub.Image = (zData.Default.ButtonImageStyle == ButtonImageLightStyle) ? Properties.Resources.playIconLight : Properties.Resources.playIconDark;
                    }
                    else if (sub.Name == "labelRevertImage")
                    {
                        sub.Image = (zData.Default.ButtonImageStyle == ButtonImageLightStyle) ? Properties.Resources.revertIconLight : Properties.Resources.revertIconDark;
                    }
                }

                else if (c.GetType() == typeof(Panel))
                {
                    Panel sub = (Panel)c;
                    sub.BackColor = zData.Default.BG;
                    sub.ForeColor = zData.Default.TextFore;

                    // Don't border things with the tag 'no border'
                    if (c.Tag == null)
                    {
                        sub.BorderStyle = zData.Default.PanelBorderStyle;
                        return;
                    }

                    string cTag = (string)c.Tag.ToString();

                    if (cTag == null)
                    {
                        sub.BorderStyle = zData.Default.PanelBorderStyle;
                        return;
                    }

                    if (cTag.Contains("NoBorder"))
                    {
                        sub.BorderStyle = BorderStyle.None;
                    }
                    else
                    {
                        sub.BorderStyle = zData.Default.PanelBorderStyle;
                    }
                }

                else if (c.GetType() == typeof(Form))
                {
                    Form sub = (Form)c;
                    sub.BackColor = zData.Default.BG;
                    sub.ForeColor = zData.Default.TextFore;
                }

                else if (c.GetType() == typeof(Button))
                {
                    Button sub = (Button)c;
                    sub.BackColor = zData.Default.ButtonBG;
                    sub.ForeColor = zData.Default.ButtonFore;
                    sub.FlatStyle = zData.Default.ButtonFlatStyle;

                    sub.FlatAppearance.BorderColor = zData.Default.ButtonBG;
                    sub.FlatAppearance.BorderSize = 0;
                    sub.FlatAppearance.CheckedBackColor = zData.Default.ButtonBG;

                    sub.UseVisualStyleBackColor = zData.Default.ButtonUseVisualStyles;

                    // Different image for different buttons, light/dark version depending on theme
                    if (sub.Name == "buttonShuffle")
                    {
                        sub.Image = (zData.Default.ButtonImageStyle == ButtonImageLightStyle) ? Properties.Resources.shuffleIconLight : Properties.Resources.shuffleIconDark;
                    }
                    else if (sub.Name == "buttonPlayMusic")
                    {
                        sub.Image = (zData.Default.ButtonImageStyle == ButtonImageLightStyle) ? Properties.Resources.playIconLight : Properties.Resources.playIconDark;
                    }
                    else if (sub.Name == "buttonRevert")
                    {
                        sub.Image = (zData.Default.ButtonImageStyle == ButtonImageLightStyle) ? Properties.Resources.revertIconLight : Properties.Resources.revertIconDark;
                    }
                }

                else if (c.GetType() == typeof(ComboBox))
                {
                    ComboBox sub = (ComboBox)c;
                    sub.BackColor = zData.Default.ButtonBG;
                    sub.ForeColor = zData.Default.ButtonFore;
                    sub.FlatStyle = zData.Default.ButtonFlatStyle;
                }

                else if (c.GetType() == typeof(ListView))
                {
                    ListView sub = (ListView)c;
                    sub.BackColor = zData.Default.ButtonBG;
                    sub.ForeColor = zData.Default.ButtonFore;
                    sub.BorderStyle = zData.Default.PanelBorderStyle;

                    updateListBox();
                }

                else
                {
                    c.BackColor = zData.Default.BG;
                    c.ForeColor = zData.Default.TextFore;
                }

                // Recurse
                ColourAllControls(c);
            }
        }

        private void comboBoxMusicPlayer_DrawItem(object sender, DrawItemEventArgs e)
        {
            int index = e.Index >= 0 ? e.Index : 0;
            var brush = Brushes.Black;
            e.DrawBackground();
            e.Graphics.DrawString(comboBoxMusicPlayer.Items[index].ToString(), e.Font, brush, e.Bounds, StringFormat.GenericDefault);
            e.DrawFocusRectangle();
        }

        private void comboBoxBGColour_DrawItem(object sender, DrawItemEventArgs e)
        {
            int index = e.Index >= 0 ? e.Index : 0;
            var brush = Brushes.Black;
            e.DrawBackground();
            e.Graphics.DrawString(comboBoxBGColour.Items[index].ToString(), e.Font, brush, e.Bounds, StringFormat.GenericDefault);
            e.DrawFocusRectangle();
        }
    }
}
