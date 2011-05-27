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
            this.toolStripMenu = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonClose = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonEmpty = new System.Windows.Forms.ToolStripButton();
            this.toolStripMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // hexBoxFileContent
            // 
            this.hexBoxFileContent.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hexBoxFileContent.LineInfoForeColor = System.Drawing.Color.Empty;
            this.hexBoxFileContent.LineInfoVisible = true;
            this.hexBoxFileContent.Location = new System.Drawing.Point(12, 38);
            this.hexBoxFileContent.Name = "hexBoxFileContent";
            this.hexBoxFileContent.ShadowSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(60)))), ((int)(((byte)(188)))), ((int)(((byte)(255)))));
            this.hexBoxFileContent.Size = new System.Drawing.Size(663, 396);
            this.hexBoxFileContent.StringViewVisible = true;
            this.hexBoxFileContent.TabIndex = 0;
            this.hexBoxFileContent.UseFixedBytesPerLine = true;
            this.hexBoxFileContent.VScrollBarVisible = true;
            // 
            // toolStripMenu
            // 
            this.toolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonSave,
            this.toolStripButtonEmpty,
            this.toolStripButtonClose});
            this.toolStripMenu.Location = new System.Drawing.Point(0, 0);
            this.toolStripMenu.Name = "toolStripMenu";
            this.toolStripMenu.Size = new System.Drawing.Size(687, 25);
            this.toolStripMenu.TabIndex = 1;
            this.toolStripMenu.Text = "Menu";
            // 
            // toolStripButtonSave
            // 
            this.toolStripButtonSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSave.Image = global::CNRService.StreamsFinder.Properties.Resources._1306333379_095;
            this.toolStripButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSave.Name = "toolStripButtonSave";
            this.toolStripButtonSave.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonSave.Text = "Save changes";
            this.toolStripButtonSave.Click += new System.EventHandler(this.toolStripButtonSave_Click);
            // 
            // toolStripButtonClose
            // 
            this.toolStripButtonClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonClose.Image = global::CNRService.StreamsFinder.Properties.Resources._1306333295_cross_circle_frame;
            this.toolStripButtonClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonClose.Name = "toolStripButtonClose";
            this.toolStripButtonClose.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonClose.Text = "Close window";
            this.toolStripButtonClose.Click += new System.EventHandler(this.toolStripButtonClose_Click);
            // 
            // toolStripButtonEmpty
            // 
            this.toolStripButtonEmpty.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonEmpty.Image = global::CNRService.StreamsFinder.Properties.Resources._1306514738_edit_clear;
            this.toolStripButtonEmpty.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEmpty.Name = "toolStripButtonEmpty";
            this.toolStripButtonEmpty.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonEmpty.Text = "Clear content";
            this.toolStripButtonEmpty.Click += new System.EventHandler(this.toolStripButtonEmpty_Click);
            // 
            // HexEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 446);
            this.Controls.Add(this.toolStripMenu);
            this.Controls.Add(this.hexBoxFileContent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "HexEditor";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "HexEditor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HexEditor_FormClosing);
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Be.Windows.Forms.HexBox hexBoxFileContent;
        private System.Windows.Forms.ToolStrip toolStripMenu;
        private System.Windows.Forms.ToolStripButton toolStripButtonSave;
        private System.Windows.Forms.ToolStripButton toolStripButtonClose;
        private System.Windows.Forms.ToolStripButton toolStripButtonEmpty;

    }
}