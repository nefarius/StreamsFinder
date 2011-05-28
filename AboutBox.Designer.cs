namespace CNRService.StreamsFinder
{
    partial class AboutBox
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.linkLabelNefarius = new System.Windows.Forms.LinkLabel();
            this.linkLabelCodeproject = new System.Windows.Forms.LinkLabel();
            this.buttonClose = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.linkLabelHexBox = new System.Windows.Forms.LinkLabel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Author of original project:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Author of this fork:";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.linkLabelNefarius, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.linkLabelCodeproject, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.linkLabelHexBox, 1, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(252, 93);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // linkLabelNefarius
            // 
            this.linkLabelNefarius.AutoSize = true;
            this.linkLabelNefarius.Location = new System.Drawing.Point(133, 30);
            this.linkLabelNefarius.Name = "linkLabelNefarius";
            this.linkLabelNefarius.Size = new System.Drawing.Size(98, 13);
            this.linkLabelNefarius.TabIndex = 4;
            this.linkLabelNefarius.TabStop = true;
            this.linkLabelNefarius.Text = "Benjamin Höglinger";
            this.linkLabelNefarius.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelNefarius_LinkClicked);
            // 
            // linkLabelCodeproject
            // 
            this.linkLabelCodeproject.AutoSize = true;
            this.linkLabelCodeproject.Location = new System.Drawing.Point(133, 0);
            this.linkLabelCodeproject.Name = "linkLabelCodeproject";
            this.linkLabelCodeproject.Size = new System.Drawing.Size(70, 13);
            this.linkLabelCodeproject.TabIndex = 4;
            this.linkLabelCodeproject.TabStop = true;
            this.linkLabelCodeproject.Text = "Marco Roello";
            this.linkLabelCodeproject.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelCodeproject_LinkClicked);
            // 
            // buttonClose
            // 
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonClose.Location = new System.Drawing.Point(189, 111);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 3;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Hex-Editor Control:";
            // 
            // linkLabelHexBox
            // 
            this.linkLabelHexBox.AutoSize = true;
            this.linkLabelHexBox.Location = new System.Drawing.Point(133, 60);
            this.linkLabelHexBox.Name = "linkLabelHexBox";
            this.linkLabelHexBox.Size = new System.Drawing.Size(65, 13);
            this.linkLabelHexBox.TabIndex = 6;
            this.linkLabelHexBox.TabStop = true;
            this.linkLabelHexBox.Text = "bernhardelbl";
            this.linkLabelHexBox.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelHexBox_LinkClicked);
            // 
            // AboutBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonClose;
            this.ClientSize = new System.Drawing.Size(276, 146);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AboutBox";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About this software";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.LinkLabel linkLabelNefarius;
        private System.Windows.Forms.LinkLabel linkLabelCodeproject;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel linkLabelHexBox;
    }
}