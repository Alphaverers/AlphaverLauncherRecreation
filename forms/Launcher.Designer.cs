using System.Drawing;

namespace AlphaverLauncherRecreation
{
    partial class Launcher
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Launcher));
            this.website = new System.Windows.Forms.WebBrowser();
            this.playButton = new System.Windows.Forms.Button();
            this.settingsButton = new System.Windows.Forms.Button();
            this.logintext = new System.Windows.Forms.Label();
            this.backgroundthing = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.backgroundthing)).BeginInit();
            this.SuspendLayout();
            // 
            // website
            // 
            this.website.Dock = System.Windows.Forms.DockStyle.Top;
            this.website.Location = new System.Drawing.Point(0, 0);
            this.website.MinimumSize = new System.Drawing.Size(1, 1);
            this.website.Name = "website";
            this.website.Size = new System.Drawing.Size(707, 329);
            this.website.TabIndex = 0;
            this.website.Url = new System.Uri("https://exalpha-dev.github.io", System.UriKind.Absolute);
            // 
            // playButton
            // 
            this.playButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.playButton.Location = new System.Drawing.Point(498, 345);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(197, 32);
            this.playButton.TabIndex = 1;
            this.playButton.Text = "Play";
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Click += new System.EventHandler(this.playButton_ClickAsync);
            // 
            // settingsButton
            // 
            this.settingsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.settingsButton.Location = new System.Drawing.Point(498, 388);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(197, 32);
            this.settingsButton.TabIndex = 2;
            this.settingsButton.Text = "Settings";
            this.settingsButton.UseVisualStyleBackColor = true;
            this.settingsButton.Click += new System.EventHandler(this.settingsButton_Click);
            // 
            // logintext
            // 
            this.logintext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.logintext.AutoSize = true;
            this.logintext.Location = new System.Drawing.Point(12, 407);
            this.logintext.Name = "logintext";
            this.logintext.Size = new System.Drawing.Size(93, 13);
            this.logintext.TabIndex = 3;
            this.logintext.Text = "Logged in as User";
            // 
            // backgroundthing
            // 
            this.backgroundthing.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.backgroundthing.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.backgroundthing.BackgroundImage = global::AlphaverLauncherRecreation.Properties.Resources.stone;
            this.backgroundthing.Enabled = false;
            this.backgroundthing.Location = new System.Drawing.Point(477, -108);
            this.backgroundthing.Name = "backgroundthing";
            this.backgroundthing.Size = new System.Drawing.Size(230, 540);
            this.backgroundthing.TabIndex = 4;
            this.backgroundthing.TabStop = false;
            // 
            // Launcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::AlphaverLauncherRecreation.Properties.Resources.dirt;
            this.ClientSize = new System.Drawing.Size(707, 432);
            this.Controls.Add(this.website);
            this.Controls.Add(this.logintext);
            this.Controls.Add(this.settingsButton);
            this.Controls.Add(this.playButton);
            this.Controls.Add(this.backgroundthing);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Launcher";
            this.Text = "Minecraft Launcher";
            ((System.ComponentModel.ISupportInitialize)(this.backgroundthing)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser website;
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.Button settingsButton;
        private System.Windows.Forms.Label logintext;
        private System.Windows.Forms.PictureBox backgroundthing;
    }
}

