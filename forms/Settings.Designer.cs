namespace AlphaverLauncherRecreation
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.usernameText = new System.Windows.Forms.Label();
            this.usernameBox = new System.Windows.Forms.TextBox();
            this.versionText = new System.Windows.Forms.Label();
            this.versionBox = new System.Windows.Forms.ComboBox();
            this.minecraftPathText = new System.Windows.Forms.Label();
            this.minecraftPathBox = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.argumentsText = new System.Windows.Forms.Label();
            this.argumentsBox = new System.Windows.Forms.TextBox();
            this.modBox = new System.Windows.Forms.ComboBox();
            this.modLabel = new System.Windows.Forms.Label();
            this.javaPathBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.creditText = new System.Windows.Forms.LinkLabel();
            this.javaFileSelectButton = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.generalPage = new System.Windows.Forms.TabPage();
            this.minecraftPathSelectButton = new System.Windows.Forms.Button();
            this.javaPage = new System.Windows.Forms.TabPage();
            this.versionPage = new System.Windows.Forms.TabPage();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.tabControl.SuspendLayout();
            this.generalPage.SuspendLayout();
            this.javaPage.SuspendLayout();
            this.versionPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // usernameText
            // 
            this.usernameText.AutoSize = true;
            this.usernameText.Location = new System.Drawing.Point(3, 9);
            this.usernameText.Name = "usernameText";
            this.usernameText.Size = new System.Drawing.Size(55, 13);
            this.usernameText.TabIndex = 0;
            this.usernameText.Text = "Username";
            // 
            // usernameBox
            // 
            this.usernameBox.Location = new System.Drawing.Point(3, 36);
            this.usernameBox.Name = "usernameBox";
            this.usernameBox.Size = new System.Drawing.Size(100, 20);
            this.usernameBox.TabIndex = 1;
            this.usernameBox.Text = "Player";
            // 
            // versionText
            // 
            this.versionText.AutoSize = true;
            this.versionText.Location = new System.Drawing.Point(13, 11);
            this.versionText.Name = "versionText";
            this.versionText.Size = new System.Drawing.Size(42, 13);
            this.versionText.TabIndex = 2;
            this.versionText.Text = "Version";
            // 
            // versionBox
            // 
            this.versionBox.AutoCompleteCustomSource.AddRange(new string[] {
            "v1605_unrpreview2",
            "v1605_preview",
            "lilypad_qa"});
            this.versionBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.versionBox.FormattingEnabled = true;
            this.versionBox.ImeMode = System.Windows.Forms.ImeMode.On;
            this.versionBox.Items.AddRange(new object[] {
            "lilypad_qa",
            "v1605_preview",
            "v1605_unrpreview2"});
            this.versionBox.Location = new System.Drawing.Point(16, 37);
            this.versionBox.Name = "versionBox";
            this.versionBox.Size = new System.Drawing.Size(121, 21);
            this.versionBox.TabIndex = 3;
            this.versionBox.TextChanged += new System.EventHandler(this.versionBox_TextChanged);
            // 
            // minecraftPathText
            // 
            this.minecraftPathText.AutoSize = true;
            this.minecraftPathText.Location = new System.Drawing.Point(0, 78);
            this.minecraftPathText.Name = "minecraftPathText";
            this.minecraftPathText.Size = new System.Drawing.Size(78, 13);
            this.minecraftPathText.TabIndex = 4;
            this.minecraftPathText.Text = ".minecraft Path";
            // 
            // minecraftPathBox
            // 
            this.minecraftPathBox.Location = new System.Drawing.Point(3, 104);
            this.minecraftPathBox.Name = "minecraftPathBox";
            this.minecraftPathBox.Size = new System.Drawing.Size(121, 20);
            this.minecraftPathBox.TabIndex = 5;
            this.minecraftPathBox.Text = "./.minecraft";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(254, 289);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(191, 42);
            this.saveButton.TabIndex = 6;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // argumentsText
            // 
            this.argumentsText.Location = new System.Drawing.Point(3, 88);
            this.argumentsText.Name = "argumentsText";
            this.argumentsText.Size = new System.Drawing.Size(100, 13);
            this.argumentsText.TabIndex = 0;
            this.argumentsText.Text = "JVM Arguments ";
            // 
            // argumentsBox
            // 
            this.argumentsBox.Location = new System.Drawing.Point(3, 116);
            this.argumentsBox.Name = "argumentsBox";
            this.argumentsBox.Size = new System.Drawing.Size(376, 20);
            this.argumentsBox.TabIndex = 7;
            this.argumentsBox.Text = "-Xmx2G";
            // 
            // modBox
            // 
            this.modBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.modBox.FormattingEnabled = true;
            this.modBox.ImeMode = System.Windows.Forms.ImeMode.On;
            this.modBox.Items.AddRange(new object[] {
            "lilypad_qa",
            "v1605_preview",
            "v1605_unrpreview2"});
            this.modBox.Location = new System.Drawing.Point(16, 104);
            this.modBox.Name = "modBox";
            this.modBox.Size = new System.Drawing.Size(121, 21);
            this.modBox.TabIndex = 9;
            this.modBox.TextChanged += new System.EventHandler(this.modBox_TextChanged);
            // 
            // modLabel
            // 
            this.modLabel.AutoSize = true;
            this.modLabel.Location = new System.Drawing.Point(13, 78);
            this.modLabel.Name = "modLabel";
            this.modLabel.Size = new System.Drawing.Size(28, 13);
            this.modLabel.TabIndex = 8;
            this.modLabel.Text = "Mod";
            // 
            // javaPathBox
            // 
            this.javaPathBox.Location = new System.Drawing.Point(3, 44);
            this.javaPathBox.Name = "javaPathBox";
            this.javaPathBox.Size = new System.Drawing.Size(351, 20);
            this.javaPathBox.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Java Path (Leave empty for default)";
            // 
            // creditText
            // 
            this.creditText.AutoSize = true;
            this.creditText.Location = new System.Drawing.Point(157, 104);
            this.creditText.Name = "creditText";
            this.creditText.Size = new System.Drawing.Size(74, 13);
            this.creditText.TabIndex = 14;
            this.creditText.TabStop = true;
            this.creditText.Text = "text goes here";
            this.creditText.Visible = false;
            this.creditText.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.creditText_LinkClicked);
            // 
            // javaFileSelectButton
            // 
            this.javaFileSelectButton.Location = new System.Drawing.Point(356, 44);
            this.javaFileSelectButton.Name = "javaFileSelectButton";
            this.javaFileSelectButton.Size = new System.Drawing.Size(23, 20);
            this.javaFileSelectButton.TabIndex = 15;
            this.javaFileSelectButton.Text = "...";
            this.javaFileSelectButton.UseVisualStyleBackColor = true;
            this.javaFileSelectButton.Click += new System.EventHandler(this.javaFileSelectButton_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.generalPage);
            this.tabControl.Controls.Add(this.javaPage);
            this.tabControl.Controls.Add(this.versionPage);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(433, 244);
            this.tabControl.TabIndex = 0;
            // 
            // generalPage
            // 
            this.generalPage.Controls.Add(this.minecraftPathSelectButton);
            this.generalPage.Controls.Add(this.usernameBox);
            this.generalPage.Controls.Add(this.usernameText);
            this.generalPage.Controls.Add(this.minecraftPathBox);
            this.generalPage.Controls.Add(this.minecraftPathText);
            this.generalPage.Location = new System.Drawing.Point(4, 22);
            this.generalPage.Name = "generalPage";
            this.generalPage.Size = new System.Drawing.Size(425, 218);
            this.generalPage.TabIndex = 0;
            this.generalPage.Text = "General";
            this.generalPage.UseVisualStyleBackColor = true;
            // 
            // minecraftPathSelectButton
            // 
            this.minecraftPathSelectButton.Location = new System.Drawing.Point(130, 104);
            this.minecraftPathSelectButton.Name = "minecraftPathSelectButton";
            this.minecraftPathSelectButton.Size = new System.Drawing.Size(23, 20);
            this.minecraftPathSelectButton.TabIndex = 16;
            this.minecraftPathSelectButton.Text = "...";
            this.minecraftPathSelectButton.UseVisualStyleBackColor = true;
            this.minecraftPathSelectButton.Click += new System.EventHandler(this.minecraftPathSelectButton_Click);
            // 
            // javaPage
            // 
            this.javaPage.Controls.Add(this.argumentsBox);
            this.javaPage.Controls.Add(this.javaFileSelectButton);
            this.javaPage.Controls.Add(this.argumentsText);
            this.javaPage.Controls.Add(this.label1);
            this.javaPage.Controls.Add(this.javaPathBox);
            this.javaPage.Location = new System.Drawing.Point(4, 22);
            this.javaPage.Name = "javaPage";
            this.javaPage.Size = new System.Drawing.Size(425, 218);
            this.javaPage.TabIndex = 0;
            this.javaPage.Text = "Java";
            this.javaPage.UseVisualStyleBackColor = true;
            // 
            // versionPage
            // 
            this.versionPage.Controls.Add(this.creditText);
            this.versionPage.Controls.Add(this.modBox);
            this.versionPage.Controls.Add(this.versionText);
            this.versionPage.Controls.Add(this.modLabel);
            this.versionPage.Controls.Add(this.versionBox);
            this.versionPage.Location = new System.Drawing.Point(4, 22);
            this.versionPage.Name = "versionPage";
            this.versionPage.Size = new System.Drawing.Size(425, 218);
            this.versionPage.TabIndex = 0;
            this.versionPage.Text = "Version";
            this.versionPage.UseVisualStyleBackColor = true;
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // SettingsForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::AlphaverLauncherRecreation.Properties.Resources.dirt;
            this.ClientSize = new System.Drawing.Size(457, 343);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.saveButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.tabControl.ResumeLayout(false);
            this.generalPage.ResumeLayout(false);
            this.generalPage.PerformLayout();
            this.javaPage.ResumeLayout(false);
            this.javaPage.PerformLayout();
            this.versionPage.ResumeLayout(false);
            this.versionPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label usernameText;
        private System.Windows.Forms.TextBox usernameBox;
        private System.Windows.Forms.Label versionText;
        private System.Windows.Forms.ComboBox versionBox;
        private System.Windows.Forms.Label minecraftPathText;
        private System.Windows.Forms.TextBox minecraftPathBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label argumentsText;
        private System.Windows.Forms.TextBox argumentsBox;
        private System.Windows.Forms.ComboBox modBox;
        private System.Windows.Forms.Label modLabel;
        private System.Windows.Forms.TextBox javaPathBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel creditText;
        private System.Windows.Forms.Button javaFileSelectButton;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage generalPage;
        private System.Windows.Forms.TabPage javaPage;
        private System.Windows.Forms.TabPage versionPage;
        private System.Windows.Forms.Button minecraftPathSelectButton;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
    }
}