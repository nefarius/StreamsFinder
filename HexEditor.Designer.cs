namespace CNRService.StreamsFinder
{
    partial class HexEditor
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
            this.hexBoxFileContent = new Be.Windows.Forms.HexBox();
            this.SuspendLayout();
            // 
            // hexBoxFileContent
            // 
            this.hexBoxFileContent.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hexBoxFileContent.LineInfoForeColor = System.Drawing.Color.Empty;
            this.hexBoxFileContent.LineInfoVisible = true;
            this.hexBoxFileContent.Location = new System.Drawing.Point(12, 12);
            this.hexBoxFileContent.Name = "hexBoxFileContent";
            this.hexBoxFileContent.ShadowSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(60)))), ((int)(((byte)(188)))), ((int)(((byte)(255)))));
            this.hexBoxFileContent.Size = new System.Drawing.Size(663, 422);
            this.hexBoxFileContent.StringViewVisible = true;
            this.hexBoxFileContent.TabIndex = 0;
            this.hexBoxFileContent.UseFixedBytesPerLine = true;
            this.hexBoxFileContent.VScrollBarVisible = true;
            // 
            // HexEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 446);
            this.Controls.Add(this.hexBoxFileContent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "HexEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "HexEditor";
            this.ResumeLayout(false);

        }

        #endregion

        public Be.Windows.Forms.HexBox hexBoxFileContent;

    }
}