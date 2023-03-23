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
            this.saveButton = new System.Windows.Forms.Button();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.versionPage = new System.Windows.Forms.TabPage();
            this.creditText = new System.Windows.Forms.LinkLabel();
            this.modBox = new System.Windows.Forms.ComboBox();
            this.versionText = new System.Windows.Forms.Label();
            this.modLabel = new System.Windows.Forms.Label();
            this.versionBox = new System.Windows.Forms.ComboBox();
            this.javaPage = new System.Windows.Forms.TabPage();
            this.argumentsBox = new System.Windows.Forms.TextBox();
            this.javaPathBox = new System.Windows.Forms.TextBox();
            this.javaFileSelectButton = new System.Windows.Forms.Button();
            this.argumentsText = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.generalPage = new System.Windows.Forms.TabPage();
            this.launchDelayBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.librariesPathSelectButton = new System.Windows.Forms.Button();
            this.librariesPathBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.consoleCheckBox = new System.Windows.Forms.CheckBox();
            this.jarPathSelectButton = new System.Windows.Forms.Button();
            this.jarPathBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.loadingCheckBox = new System.Windows.Forms.CheckBox();
            this.discordRPCCheckBox = new System.Windows.Forms.CheckBox();
            this.minecraftPathSelectButton = new System.Windows.Forms.Button();
            this.usernameBox = new System.Windows.Forms.TextBox();
            this.minecraftPathBox = new System.Windows.Forms.TextBox();
            this.usernameText = new System.Windows.Forms.Label();
            this.minecraftPathText = new System.Windows.Forms.Label();
            this.infoTab = new System.Windows.Forms.TabPage();
            this.launcherVersionText = new System.Windows.Forms.Label();
            this.alphaverChannelButton = new System.Windows.Forms.Button();
            this.githubRepoButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.addModButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.versionPage.SuspendLayout();
            this.javaPage.SuspendLayout();
            this.generalPage.SuspendLayout();
            this.infoTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabControl.SuspendLayout();
            this.SuspendLayout();
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
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // versionPage
            // 
            this.versionPage.Controls.Add(this.addModButton);
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
            // versionText
            // 
            this.versionText.AutoSize = true;
            this.versionText.Location = new System.Drawing.Point(13, 11);
            this.versionText.Name = "versionText";
            this.versionText.Size = new System.Drawing.Size(42, 13);
            this.versionText.TabIndex = 2;
            this.versionText.Text = "Version";
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
            // javaPage
            // 
            this.javaPage.Controls.Add(this.argumentsBox);
            this.javaPage.Controls.Add(this.javaPathBox);
            this.javaPage.Controls.Add(this.javaFileSelectButton);
            this.javaPage.Controls.Add(this.argumentsText);
            this.javaPage.Controls.Add(this.label1);
            this.javaPage.Location = new System.Drawing.Point(4, 22);
            this.javaPage.Name = "javaPage";
            this.javaPage.Size = new System.Drawing.Size(425, 218);
            this.javaPage.TabIndex = 0;
            this.javaPage.Text = "Java";
            this.javaPage.UseVisualStyleBackColor = true;
            // 
            // argumentsBox
            // 
            this.argumentsBox.Location = new System.Drawing.Point(3, 116);
            this.argumentsBox.Name = "argumentsBox";
            this.argumentsBox.Size = new System.Drawing.Size(376, 20);
            this.argumentsBox.TabIndex = 7;
            this.argumentsBox.Text = "-Xmx2G";
            // 
            // javaPathBox
            // 
            this.javaPathBox.Location = new System.Drawing.Point(3, 44);
            this.javaPathBox.Name = "javaPathBox";
            this.javaPathBox.Size = new System.Drawing.Size(351, 20);
            this.javaPathBox.TabIndex = 11;
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
            // argumentsText
            // 
            this.argumentsText.Location = new System.Drawing.Point(3, 88);
            this.argumentsText.Name = "argumentsText";
            this.argumentsText.Size = new System.Drawing.Size(100, 13);
            this.argumentsText.TabIndex = 0;
            this.argumentsText.Text = "JVM Arguments ";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Java Path (Leave empty for default)";
            // 
            // generalPage
            // 
            this.generalPage.Controls.Add(this.launchDelayBox);
            this.generalPage.Controls.Add(this.label7);
            this.generalPage.Controls.Add(this.librariesPathSelectButton);
            this.generalPage.Controls.Add(this.librariesPathBox);
            this.generalPage.Controls.Add(this.label6);
            this.generalPage.Controls.Add(this.consoleCheckBox);
            this.generalPage.Controls.Add(this.jarPathSelectButton);
            this.generalPage.Controls.Add(this.jarPathBox);
            this.generalPage.Controls.Add(this.label5);
            this.generalPage.Controls.Add(this.label4);
            this.generalPage.Controls.Add(this.loadingCheckBox);
            this.generalPage.Controls.Add(this.discordRPCCheckBox);
            this.generalPage.Controls.Add(this.minecraftPathSelectButton);
            this.generalPage.Controls.Add(this.usernameBox);
            this.generalPage.Controls.Add(this.minecraftPathBox);
            this.generalPage.Controls.Add(this.usernameText);
            this.generalPage.Controls.Add(this.minecraftPathText);
            this.generalPage.Location = new System.Drawing.Point(4, 22);
            this.generalPage.Name = "generalPage";
            this.generalPage.Size = new System.Drawing.Size(425, 218);
            this.generalPage.TabIndex = 0;
            this.generalPage.Text = "General";
            this.generalPage.UseVisualStyleBackColor = true;
            // 
            // launchDelayBox
            // 
            this.launchDelayBox.Location = new System.Drawing.Point(182, 36);
            this.launchDelayBox.Name = "launchDelayBox";
            this.launchDelayBox.Size = new System.Drawing.Size(100, 20);
            this.launchDelayBox.TabIndex = 28;
            this.launchDelayBox.Text = "15";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(182, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 13);
            this.label7.TabIndex = 27;
            this.label7.Text = "Launch Delay";
            // 
            // librariesPathSelectButton
            // 
            this.librariesPathSelectButton.Cursor = System.Windows.Forms.Cursors.No;
            this.librariesPathSelectButton.Location = new System.Drawing.Point(309, 98);
            this.librariesPathSelectButton.Name = "librariesPathSelectButton";
            this.librariesPathSelectButton.Size = new System.Drawing.Size(23, 20);
            this.librariesPathSelectButton.TabIndex = 26;
            this.librariesPathSelectButton.Text = "...";
            this.librariesPathSelectButton.UseVisualStyleBackColor = true;
            // 
            // librariesPathBox
            // 
            this.librariesPathBox.BackColor = System.Drawing.SystemColors.Menu;
            this.librariesPathBox.Location = new System.Drawing.Point(182, 98);
            this.librariesPathBox.Name = "librariesPathBox";
            this.librariesPathBox.Size = new System.Drawing.Size(121, 20);
            this.librariesPathBox.TabIndex = 25;
            this.librariesPathBox.Text = "./bin";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(179, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Libraries";
            // 
            // consoleCheckBox
            // 
            this.consoleCheckBox.AutoSize = true;
            this.consoleCheckBox.Location = new System.Drawing.Point(309, 55);
            this.consoleCheckBox.Name = "consoleCheckBox";
            this.consoleCheckBox.Size = new System.Drawing.Size(106, 17);
            this.consoleCheckBox.TabIndex = 23;
            this.consoleCheckBox.Text = "Console Window";
            this.consoleCheckBox.UseVisualStyleBackColor = true;
            // 
            // jarPathSelectButton
            // 
            this.jarPathSelectButton.Cursor = System.Windows.Forms.Cursors.No;
            this.jarPathSelectButton.Location = new System.Drawing.Point(130, 97);
            this.jarPathSelectButton.Name = "jarPathSelectButton";
            this.jarPathSelectButton.Size = new System.Drawing.Size(23, 20);
            this.jarPathSelectButton.TabIndex = 22;
            this.jarPathSelectButton.Text = "...";
            this.jarPathSelectButton.UseVisualStyleBackColor = true;
            // 
            // jarPathBox
            // 
            this.jarPathBox.BackColor = System.Drawing.SystemColors.Menu;
            this.jarPathBox.Location = new System.Drawing.Point(3, 97);
            this.jarPathBox.Name = "jarPathBox";
            this.jarPathBox.Size = new System.Drawing.Size(121, 20);
            this.jarPathBox.TabIndex = 21;
            this.jarPathBox.Text = "./jars";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(0, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Jars";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(225, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "It\'s currently grayed out due to some problems.";
            // 
            // loadingCheckBox
            // 
            this.loadingCheckBox.AutoSize = true;
            this.loadingCheckBox.Location = new System.Drawing.Point(309, 32);
            this.loadingCheckBox.Name = "loadingCheckBox";
            this.loadingCheckBox.Size = new System.Drawing.Size(83, 17);
            this.loadingCheckBox.TabIndex = 18;
            this.loadingCheckBox.Text = "Loading Bar";
            this.loadingCheckBox.UseVisualStyleBackColor = true;
            // 
            // discordRPCCheckBox
            // 
            this.discordRPCCheckBox.AutoSize = true;
            this.discordRPCCheckBox.Location = new System.Drawing.Point(309, 9);
            this.discordRPCCheckBox.Name = "discordRPCCheckBox";
            this.discordRPCCheckBox.Size = new System.Drawing.Size(87, 17);
            this.discordRPCCheckBox.TabIndex = 17;
            this.discordRPCCheckBox.Text = "Discord RPC";
            this.discordRPCCheckBox.UseVisualStyleBackColor = true;
            // 
            // minecraftPathSelectButton
            // 
            this.minecraftPathSelectButton.Cursor = System.Windows.Forms.Cursors.No;
            this.minecraftPathSelectButton.Enabled = false;
            this.minecraftPathSelectButton.Location = new System.Drawing.Point(130, 161);
            this.minecraftPathSelectButton.Name = "minecraftPathSelectButton";
            this.minecraftPathSelectButton.Size = new System.Drawing.Size(23, 20);
            this.minecraftPathSelectButton.TabIndex = 16;
            this.minecraftPathSelectButton.Text = "...";
            this.minecraftPathSelectButton.UseVisualStyleBackColor = true;
            this.minecraftPathSelectButton.Click += new System.EventHandler(this.minecraftPathSelectButton_Click);
            // 
            // usernameBox
            // 
            this.usernameBox.Location = new System.Drawing.Point(3, 36);
            this.usernameBox.Name = "usernameBox";
            this.usernameBox.Size = new System.Drawing.Size(100, 20);
            this.usernameBox.TabIndex = 1;
            this.usernameBox.Text = "Player";
            // 
            // minecraftPathBox
            // 
            this.minecraftPathBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.minecraftPathBox.Enabled = false;
            this.minecraftPathBox.Location = new System.Drawing.Point(3, 161);
            this.minecraftPathBox.Name = "minecraftPathBox";
            this.minecraftPathBox.Size = new System.Drawing.Size(121, 20);
            this.minecraftPathBox.TabIndex = 5;
            this.minecraftPathBox.Text = "%appdata%/.minecraft";
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
            // minecraftPathText
            // 
            this.minecraftPathText.AutoSize = true;
            this.minecraftPathText.Location = new System.Drawing.Point(0, 135);
            this.minecraftPathText.Name = "minecraftPathText";
            this.minecraftPathText.Size = new System.Drawing.Size(78, 13);
            this.minecraftPathText.TabIndex = 4;
            this.minecraftPathText.Text = ".minecraft Path";
            // 
            // infoTab
            // 
            this.infoTab.Controls.Add(this.launcherVersionText);
            this.infoTab.Controls.Add(this.alphaverChannelButton);
            this.infoTab.Controls.Add(this.githubRepoButton);
            this.infoTab.Controls.Add(this.label3);
            this.infoTab.Controls.Add(this.label2);
            this.infoTab.Controls.Add(this.pictureBox1);
            this.infoTab.Location = new System.Drawing.Point(4, 22);
            this.infoTab.Name = "infoTab";
            this.infoTab.Padding = new System.Windows.Forms.Padding(3);
            this.infoTab.Size = new System.Drawing.Size(425, 218);
            this.infoTab.TabIndex = 1;
            this.infoTab.Text = "Info";
            this.infoTab.UseVisualStyleBackColor = true;
            // 
            // launcherVersionText
            // 
            this.launcherVersionText.AutoSize = true;
            this.launcherVersionText.Location = new System.Drawing.Point(194, 113);
            this.launcherVersionText.Name = "launcherVersionText";
            this.launcherVersionText.Size = new System.Drawing.Size(20, 13);
            this.launcherVersionText.TabIndex = 5;
            this.launcherVersionText.Text = "V3";
            // 
            // alphaverChannelButton
            // 
            this.alphaverChannelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.alphaverChannelButton.Location = new System.Drawing.Point(228, 174);
            this.alphaverChannelButton.Name = "alphaverChannelButton";
            this.alphaverChannelButton.Size = new System.Drawing.Size(82, 35);
            this.alphaverChannelButton.TabIndex = 4;
            this.alphaverChannelButton.Text = "Alphaver Channel";
            this.alphaverChannelButton.UseVisualStyleBackColor = true;
            this.alphaverChannelButton.Click += new System.EventHandler(this.alphaverChannelButton_Click);
            // 
            // githubRepoButton
            // 
            this.githubRepoButton.Location = new System.Drawing.Point(119, 174);
            this.githubRepoButton.Name = "githubRepoButton";
            this.githubRepoButton.Size = new System.Drawing.Size(82, 38);
            this.githubRepoButton.TabIndex = 3;
            this.githubRepoButton.Text = "Github Repo";
            this.githubRepoButton.UseVisualStyleBackColor = true;
            this.githubRepoButton.Click += new System.EventHandler(this.githubRepoButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(116, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(194, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Developed by Gnawmon and Unnatural";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(136, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Alphaver Launcher Recreation";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::AlphaverLauncherRecreation.Properties.Resources.icon;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(167, 26);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(80, 80);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.generalPage);
            this.tabControl.Controls.Add(this.versionPage);
            this.tabControl.Controls.Add(this.javaPage);
            this.tabControl.Controls.Add(this.infoTab);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(433, 244);
            this.tabControl.TabIndex = 0;
            // 
            // addModButton
            // 
            this.addModButton.Location = new System.Drawing.Point(16, 162);
            this.addModButton.Name = "addModButton";
            this.addModButton.Size = new System.Drawing.Size(121, 23);
            this.addModButton.TabIndex = 15;
            this.addModButton.Text = "Add Mod";
            this.addModButton.UseVisualStyleBackColor = true;
            this.addModButton.Click += new System.EventHandler(this.addModButton_Click);
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
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.versionPage.ResumeLayout(false);
            this.versionPage.PerformLayout();
            this.javaPage.ResumeLayout(false);
            this.javaPage.PerformLayout();
            this.generalPage.ResumeLayout(false);
            this.generalPage.PerformLayout();
            this.infoTab.ResumeLayout(false);
            this.infoTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button saveButton;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage generalPage;
        private System.Windows.Forms.CheckBox loadingCheckBox;
        private System.Windows.Forms.CheckBox discordRPCCheckBox;
        private System.Windows.Forms.Button minecraftPathSelectButton;
        private System.Windows.Forms.TextBox usernameBox;
        private System.Windows.Forms.TextBox minecraftPathBox;
        private System.Windows.Forms.Label usernameText;
        private System.Windows.Forms.Label minecraftPathText;
        private System.Windows.Forms.TabPage versionPage;
        private System.Windows.Forms.LinkLabel creditText;
        private System.Windows.Forms.ComboBox modBox;
        private System.Windows.Forms.Label versionText;
        private System.Windows.Forms.Label modLabel;
        private System.Windows.Forms.ComboBox versionBox;
        private System.Windows.Forms.TabPage javaPage;
        private System.Windows.Forms.TextBox argumentsBox;
        private System.Windows.Forms.TextBox javaPathBox;
        private System.Windows.Forms.Button javaFileSelectButton;
        private System.Windows.Forms.Label argumentsText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage infoTab;
        private System.Windows.Forms.Button alphaverChannelButton;
        private System.Windows.Forms.Button githubRepoButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox consoleCheckBox;
        private System.Windows.Forms.Button jarPathSelectButton;
        private System.Windows.Forms.TextBox jarPathBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button librariesPathSelectButton;
        private System.Windows.Forms.TextBox librariesPathBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label launcherVersionText;
        private System.Windows.Forms.TextBox launchDelayBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button addModButton;
    }
}