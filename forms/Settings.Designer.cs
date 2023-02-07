namespace AlphaverLauncherRecreation
{
    partial class Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.usernameText = new System.Windows.Forms.Label();
            this.usernameBox = new System.Windows.Forms.TextBox();
            this.versionText = new System.Windows.Forms.Label();
            this.versionBox = new System.Windows.Forms.ComboBox();
            this.minecraftLocationText = new System.Windows.Forms.Label();
            this.minecraftLocationBox = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
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
            // 
            // minecraftLocationText
            // 
            this.minecraftLocationText.AutoSize = true;
            this.minecraftLocationText.Location = new System.Drawing.Point(285, 19);
            this.minecraftLocationText.Name = "minecraftLocationText";
            this.minecraftLocationText.Size = new System.Drawing.Size(97, 13);
            this.minecraftLocationText.TabIndex = 4;
            this.minecraftLocationText.Text = ".minecraft Location";
            // 
            // minecraftLocationBox
            // 
            this.minecraftLocationBox.Location = new System.Drawing.Point(288, 45);
            this.minecraftLocationBox.Name = "minecraftLocationBox";
            this.minecraftLocationBox.Size = new System.Drawing.Size(100, 20);
            this.minecraftLocationBox.TabIndex = 5;
            this.minecraftLocationBox.Text = "./.minecraft";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(197, 208);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(191, 42);
            this.saveButton.TabIndex = 6;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // Settings
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::AlphaverLauncherRecreation.Properties.Resources.dirt;
            this.ClientSize = new System.Drawing.Size(457, 262);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.minecraftLocationBox);
            this.Controls.Add(this.minecraftLocationText);
            this.Controls.Add(this.versionBox);
            this.Controls.Add(this.versionText);
            this.Controls.Add(this.usernameBox);
            this.Controls.Add(this.usernameText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Settings";
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
        private System.Windows.Forms.Label minecraftLocationText;
        private System.Windows.Forms.TextBox minecraftLocationBox;
        private System.Windows.Forms.Button saveButton;
    }
}