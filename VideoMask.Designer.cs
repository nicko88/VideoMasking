namespace VideoMasking
{
    partial class VideoMask
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VideoMask));
            this.SuspendLayout();
            // 
            // VideoMask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 150);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "VideoMask";
            this.Text = "VideoMask";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.VideoMask_FormClosing);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.VideoMask_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.VideoMask_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion
    }
}