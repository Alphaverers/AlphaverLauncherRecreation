namespace AlphaverLauncherRecreation.forms
{
    partial class Keys
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Keys));
            this.userNameBox = new System.Windows.Forms.TextBox();
            this.keyBox = new System.Windows.Forms.RichTextBox();
            this.generateButton = new System.Windows.Forms.Button();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // userNameBox
            // 
            this.userNameBox.Location = new System.Drawing.Point(29, 34);
            this.userNameBox.Name = "userNameBox";
            this.userNameBox.Size = new System.Drawing.Size(100, 20);
            this.userNameBox.TabIndex = 0;
            // 
            // keyBox
            // 
            this.keyBox.Location = new System.Drawing.Point(29, 69);
            this.keyBox.Name = "keyBox";
            this.keyBox.ReadOnly = true;
            this.keyBox.Size = new System.Drawing.Size(151, 56);
            this.keyBox.TabIndex = 1;
            this.keyBox.Text = "";
            // 
            // generateButton
            // 
            this.generateButton.Location = new System.Drawing.Point(135, 32);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(75, 23);
            this.generateButton.TabIndex = 2;
            this.generateButton.Text = "Generate";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(29, 180);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.ReadOnly = true;
            this.richTextBox2.Size = new System.Drawing.Size(151, 38);
            this.richTextBox2.TabIndex = 3;
            this.richTextBox2.Text = "47984-25158-78941";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Lilypad Key Generator";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Unrpreview2 Key";
            // 
            // Keys
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::AlphaverLauncherRecreation.Properties.Resources.dirt;
            this.ClientSize = new System.Drawing.Size(405, 331);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.generateButton);
            this.Controls.Add(this.keyBox);
            this.Controls.Add(this.userNameBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Keys";
            this.Text = "Keys";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox userNameBox;
        private System.Windows.Forms.RichTextBox keyBox;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}