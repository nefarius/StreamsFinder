using System;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Collections;

namespace CNRService.StreamsFinder
{
    public partial class FindForm
    {
        #region Windows Form Designer generated code
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonFind;
        private System.Windows.Forms.TextBox textBoxFind;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Timer timerGrid;
        private System.Windows.Forms.CheckBox checkBoxSubFolders;
        private Button buttonSelectAll;
        private Button buttonRemoveSelected;
        private Label labelCurrentDirectory;
        private Label labelDirectory;
        private Button buttonOpenHex;
        private DataGridView dataGridResult;
        private BindingSource fileInfoData1BindingSource;
        private StatusStrip statusStripInfo;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel labelFoundItems;
        private Button buttonExport;
        private SaveFileDialog saveFileDialogExport;
        private DataGridViewTextBoxColumn fileNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn streamNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn streamSizeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn locationDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn creationDateDataGridViewTextBoxColumn;
        private LinkLabel linkLabelAbout;
        private System.ComponentModel.IContainer components;
        private CNRService.StreamsFinder.FileInfoData fileInfoDataStreams;
        private System.ComponentModel.BackgroundWorker backgroundWorkerScan;

        public struct FileInfoStruct
        {
            public string File_Name;
            public string Stream_Name;
            public long Stream_Size;
            public string Location;
            public System.DateTime Creation_Date;
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FindForm));
            this.textBoxFind = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonExport = new System.Windows.Forms.Button();
            this.buttonOpenHex = new System.Windows.Forms.Button();
            this.labelDirectory = new System.Windows.Forms.Label();
            this.labelCurrentDirectory = new System.Windows.Forms.Label();
            this.buttonRemoveSelected = new System.Windows.Forms.Button();
            this.buttonSelectAll = new System.Windows.Forms.Button();
            this.checkBoxSubFolders = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.buttonFind = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.timerGrid = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorkerScan = new System.ComponentModel.BackgroundWorker();
            this.dataGridResult = new System.Windows.Forms.DataGridView();
            this.statusStripInfo = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelFoundItems = new System.Windows.Forms.ToolStripStatusLabel();
            this.saveFileDialogExport = new System.Windows.Forms.SaveFileDialog();
            this.fileNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.streamNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.streamSizeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.locationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.creationDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fileInfoData1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fileInfoDataStreams = new CNRService.StreamsFinder.FileInfoData();
            this.linkLabelAbout = new System.Windows.Forms.LinkLabel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridResult)).BeginInit();
            this.statusStripInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileInfoData1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileInfoDataStreams)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxFind
            // 
            this.textBoxFind.Location = new System.Drawing.Point(16, 32);
            this.textBoxFind.Name = "textBoxFind";
            this.textBoxFind.Size = new System.Drawing.Size(408, 20);
            this.textBoxFind.TabIndex = 0;
            this.textBoxFind.Text = "C:\\";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel1.Controls.Add(this.linkLabelAbout);
            this.panel1.Controls.Add(this.buttonExport);
            this.panel1.Controls.Add(this.buttonOpenHex);
            this.panel1.Controls.Add(this.labelDirectory);
            this.panel1.Controls.Add(this.labelCurrentDirectory);
            this.panel1.Controls.Add(this.buttonRemoveSelected);
            this.panel1.Controls.Add(this.buttonSelectAll);
            this.panel1.Controls.Add(this.checkBoxSubFolders);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.buttonBrowse);
            this.panel1.Controls.Add(this.buttonFind);
            this.panel1.Controls.Add(this.textBoxFind);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(792, 112);
            this.panel1.TabIndex = 1;
            // 
            // buttonExport
            // 
            this.buttonExport.BackColor = System.Drawing.SystemColors.Control;
            this.buttonExport.Enabled = false;
            this.buttonExport.Location = new System.Drawing.Point(511, 64);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(89, 23);
            this.buttonExport.TabIndex = 12;
            this.buttonExport.Text = "Export to file...";
            this.buttonExport.UseVisualStyleBackColor = true;
            this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
            // 
            // buttonOpenHex
            // 
            this.buttonOpenHex.BackColor = System.Drawing.SystemColors.Control;
            this.buttonOpenHex.Enabled = false;
            this.buttonOpenHex.Location = new System.Drawing.Point(366, 64);
            this.buttonOpenHex.Name = "buttonOpenHex";
            this.buttonOpenHex.Size = new System.Drawing.Size(139, 23);
            this.buttonOpenHex.TabIndex = 11;
            this.buttonOpenHex.Text = "Open file in Hex-Editor...";
            this.buttonOpenHex.UseVisualStyleBackColor = true;
            this.buttonOpenHex.Click += new System.EventHandler(this.buttonOpenHex_Click);
            // 
            // labelDirectory
            // 
            this.labelDirectory.AutoSize = true;
            this.labelDirectory.Location = new System.Drawing.Point(16, 93);
            this.labelDirectory.Name = "labelDirectory";
            this.labelDirectory.Size = new System.Drawing.Size(87, 13);
            this.labelDirectory.TabIndex = 10;
            this.labelDirectory.Text = "Current directory:";
            this.labelDirectory.Visible = false;
            // 
            // labelCurrentDirectory
            // 
            this.labelCurrentDirectory.AutoEllipsis = true;
            this.labelCurrentDirectory.Location = new System.Drawing.Point(109, 90);
            this.labelCurrentDirectory.Name = "labelCurrentDirectory";
            this.labelCurrentDirectory.Size = new System.Drawing.Size(671, 19);
            this.labelCurrentDirectory.TabIndex = 9;
            this.labelCurrentDirectory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonRemoveSelected
            // 
            this.buttonRemoveSelected.BackColor = System.Drawing.SystemColors.Control;
            this.buttonRemoveSelected.Enabled = false;
            this.buttonRemoveSelected.Location = new System.Drawing.Point(207, 64);
            this.buttonRemoveSelected.Name = "buttonRemoveSelected";
            this.buttonRemoveSelected.Size = new System.Drawing.Size(153, 23);
            this.buttonRemoveSelected.TabIndex = 8;
            this.buttonRemoveSelected.Text = "Remove selected streams...";
            this.buttonRemoveSelected.UseVisualStyleBackColor = true;
            this.buttonRemoveSelected.Click += new System.EventHandler(this.buttonRemoveSelected_Click);
            // 
            // buttonSelectAll
            // 
            this.buttonSelectAll.BackColor = System.Drawing.SystemColors.Control;
            this.buttonSelectAll.Enabled = false;
            this.buttonSelectAll.Location = new System.Drawing.Point(97, 64);
            this.buttonSelectAll.Name = "buttonSelectAll";
            this.buttonSelectAll.Size = new System.Drawing.Size(104, 23);
            this.buttonSelectAll.TabIndex = 7;
            this.buttonSelectAll.Text = "Select all streams";
            this.buttonSelectAll.UseVisualStyleBackColor = true;
            this.buttonSelectAll.Click += new System.EventHandler(this.buttonSelectAll_Click);
            // 
            // checkBoxSubFolders
            // 
            this.checkBoxSubFolders.Checked = true;
            this.checkBoxSubFolders.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxSubFolders.Location = new System.Drawing.Point(511, 30);
            this.checkBoxSubFolders.Name = "checkBoxSubFolders";
            this.checkBoxSubFolders.Size = new System.Drawing.Size(128, 24);
            this.checkBoxSubFolders.TabIndex = 6;
            this.checkBoxSubFolders.Text = "scan subfolders?";
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(16, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Select start-up folder:";
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.BackColor = System.Drawing.SystemColors.Control;
            this.buttonBrowse.Location = new System.Drawing.Point(430, 30);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowse.TabIndex = 2;
            this.buttonBrowse.Text = "Browse...";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // buttonFind
            // 
            this.buttonFind.BackColor = System.Drawing.SystemColors.Control;
            this.buttonFind.Location = new System.Drawing.Point(16, 64);
            this.buttonFind.Name = "buttonFind";
            this.buttonFind.Size = new System.Drawing.Size(75, 23);
            this.buttonFind.TabIndex = 1;
            this.buttonFind.Text = "Start search";
            this.buttonFind.UseVisualStyleBackColor = true;
            this.buttonFind.Click += new System.EventHandler(this.buttonFind_Click);
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 112);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(792, 3);
            this.splitter1.TabIndex = 3;
            this.splitter1.TabStop = false;
            // 
            // timerGrid
            // 
            this.timerGrid.Interval = 300;
            this.timerGrid.Tick += new System.EventHandler(this.timerGrid_Tick);
            // 
            // backgroundWorkerScan
            // 
            this.backgroundWorkerScan.WorkerReportsProgress = true;
            this.backgroundWorkerScan.WorkerSupportsCancellation = true;
            this.backgroundWorkerScan.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerScan_DoWork);
            this.backgroundWorkerScan.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerScan_ProgressChanged);
            this.backgroundWorkerScan.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerScan_RunWorkerCompleted);
            // 
            // dataGridResult
            // 
            this.dataGridResult.AllowUserToAddRows = false;
            this.dataGridResult.AllowUserToResizeRows = false;
            this.dataGridResult.AutoGenerateColumns = false;
            this.dataGridResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fileNameDataGridViewTextBoxColumn,
            this.streamNameDataGridViewTextBoxColumn,
            this.streamSizeDataGridViewTextBoxColumn,
            this.locationDataGridViewTextBoxColumn,
            this.creationDateDataGridViewTextBoxColumn});
            this.dataGridResult.DataMember = "FileInfo";
            this.dataGridResult.DataSource = this.fileInfoData1BindingSource;
            this.dataGridResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridResult.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridResult.Location = new System.Drawing.Point(0, 115);
            this.dataGridResult.Name = "dataGridResult";
            this.dataGridResult.ReadOnly = true;
            this.dataGridResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridResult.Size = new System.Drawing.Size(792, 429);
            this.dataGridResult.TabIndex = 4;
            this.dataGridResult.SelectionChanged += new System.EventHandler(this.dataGridResult_SelectionChanged);
            // 
            // statusStripInfo
            // 
            this.statusStripInfo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.labelFoundItems});
            this.statusStripInfo.Location = new System.Drawing.Point(0, 544);
            this.statusStripInfo.Name = "statusStripInfo";
            this.statusStripInfo.Size = new System.Drawing.Size(792, 22);
            this.statusStripInfo.TabIndex = 5;
            this.statusStripInfo.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(87, 17);
            this.toolStripStatusLabel1.Text = "Streams found:";
            // 
            // labelFoundItems
            // 
            this.labelFoundItems.Name = "labelFoundItems";
            this.labelFoundItems.Size = new System.Drawing.Size(13, 17);
            this.labelFoundItems.Text = "0";
            // 
            // saveFileDialogExport
            // 
            this.saveFileDialogExport.Filter = "All files|*.*";
            // 
            // fileNameDataGridViewTextBoxColumn
            // 
            this.fileNameDataGridViewTextBoxColumn.DataPropertyName = "File Name";
            this.fileNameDataGridViewTextBoxColumn.HeaderText = "File Name";
            this.fileNameDataGridViewTextBoxColumn.Name = "fileNameDataGridViewTextBoxColumn";
            this.fileNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.fileNameDataGridViewTextBoxColumn.Width = 350;
            // 
            // streamNameDataGridViewTextBoxColumn
            // 
            this.streamNameDataGridViewTextBoxColumn.DataPropertyName = "Stream Name";
            this.streamNameDataGridViewTextBoxColumn.HeaderText = "Stream Name";
            this.streamNameDataGridViewTextBoxColumn.Name = "streamNameDataGridViewTextBoxColumn";
            this.streamNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // streamSizeDataGridViewTextBoxColumn
            // 
            this.streamSizeDataGridViewTextBoxColumn.DataPropertyName = "Stream Size";
            this.streamSizeDataGridViewTextBoxColumn.HeaderText = "Stream Size";
            this.streamSizeDataGridViewTextBoxColumn.Name = "streamSizeDataGridViewTextBoxColumn";
            this.streamSizeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // locationDataGridViewTextBoxColumn
            // 
            this.locationDataGridViewTextBoxColumn.DataPropertyName = "Location";
            this.locationDataGridViewTextBoxColumn.HeaderText = "Location";
            this.locationDataGridViewTextBoxColumn.Name = "locationDataGridViewTextBoxColumn";
            this.locationDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // creationDateDataGridViewTextBoxColumn
            // 
            this.creationDateDataGridViewTextBoxColumn.DataPropertyName = "Creation Date";
            this.creationDateDataGridViewTextBoxColumn.HeaderText = "Creation Date";
            this.creationDateDataGridViewTextBoxColumn.Name = "creationDateDataGridViewTextBoxColumn";
            this.creationDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.creationDateDataGridViewTextBoxColumn.Width = 99;
            // 
            // fileInfoData1BindingSource
            // 
            this.fileInfoData1BindingSource.DataSource = this.fileInfoDataStreams;
            this.fileInfoData1BindingSource.Position = 0;
            // 
            // fileInfoDataStreams
            // 
            this.fileInfoDataStreams.DataSetName = "FileInfoData";
            this.fileInfoDataStreams.Locale = new System.Globalization.CultureInfo("en-US");
            this.fileInfoDataStreams.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // linkLabelAbout
            // 
            this.linkLabelAbout.AutoSize = true;
            this.linkLabelAbout.LinkColor = System.Drawing.Color.White;
            this.linkLabelAbout.Location = new System.Drawing.Point(736, 8);
            this.linkLabelAbout.Name = "linkLabelAbout";
            this.linkLabelAbout.Size = new System.Drawing.Size(44, 13);
            this.linkLabelAbout.TabIndex = 13;
            this.linkLabelAbout.TabStop = true;
            this.linkLabelAbout.Text = "About...";
            this.linkLabelAbout.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelAbout_LinkClicked);
            // 
            // FindForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.dataGridResult);
            this.Controls.Add(this.statusStripInfo);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(808, 604);
            this.Name = "FindForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NTFS Stream Scanner and Editor";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridResult)).EndInit();
            this.statusStripInfo.ResumeLayout(false);
            this.statusStripInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileInfoData1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileInfoDataStreams)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
    }
}
