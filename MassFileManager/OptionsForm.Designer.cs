namespace MassFileManager
{
    partial class OptionsForm
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
            this.checkBoxRecurse = new System.Windows.Forms.CheckBox();
            this.checkBoxScaleFont = new System.Windows.Forms.CheckBox();
            this.textBoxAddExtension = new System.Windows.Forms.TextBox();
            this.buttonAddExtension = new System.Windows.Forms.Button();
            this.listViewExtensions = new System.Windows.Forms.ListView();
            this.columnHeaderDelete = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonResetExtensions = new System.Windows.Forms.Button();
            this.checkBoxFilterFiles = new System.Windows.Forms.CheckBox();
            this.comboBoxMusicPlayer = new System.Windows.Forms.ComboBox();
            this.labelPreferredPlayer = new System.Windows.Forms.Label();
            this.labelTheme = new System.Windows.Forms.Label();
            this.comboBoxBGColour = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBoxRecurse
            // 
            this.checkBoxRecurse.AutoSize = true;
            this.checkBoxRecurse.Checked = true;
            this.checkBoxRecurse.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxRecurse.Location = new System.Drawing.Point(12, 12);
            this.checkBoxRecurse.Name = "checkBoxRecurse";
            this.checkBoxRecurse.Size = new System.Drawing.Size(164, 17);
            this.checkBoxRecurse.TabIndex = 12;
            this.checkBoxRecurse.Text = "Search directories recursively";
            this.checkBoxRecurse.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.checkBoxRecurse.UseVisualStyleBackColor = true;
            this.checkBoxRecurse.CheckedChanged += new System.EventHandler(this.checkBoxRecurse_CheckedChanged);
            // 
            // checkBoxScaleFont
            // 
            this.checkBoxScaleFont.AutoSize = true;
            this.checkBoxScaleFont.Location = new System.Drawing.Point(12, 42);
            this.checkBoxScaleFont.Name = "checkBoxScaleFont";
            this.checkBoxScaleFont.Size = new System.Drawing.Size(74, 17);
            this.checkBoxScaleFont.TabIndex = 13;
            this.checkBoxScaleFont.Text = "Large font";
            this.checkBoxScaleFont.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.checkBoxScaleFont.UseVisualStyleBackColor = true;
            this.checkBoxScaleFont.CheckedChanged += new System.EventHandler(this.checkBoxScaleFont_CheckedChanged);
            // 
            // textBoxAddExtension
            // 
            this.textBoxAddExtension.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxAddExtension.Location = new System.Drawing.Point(0, 0);
            this.textBoxAddExtension.Name = "textBoxAddExtension";
            this.textBoxAddExtension.Size = new System.Drawing.Size(98, 20);
            this.textBoxAddExtension.TabIndex = 15;
            this.textBoxAddExtension.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxAddExtension_KeyPress);
            // 
            // buttonAddExtension
            // 
            this.buttonAddExtension.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonAddExtension.Location = new System.Drawing.Point(0, 25);
            this.buttonAddExtension.Name = "buttonAddExtension";
            this.buttonAddExtension.Size = new System.Drawing.Size(98, 28);
            this.buttonAddExtension.TabIndex = 16;
            this.buttonAddExtension.Text = "Add";
            this.buttonAddExtension.UseVisualStyleBackColor = true;
            this.buttonAddExtension.Click += new System.EventHandler(this.buttonAddExtension_Click);
            // 
            // listViewExtensions
            // 
            this.listViewExtensions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderDelete,
            this.columnHeaderName});
            this.listViewExtensions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.listViewExtensions.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listViewExtensions.HideSelection = false;
            this.listViewExtensions.Location = new System.Drawing.Point(0, 56);
            this.listViewExtensions.MultiSelect = false;
            this.listViewExtensions.Name = "listViewExtensions";
            this.listViewExtensions.ShowGroups = false;
            this.listViewExtensions.Size = new System.Drawing.Size(260, 129);
            this.listViewExtensions.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listViewExtensions.TabIndex = 17;
            this.listViewExtensions.UseCompatibleStateImageBehavior = false;
            this.listViewExtensions.View = System.Windows.Forms.View.Details;
            this.listViewExtensions.Click += new System.EventHandler(this.listViewExtensions_Click);
            // 
            // columnHeaderDelete
            // 
            this.columnHeaderDelete.Text = "";
            this.columnHeaderDelete.Width = 20;
            // 
            // columnHeaderName
            // 
            this.columnHeaderName.Text = "Extension";
            this.columnHeaderName.Width = 100;
            // 
            // buttonResetExtensions
            // 
            this.buttonResetExtensions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonResetExtensions.Location = new System.Drawing.Point(0, 101);
            this.buttonResetExtensions.Name = "buttonResetExtensions";
            this.buttonResetExtensions.Size = new System.Drawing.Size(98, 28);
            this.buttonResetExtensions.TabIndex = 19;
            this.buttonResetExtensions.Text = "Defaults";
            this.buttonResetExtensions.UseVisualStyleBackColor = true;
            this.buttonResetExtensions.Click += new System.EventHandler(this.buttonResetExtensions_Click);
            // 
            // checkBoxFilterFiles
            // 
            this.checkBoxFilterFiles.AutoSize = true;
            this.checkBoxFilterFiles.Checked = true;
            this.checkBoxFilterFiles.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxFilterFiles.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.checkBoxFilterFiles.Location = new System.Drawing.Point(0, 39);
            this.checkBoxFilterFiles.Name = "checkBoxFilterFiles";
            this.checkBoxFilterFiles.Size = new System.Drawing.Size(260, 17);
            this.checkBoxFilterFiles.TabIndex = 20;
            this.checkBoxFilterFiles.Text = "Only search for the following file types";
            this.checkBoxFilterFiles.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.checkBoxFilterFiles.UseVisualStyleBackColor = true;
            this.checkBoxFilterFiles.CheckedChanged += new System.EventHandler(this.checkBoxFilterFiles_CheckedChanged);
            // 
            // comboBoxMusicPlayer
            // 
            this.comboBoxMusicPlayer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.comboBoxMusicPlayer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMusicPlayer.Items.AddRange(new object[] {
            "ITunes",
            "MediaMonkey",
            "MusicBee",
            "SCM Music Player",
            "the thing thats like vlc but downloads subtitles online",
            "VLC",
            "Winamp",
            "Windows Media Player",
            "Zune Music"});
            this.comboBoxMusicPlayer.Location = new System.Drawing.Point(0, 39);
            this.comboBoxMusicPlayer.Name = "comboBoxMusicPlayer";
            this.comboBoxMusicPlayer.Size = new System.Drawing.Size(363, 21);
            this.comboBoxMusicPlayer.Sorted = true;
            this.comboBoxMusicPlayer.TabIndex = 21;
            this.comboBoxMusicPlayer.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.comboBoxMusicPlayer_DrawItem);
            this.comboBoxMusicPlayer.SelectedIndexChanged += new System.EventHandler(this.comboBoxMusicPlayer_SelectedIndexChanged);
            // 
            // labelPreferredPlayer
            // 
            this.labelPreferredPlayer.AutoSize = true;
            this.labelPreferredPlayer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelPreferredPlayer.Location = new System.Drawing.Point(0, 26);
            this.labelPreferredPlayer.Name = "labelPreferredPlayer";
            this.labelPreferredPlayer.Size = new System.Drawing.Size(69, 13);
            this.labelPreferredPlayer.TabIndex = 22;
            this.labelPreferredPlayer.Text = "Music player:";
            // 
            // labelTheme
            // 
            this.labelTheme.AutoSize = true;
            this.labelTheme.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelTheme.Location = new System.Drawing.Point(0, 26);
            this.labelTheme.Name = "labelTheme";
            this.labelTheme.Size = new System.Drawing.Size(72, 13);
            this.labelTheme.TabIndex = 26;
            this.labelTheme.Text = "Colour theme:";
            // 
            // comboBoxBGColour
            // 
            this.comboBoxBGColour.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.comboBoxBGColour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBGColour.Items.AddRange(new object[] {
            "[default]",
            "Midnight",
            "Cherry",
            "Wood",
            "Professional"});
            this.comboBoxBGColour.Location = new System.Drawing.Point(0, 39);
            this.comboBoxBGColour.Name = "comboBoxBGColour";
            this.comboBoxBGColour.Size = new System.Drawing.Size(363, 21);
            this.comboBoxBGColour.TabIndex = 25;
            this.comboBoxBGColour.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.comboBoxBGColour_DrawItem);
            this.comboBoxBGColour.SelectedIndexChanged += new System.EventHandler(this.comboBoxBGColour_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelTheme);
            this.panel1.Controls.Add(this.comboBoxBGColour);
            this.panel1.Location = new System.Drawing.Point(13, 130);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(363, 60);
            this.panel1.TabIndex = 27;
            this.panel1.Tag = "NoBorder";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.labelPreferredPlayer);
            this.panel2.Controls.Add(this.comboBoxMusicPlayer);
            this.panel2.Location = new System.Drawing.Point(13, 65);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(363, 60);
            this.panel2.TabIndex = 28;
            this.panel2.Tag = "NoBorder";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.checkBoxFilterFiles);
            this.panel3.Controls.Add(this.listViewExtensions);
            this.panel3.Location = new System.Drawing.Point(12, 196);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(260, 185);
            this.panel3.TabIndex = 29;
            this.panel3.Tag = "NoBorder";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.buttonAddExtension);
            this.panel4.Controls.Add(this.buttonResetExtensions);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Controls.Add(this.textBoxAddExtension);
            this.panel4.Location = new System.Drawing.Point(278, 252);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(98, 129);
            this.panel4.TabIndex = 30;
            this.panel4.Tag = "NoBorder";
            // 
            // panel5
            // 
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 20);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(98, 5);
            this.panel5.TabIndex = 20;
            this.panel5.Tag = "NoBorder";
            // 
            // OptionsForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(388, 395);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.checkBoxRecurse);
            this.Controls.Add(this.checkBoxScaleFont);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionsForm";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Options";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxRecurse;
        private System.Windows.Forms.CheckBox checkBoxScaleFont;
        private System.Windows.Forms.TextBox textBoxAddExtension;
        private System.Windows.Forms.Button buttonAddExtension;
        private System.Windows.Forms.ListView listViewExtensions;
        private System.Windows.Forms.ColumnHeader columnHeaderDelete;
        private System.Windows.Forms.ColumnHeader columnHeaderName;
        private System.Windows.Forms.Button buttonResetExtensions;
        private System.Windows.Forms.CheckBox checkBoxFilterFiles;
        private System.Windows.Forms.ComboBox comboBoxMusicPlayer;
        private System.Windows.Forms.Label labelPreferredPlayer;
        private System.Windows.Forms.Label labelTheme;
        private System.Windows.Forms.ComboBox comboBoxBGColour;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
    }
}