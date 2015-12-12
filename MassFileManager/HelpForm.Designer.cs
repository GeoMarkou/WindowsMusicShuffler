namespace MassFileManager
{
    partial class HelpForm
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
            this.buttonCloseForm = new System.Windows.Forms.Button();
            this.labelPlayMusicImage = new System.Windows.Forms.Label();
            this.labelShuffleImage = new System.Windows.Forms.Label();
            this.labelRevertImage = new System.Windows.Forms.Label();
            this.labelGeneralInfo = new System.Windows.Forms.Label();
            this.labelPlayMusicHelp = new System.Windows.Forms.Label();
            this.splitContainerPlayMusic = new System.Windows.Forms.SplitContainer();
            this.splitContainerShuffle = new System.Windows.Forms.SplitContainer();
            this.labelShuffleHelp = new System.Windows.Forms.Label();
            this.splitContainerRevert = new System.Windows.Forms.SplitContainer();
            this.labelRevertHelp = new System.Windows.Forms.Label();
            this.labelSignature = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerPlayMusic)).BeginInit();
            this.splitContainerPlayMusic.Panel1.SuspendLayout();
            this.splitContainerPlayMusic.Panel2.SuspendLayout();
            this.splitContainerPlayMusic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerShuffle)).BeginInit();
            this.splitContainerShuffle.Panel1.SuspendLayout();
            this.splitContainerShuffle.Panel2.SuspendLayout();
            this.splitContainerShuffle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerRevert)).BeginInit();
            this.splitContainerRevert.Panel1.SuspendLayout();
            this.splitContainerRevert.Panel2.SuspendLayout();
            this.splitContainerRevert.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonCloseForm
            // 
            this.buttonCloseForm.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCloseForm.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonCloseForm.Location = new System.Drawing.Point(10, 424);
            this.buttonCloseForm.Name = "buttonCloseForm";
            this.buttonCloseForm.Size = new System.Drawing.Size(535, 33);
            this.buttonCloseForm.TabIndex = 1;
            this.buttonCloseForm.Text = "Close";
            this.buttonCloseForm.UseVisualStyleBackColor = true;
            this.buttonCloseForm.Click += new System.EventHandler(this.buttonCloseForm_Click);
            // 
            // labelPlayMusicImage
            // 
            this.labelPlayMusicImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelPlayMusicImage.Image = global::MassFileManager.Properties.Resources.playIconDark;
            this.labelPlayMusicImage.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.labelPlayMusicImage.Location = new System.Drawing.Point(0, 0);
            this.labelPlayMusicImage.Name = "labelPlayMusicImage";
            this.labelPlayMusicImage.Size = new System.Drawing.Size(64, 64);
            this.labelPlayMusicImage.TabIndex = 2;
            // 
            // labelShuffleImage
            // 
            this.labelShuffleImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelShuffleImage.Image = global::MassFileManager.Properties.Resources.shuffleIconDark;
            this.labelShuffleImage.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.labelShuffleImage.Location = new System.Drawing.Point(0, 0);
            this.labelShuffleImage.Name = "labelShuffleImage";
            this.labelShuffleImage.Size = new System.Drawing.Size(64, 64);
            this.labelShuffleImage.TabIndex = 3;
            // 
            // labelRevertImage
            // 
            this.labelRevertImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelRevertImage.Image = global::MassFileManager.Properties.Resources.revertIconDark;
            this.labelRevertImage.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.labelRevertImage.Location = new System.Drawing.Point(0, 0);
            this.labelRevertImage.Name = "labelRevertImage";
            this.labelRevertImage.Size = new System.Drawing.Size(64, 64);
            this.labelRevertImage.TabIndex = 4;
            // 
            // labelGeneralInfo
            // 
            this.labelGeneralInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelGeneralInfo.Location = new System.Drawing.Point(10, 10);
            this.labelGeneralInfo.Name = "labelGeneralInfo";
            this.labelGeneralInfo.Size = new System.Drawing.Size(535, 127);
            this.labelGeneralInfo.TabIndex = 5;
            this.labelGeneralInfo.Text = "labelGeneralInfo";
            // 
            // labelPlayMusicHelp
            // 
            this.labelPlayMusicHelp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelPlayMusicHelp.Location = new System.Drawing.Point(0, 0);
            this.labelPlayMusicHelp.Name = "labelPlayMusicHelp";
            this.labelPlayMusicHelp.Size = new System.Drawing.Size(467, 64);
            this.labelPlayMusicHelp.TabIndex = 6;
            this.labelPlayMusicHelp.Text = "labelPlayMusicHelp";
            // 
            // splitContainerPlayMusic
            // 
            this.splitContainerPlayMusic.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitContainerPlayMusic.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerPlayMusic.IsSplitterFixed = true;
            this.splitContainerPlayMusic.Location = new System.Drawing.Point(10, 137);
            this.splitContainerPlayMusic.Name = "splitContainerPlayMusic";
            // 
            // splitContainerPlayMusic.Panel1
            // 
            this.splitContainerPlayMusic.Panel1.Controls.Add(this.labelPlayMusicImage);
            // 
            // splitContainerPlayMusic.Panel2
            // 
            this.splitContainerPlayMusic.Panel2.Controls.Add(this.labelPlayMusicHelp);
            this.splitContainerPlayMusic.Size = new System.Drawing.Size(535, 64);
            this.splitContainerPlayMusic.SplitterDistance = 64;
            this.splitContainerPlayMusic.TabIndex = 7;
            // 
            // splitContainerShuffle
            // 
            this.splitContainerShuffle.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitContainerShuffle.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerShuffle.IsSplitterFixed = true;
            this.splitContainerShuffle.Location = new System.Drawing.Point(10, 201);
            this.splitContainerShuffle.Name = "splitContainerShuffle";
            // 
            // splitContainerShuffle.Panel1
            // 
            this.splitContainerShuffle.Panel1.Controls.Add(this.labelShuffleImage);
            // 
            // splitContainerShuffle.Panel2
            // 
            this.splitContainerShuffle.Panel2.Controls.Add(this.labelShuffleHelp);
            this.splitContainerShuffle.Size = new System.Drawing.Size(535, 64);
            this.splitContainerShuffle.SplitterDistance = 64;
            this.splitContainerShuffle.TabIndex = 8;
            // 
            // labelShuffleHelp
            // 
            this.labelShuffleHelp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelShuffleHelp.Location = new System.Drawing.Point(0, 0);
            this.labelShuffleHelp.Name = "labelShuffleHelp";
            this.labelShuffleHelp.Size = new System.Drawing.Size(467, 64);
            this.labelShuffleHelp.TabIndex = 0;
            this.labelShuffleHelp.Text = "labelShuffleHelp";
            // 
            // splitContainerRevert
            // 
            this.splitContainerRevert.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitContainerRevert.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerRevert.IsSplitterFixed = true;
            this.splitContainerRevert.Location = new System.Drawing.Point(10, 265);
            this.splitContainerRevert.Name = "splitContainerRevert";
            // 
            // splitContainerRevert.Panel1
            // 
            this.splitContainerRevert.Panel1.Controls.Add(this.labelRevertImage);
            // 
            // splitContainerRevert.Panel2
            // 
            this.splitContainerRevert.Panel2.Controls.Add(this.labelRevertHelp);
            this.splitContainerRevert.Size = new System.Drawing.Size(535, 64);
            this.splitContainerRevert.SplitterDistance = 64;
            this.splitContainerRevert.TabIndex = 9;
            // 
            // labelRevertHelp
            // 
            this.labelRevertHelp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelRevertHelp.Location = new System.Drawing.Point(0, 0);
            this.labelRevertHelp.Name = "labelRevertHelp";
            this.labelRevertHelp.Size = new System.Drawing.Size(467, 64);
            this.labelRevertHelp.TabIndex = 0;
            this.labelRevertHelp.Text = "labelRevertHelp";
            // 
            // labelSignature
            // 
            this.labelSignature.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelSignature.Location = new System.Drawing.Point(10, 329);
            this.labelSignature.Name = "labelSignature";
            this.labelSignature.Size = new System.Drawing.Size(535, 92);
            this.labelSignature.TabIndex = 10;
            this.labelSignature.Text = "labelSignature";
            this.labelSignature.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // HelpForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(555, 467);
            this.Controls.Add(this.labelSignature);
            this.Controls.Add(this.splitContainerRevert);
            this.Controls.Add(this.splitContainerShuffle);
            this.Controls.Add(this.splitContainerPlayMusic);
            this.Controls.Add(this.labelGeneralInfo);
            this.Controls.Add(this.buttonCloseForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "HelpForm";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "HelpForm";
            this.Shown += new System.EventHandler(this.HelpForm_Shown);
            this.splitContainerPlayMusic.Panel1.ResumeLayout(false);
            this.splitContainerPlayMusic.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerPlayMusic)).EndInit();
            this.splitContainerPlayMusic.ResumeLayout(false);
            this.splitContainerShuffle.Panel1.ResumeLayout(false);
            this.splitContainerShuffle.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerShuffle)).EndInit();
            this.splitContainerShuffle.ResumeLayout(false);
            this.splitContainerRevert.Panel1.ResumeLayout(false);
            this.splitContainerRevert.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerRevert)).EndInit();
            this.splitContainerRevert.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonCloseForm;
        private System.Windows.Forms.Label labelPlayMusicImage;
        private System.Windows.Forms.Label labelShuffleImage;
        private System.Windows.Forms.Label labelRevertImage;
        private System.Windows.Forms.Label labelGeneralInfo;
        private System.Windows.Forms.Label labelPlayMusicHelp;
        private System.Windows.Forms.SplitContainer splitContainerPlayMusic;
        private System.Windows.Forms.SplitContainer splitContainerShuffle;
        private System.Windows.Forms.Label labelShuffleHelp;
        private System.Windows.Forms.SplitContainer splitContainerRevert;
        private System.Windows.Forms.Label labelRevertHelp;
        private System.Windows.Forms.Label labelSignature;
    }
}