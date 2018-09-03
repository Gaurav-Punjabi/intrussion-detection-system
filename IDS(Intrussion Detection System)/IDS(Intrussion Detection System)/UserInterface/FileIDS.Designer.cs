namespace IDS_Intrussion_Detection_System_.UserInterface {
    partial class FileIDS {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.pnlList = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pnlList
            // 
            this.pnlList.AutoScroll = true;
            this.pnlList.Location = new System.Drawing.Point(0, 0);
            this.pnlList.Name = "pnlList";
            this.pnlList.Size = new System.Drawing.Size(440, 354);
            this.pnlList.TabIndex = 0;
            // 
            // FileIDS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 354);
            this.Controls.Add(this.pnlList);
            this.Name = "FileIDS";
            this.Text = "FileIDS";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlList;
    }
}