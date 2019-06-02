namespace NaiveBlobDetection
{
    partial class Display
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Display));
            this.pictureBoxSource = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSource)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxSource
            // 
            this.pictureBoxSource.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxSource.Name = "pictureBoxSource";
            this.pictureBoxSource.Size = new System.Drawing.Size(402, 412);
            this.pictureBoxSource.TabIndex = 0;
            this.pictureBoxSource.TabStop = false;
            // 
            // Display
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 411);
            this.Controls.Add(this.pictureBoxSource);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Display";
            this.Text = "Naive Blob Detection";
            this.Shown += new System.EventHandler(this.Display_Shown_1);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxSource;
    }
}

