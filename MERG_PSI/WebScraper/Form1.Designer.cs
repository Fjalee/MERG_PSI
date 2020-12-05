namespace WebScraper
{
    partial class Form1
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
            this.ScrapeButton = new System.Windows.Forms.Button();
            this.TextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // ScrapeButton
            // 
            this.ScrapeButton.Location = new System.Drawing.Point(12, 318);
            this.ScrapeButton.Name = "ScrapeButton";
            this.ScrapeButton.Size = new System.Drawing.Size(652, 31);
            this.ScrapeButton.TabIndex = 1;
            this.ScrapeButton.Text = "Scrape";
            this.ScrapeButton.UseVisualStyleBackColor = true;
            this.ScrapeButton.Click += new System.EventHandler(this.ButtonScrape_Click);
            // 
            // TextBox1
            // 
            this.TextBox1.Location = new System.Drawing.Point(12, 12);
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Size = new System.Drawing.Size(652, 300);
            this.TextBox1.TabIndex = 2;
            this.TextBox1.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 361);
            this.Controls.Add(this.TextBox1);
            this.Controls.Add(this.ScrapeButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button ScrapeButton;
        private System.Windows.Forms.RichTextBox TextBox1;
    }
}