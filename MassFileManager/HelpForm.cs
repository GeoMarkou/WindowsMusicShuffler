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
    public partial class HelpForm : Form
    {
        /// <summary>
        /// Displays 'about' information for the mass file manager class
        /// </summary>
        public HelpForm()
        {
            InitializeComponent();

            labelGeneralInfo.Text = "An application designed to help shuffling files. Many programs do not have a good shuffle option (such as VLC or Audiosurf) and this app aims to solve that."
            + "\n"
            + "\nSimply drop files / folders you wish to select into the program and select the action you wish to perform. You can also select a folder the long way using file>open or ctrl+o.";

            labelPlayMusicHelp.Text = "Play music:"
            + "\nSends the list of files to VLC as a playlist";

            labelShuffleHelp.Text = "Shuffle:"
            + "\nShuffles the selected files with the pattern [001] - filename.";

            labelRevertHelp.Text = "Fix filenames:"
            + "\nReverts the files' names to their original ones.";

            labelSignature.Text = "Version 1.8"
            + "\nAuthored by Georgios Markou"
            + "\ngeomarkou@rocketmail.com";
        }


        /// <summary>
        /// Exit the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCloseForm_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void HelpForm_Shown(object sender, EventArgs e)
        {
            if (zData.Default.Scale)
            {
                double heightScale = ((double)((double)this.Width - (double)this.MinimumSize.Width) / 100.0) + 9.0;
                double widthScale = (((double)(double)this.Height - (double)this.MinimumSize.Height) / 100.0) + 9.0;
                float fontScale = Convert.ToSingle((heightScale > widthScale) ? widthScale : heightScale);

                Font = new Font("Arial", fontScale, FontStyle.Regular);
            }
            else
            {
                this.Font = new Font("Arial", (float)9, FontStyle.Regular);
            }
        }
    }
}
