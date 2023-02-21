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
            this.SuspendLayout();
            // 
            // usernameText
            // 
            this.usernameText.AutoSize = true;
            this.usernameText.Location = new System.Drawing.Point(12, 19);
            this.usernameText.Name = "usernameText";
            this.usernameText.Size = new System.Drawing.Size(55, 13);
            this.usernameText.TabIndex = 0;
            this.usernameText.Text = "Username";
            // 
            // usernameBox
            // 
            this.usernameBox.Location = new System.Drawing.Point(12, 46);
            this.usernameBox.Name = "usernameBox";
            this.usernameBox.Size = new System.Drawing.Size(100, 20);
            this.usernameBox.TabIndex = 1;
            this.usernameBox.Text = "Player";
            // 
            // versionText
            // 
            this.versionText.AutoSize = true;
            this.versionText.Location = new System.Drawing.Point(141, 19);
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
            this.versionBox.Location = new System.Drawing.Point(144, 45);
            this.versionBox.Name = "versionBox";
            this.versionBox.Size = new System.Drawing.Size(121, 21);
            this.versionBox.TabIndex = 3;
            this.versionBox.TextChanged += new System.EventHandler(this.versionBox_TextChanged);
            // 
            // minecraftPathText
            // 
            this.minecraftPathText.AutoSize = true;
            this.minecraftPathText.Location = new System.Drawing.Point(285, 19);
            this.minecraftPathText.Name = "minecraftPathText";
            this.minecraftPathText.Size = new System.Drawing.Size(78, 13);
            this.minecraftPathText.TabIndex = 4;
            this.minecraftPathText.Text = ".minecraft Path";
            // 
            // minecraftPathBox
            // 
            this.minecraftPathBox.Location = new System.Drawing.Point(288, 45);
            this.minecraftPathBox.Name = "minecraftPathBox";
            this.minecraftPathBox.Size = new System.Drawing.Size(100, 20);
            this.minecraftPathBox.TabIndex = 5;
            this.minecraftPathBox.Text = "./.minecraft";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(197, 289);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(191, 42);
            this.saveButton.TabIndex = 6;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // argumentsText
            // 
            this.argumentsText.Location = new System.Drawing.Point(12, 223);
            this.argumentsText.Name = "argumentsText";
            this.argumentsText.Size = new System.Drawing.Size(100, 13);
            this.argumentsText.TabIndex = 0;
            this.argumentsText.Text = "JVM Arguments ";
            // 
            // argumentsBox
            // 
            this.argumentsBox.Location = new System.Drawing.Point(12, 251);
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
            this.modBox.Location = new System.Drawing.Point(144, 112);
            this.modBox.Name = "modBox";
            this.modBox.Size = new System.Drawing.Size(121, 21);
            this.modBox.TabIndex = 9;
            this.modBox.TextChanged += new System.EventHandler(this.modBox_TextChanged);
            // 
            // modLabel
            // 
            this.modLabel.AutoSize = true;
            this.modLabel.Location = new System.Drawing.Point(141, 86);
            this.modLabel.Name = "modLabel";
            this.modLabel.Size = new System.Drawing.Size(28, 13);
            this.modLabel.TabIndex = 8;
            this.modLabel.Text = "Mod";
            // 
            // javaPathBox
            // 
            this.javaPathBox.Location = new System.Drawing.Point(12, 179);
            this.javaPathBox.Name = "javaPathBox";
            this.javaPathBox.Size = new System.Drawing.Size(376, 20);
            this.javaPathBox.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 151);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Java Path (Leave empty for default)";
            // 
            // creditText
            // 
            this.creditText.AutoSize = true;
            this.creditText.Location = new System.Drawing.Point(285, 112);
            this.creditText.Name = "creditText";
            this.creditText.Size = new System.Drawing.Size(74, 13);
            this.creditText.TabIndex = 14;
            this.creditText.TabStop = true;
            this.creditText.Text = "text goes here";
            this.creditText.Visible = false;
            this.creditText.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.creditText_LinkClicked);
            // 
            // SettingsForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::AlphaverLauncherRecreation.Properties.Resources.dirt;
            this.ClientSize = new System.Drawing.Size(457, 343);
            this.Controls.Add(this.creditText);
            this.Controls.Add(this.javaPathBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.modBox);
            this.Controls.Add(this.modLabel);
            this.Controls.Add(this.argumentsBox);
            this.Controls.Add(this.argumentsText);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.minecraftPathBox);
            this.Controls.Add(this.minecraftPathText);
            this.Controls.Add(this.versionBox);
            this.Controls.Add(this.versionText);
            this.Controls.Add(this.usernameBox);
            this.Controls.Add(this.usernameText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}