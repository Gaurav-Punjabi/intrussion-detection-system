namespace IDS_Intrussion_Detection_System_.UserInterface.Components {
    partial class FileLogItem {
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnClick = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Raleway", 14F);
            this.lblTitle.Location = new System.Drawing.Point(12, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(239, 22);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Name of the File Changed";
            // 
            // btnClick
            // 
            this.btnClick.Location = new System.Drawing.Point(295, 9);
            this.btnClick.Name = "btnClick";
            this.btnClick.Size = new System.Drawing.Size(75, 23);
            this.btnClick.TabIndex = 1;
            this.btnClick.Text = "Click Me !!!";
            this.btnClick.UseVisualStyleBackColor = true;
            // 
            // FileLogItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnClick);
            this.Controls.Add(this.lblTitle);
            this.Name = "FileLogItem";
            this.Size = new System.Drawing.Size(385, 45);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnClick;
    }
}
