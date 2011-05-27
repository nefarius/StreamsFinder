//************************************************************************************
// StreamsFinder application
// Copyright (C) 2005, Marco Roello
//
// This software is provided "as-is", without any express or implied warranty. In 
// no event will the authors be held liable for any damages arising from the use 
// of this software.
//
// Permission is granted to anyone to use this software for any purpose, including 
// commercial applications, and to alter it and redistribute it freely, subject to 
// the following restrictions:
//
// 1. The origin of this software must not be misrepresented; you must not claim 
//    that you wrote the original software. If you use this software in a product, 
//    an acknowledgment in the product documentation would be appreciated but is 
//    not required.
//
// 2. Altered source versions must be plainly marked as such, and must not be 
//    misrepresented as being the original software.
//
// 3. This notice may not be removed or altered from any source distribution.
//
//************************************************************************************
using System;
using System.Collections;
using System.Data;
using System.IO;
using System.Windows.Forms;
using Be.Windows.Forms;

namespace CNRService.StreamsFinder
{
    /// <summary>
    /// Descrizione di riepilogo per Form1.
    /// </summary>
    public class FindForm : System.Windows.Forms.Form
    {
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonFind;
        private System.Windows.Forms.TextBox textBoxFind;
        private System.Windows.Forms.Button buttonBrowse;
        private System.ComponentModel.IContainer components;
        private CNRService.StreamsFinder.FileInfoData fileInfoDataStreams;
        private System.Windows.Forms.Splitter splitter1;

        private System.Windows.Forms.Timer timerGrid;

        public struct FileInfoStruct
        {
            public string File_Name;
            public string Stream_Name;
            public long Stream_Size;
            public string Location;
            public System.DateTime Creation_Date;
        }

        private ArrayList ArrayFileInfo;
        private System.Windows.Forms.CheckBox checkBoxSubFolders;
        private Button buttonSelectAll;
        private Button buttonRemoveSelected;
        private System.ComponentModel.BackgroundWorker backgroundWorkerScan;
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
        private int lastIndexAdded = 0;

        public FindForm()
        {
            //
            // Necessario per il supporto di Progettazione Windows Form
            //
            InitializeComponent();

            ArrayFileInfo = new ArrayList();
        }

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
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

        #region Codice generato da Progettazione Windows Form
        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
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
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.timerGrid = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorkerScan = new System.ComponentModel.BackgroundWorker();
            this.fileInfoDataStreams = new CNRService.StreamsFinder.FileInfoData();
            this.dataGridResult = new System.Windows.Forms.DataGridView();
            this.fileInfoData1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.statusStripInfo = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelFoundItems = new System.Windows.Forms.ToolStripStatusLabel();
            this.saveFileDialogExport = new System.Windows.Forms.SaveFileDialog();
            this.fileNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.streamNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.streamSizeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.locationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.creationDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileInfoDataStreams)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileInfoData1BindingSource)).BeginInit();
            this.statusStripInfo.SuspendLayout();
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
            // fileInfoDataStreams
            // 
            this.fileInfoDataStreams.DataSetName = "FileInfoData";
            this.fileInfoDataStreams.Locale = new System.Globalization.CultureInfo("en-US");
            this.fileInfoDataStreams.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            // fileInfoData1BindingSource
            // 
            this.fileInfoData1BindingSource.DataSource = this.fileInfoDataStreams;
            this.fileInfoData1BindingSource.Position = 0;
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
            ((System.ComponentModel.ISupportInitialize)(this.fileInfoDataStreams)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileInfoData1BindingSource)).EndInit();
            this.statusStripInfo.ResumeLayout(false);
            this.statusStripInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        /// <summary>
        /// Il punto di ingresso principale dell'applicazione.
        /// </summary>
        [STAThread]
        static void Main()
        {
            FindForm frm = new FindForm();
            Application.EnableVisualStyles();
            Application.Run(frm);
        }

        private void buttonFind_Click(object sender, System.EventArgs e)
        {
            // If stop is clicked and worker is busy, send a kill signal
            if (backgroundWorkerScan.IsBusy)
            {
                backgroundWorkerScan.CancelAsync();
            }

            // Change search button caption and visibility of additional buttons
            if (this.buttonFind.Text == "Stop search")
            {
                this.buttonFind.Text = "Start search";
                labelDirectory.Visible = false;
                labelCurrentDirectory.Visible = false;
            }
            else // Start search:
            {
                foreach (DriveInfo drive in DriveInfo.GetDrives())
                {
                    if (textBoxFind.Text.Substring(0, 3).ToLower().Contains(drive.Name.ToLower()))
                    {
                        if (!drive.DriveFormat.ToUpper().Equals("NTFS"))
                        {
                            MessageBox.Show("The selected Drive \"" + drive.Name + "\" " + 
                                "is formated with " + drive.DriveFormat + 
                                ", you won't find any streams here.",
                                "Wrong file system", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            return;
                        }
                    }
                }

                this.buttonFind.Text = "Stop search";

                lastIndexAdded = 0;
                ArrayFileInfo.Clear();
                this.fileInfoDataStreams.FileInfo.Rows.Clear();
                labelDirectory.Visible = true;
                labelCurrentDirectory.Visible = true;

                backgroundWorkerScan.RunWorkerAsync();
                timerGrid.Enabled = true;
            }
        }

        private void DirSearch(string sDir, bool subFolders)
        {
            try
            {
                foreach (string f in Directory.GetFiles(sDir))
                {
                    ReportDirName(f);
                    FileInfo FSInfo = new FileInfo(f);
                    NTFS.FileStreams FS = new NTFS.FileStreams(f);

                    foreach (NTFS.StreamInfo s in FS)
                    {
                        if (backgroundWorkerScan.CancellationPending)
                            return;

                        FileInfoStruct fis;
                        fis.File_Name = FS.FileName;
                        fis.Stream_Name = s.Name;
                        fis.Stream_Size = s.Size;
                        fis.Location = FSInfo.DirectoryName;
                        fis.Creation_Date = FSInfo.CreationTime;

                        ArrayFileInfo.Add(fis);
                    }
                }
                // update the results label
                backgroundWorkerScan.ReportProgress(this.ArrayFileInfo.Count);

                if (subFolders)
                {
                    foreach (string d in Directory.GetDirectories(sDir))
                    {
                        if (backgroundWorkerScan.CancellationPending)
                            return;
                        DirSearch(d, subFolders);
                    }
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// Displays a directory browser.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonBrowse_Click(object sender, System.EventArgs e)
        {
            if (this.folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                this.textBoxFind.Text = this.folderBrowserDialog1.SelectedPath;
        }

        /// <summary>
        /// Updates the data grid with the found streams.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerGrid_Tick(object sender, System.EventArgs e)
        {
            this.timerGrid.Enabled = false;
            int cnt = ArrayFileInfo.Count;

            for (int i = lastIndexAdded; i < cnt; i++)
            {
                FileInfoStruct fis = (FileInfoStruct)ArrayFileInfo[i];

                FileInfoData.FileInfoRow r = this.fileInfoDataStreams.FileInfo.NewFileInfoRow();
                r.BeginEdit();
                r.File_Name = fis.File_Name;
                r.Stream_Name = fis.Stream_Name;
                r.Stream_Size = fis.Stream_Size;
                r.Location = fis.Location;
                r.Creation_Date = fis.Creation_Date;
                r.EndEdit();
                this.fileInfoDataStreams.FileInfo.AddFileInfoRow(r);
            }

            lastIndexAdded = cnt;
            this.timerGrid.Enabled = true;
        }

        /// <summary>
        /// Thread-safe report call.
        /// </summary>
        /// <param name="dirname"></param>
        private delegate void ReportDirNameCallback(String dirname);
        /// <summary>
        /// Updates the current directory display label.
        /// </summary>
        /// <param name="dirname"></param>
        private void ReportDirName(string dirname)
        {
            if (labelCurrentDirectory.InvokeRequired)
            {
                ReportDirNameCallback rfc = new ReportDirNameCallback(ReportDirName);
                this.Invoke(rfc, dirname);
            }
            else
            {
                labelCurrentDirectory.Text = Path.GetDirectoryName(dirname);
            }
        }

        /// <summary>
        /// Selects everything in the data grid.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSelectAll_Click(object sender, EventArgs e)
        {
            dataGridResult.SelectAll();
        }

        /// <summary>
        /// Removes the selected entries and streams from the file system.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRemoveSelected_Click(object sender, EventArgs e)
        {
            string msg = "Do you want to delete the selected Streams?";

            if (MessageBox.Show(msg, "Delete Streams",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ArrayList rowsToKill = new ArrayList();

                foreach (DataGridViewRow row in dataGridResult.SelectedRows)
                {
                    FileInfoData.FileInfoRow r = 
                        (FileInfoData.FileInfoRow)fileInfoDataStreams.FileInfo[row.Index];

                    NTFS.FileStreams FS = new NTFS.FileStreams(r.File_Name);

                    foreach (NTFS.StreamInfo s in FS)
                        if (s.Name == r.Stream_Name)
                            s.Delete();

                    rowsToKill.Add(r);
                }

                if (rowsToKill.Count > 0)
                {
                    foreach (FileInfoData.FileInfoRow fir in rowsToKill)
                        fir.Delete();
                    dataGridResult.Update();
                }
            }
        }

        private void backgroundWorkerScan_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            DirSearch(this.textBoxFind.Text, this.checkBoxSubFolders.Checked);
        }

        /// <summary>
        /// Updates scanning progress (found files).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorkerScan_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            labelFoundItems.Text = e.ProgressPercentage.ToString();
        }

        /// <summary>
        /// Called if worked finished his job.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorkerScan_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            labelDirectory.Visible = false;
            labelCurrentDirectory.Visible = false;
            this.buttonFind.Text = "Start search";
            timerGrid.Enabled = false;
            /*
            This call is necessary to update the grid 
            if the scan finished before the first tick could appear.
            */
            timerGrid_Tick(sender, null);
        }

        /// <summary>
        /// Launches the hex editor to display the files' content.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonOpenHex_Click(object sender, EventArgs e)
        {
            HexEditor he = new HexEditor();
            
            foreach (DataGridViewRow item in dataGridResult.SelectedRows)
            {
                string filename = fileInfoDataStreams.FileInfo[item.Index].File_Name;
                string streamname = fileInfoDataStreams.FileInfo[item.Index].Stream_Name;

                NTFS.FileStreams FS = new NTFS.FileStreams(filename);

                foreach (NTFS.StreamInfo s in FS)
                {
                    if (s.Name == streamname)
                    {
                        using(FileStream fs = s.Open(FileMode.Open))
                        {
                            if (fs == null)
                            {
                                MessageBox.Show("Accessing acquired file failed, " +
                                    "maybe you have insufficient rights or the file is in use.",
                                    "Access failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            he.fileStream = fs;
                            he.hexBoxFileContent.ByteProvider = new DynamicFileByteProvider(fs);
                            he.ShowDialog();
                        }
                    }
                }
            }

            he.Dispose();
            he = null;
        }

        /// <summary>
        /// Called if the row selection is changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridResult_SelectionChanged(object sender, EventArgs e)
        {
            if (ArrayFileInfo.Count > 0)
            {
                buttonSelectAll.Enabled = true;
                buttonRemoveSelected.Enabled = true;
                buttonOpenHex.Enabled = true;
                buttonExport.Enabled = true;
            }
            else
            {
                buttonOpenHex.Enabled = false;
                buttonExport.Enabled = false;
                buttonSelectAll.Enabled = false;
                buttonRemoveSelected.Enabled = false;
            }
        }

        /// <summary>
        /// Exports selected stream to file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonExport_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dataGridResult.SelectedRows)
            {
                string filename = fileInfoDataStreams.FileInfo[item.Index].File_Name;
                string streamname = fileInfoDataStreams.FileInfo[item.Index].Stream_Name;

                NTFS.FileStreams FS = new NTFS.FileStreams(filename);

                foreach (NTFS.StreamInfo s in FS)
                {
                    if (s.Name == streamname)
                    {
                        if (saveFileDialogExport.ShowDialog() == DialogResult.OK)
                        {
                            using (FileStream input = s.Open(FileMode.Open))
                            {
                                using (FileStream output = 
                                    new FileStream(saveFileDialogExport.FileName, FileMode.Create))
                                {
                                    int bufferSize = 4096;
                                    byte[] buffer = new byte[bufferSize];
                                    while (true)
                                    {
                                        int read = input.Read(buffer, 0, buffer.Length);
                                        if (read <= 0)
                                        {
                                            return;
                                        }
                                        output.Write(buffer, 0, read);
                                    }
                                }
                            }
                        }                        
                    }
                }
            }
        }
    }
}
