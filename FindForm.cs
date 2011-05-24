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
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace CNRService.StreamsFinder
{
    /// <summary>
    /// Descrizione di riepilogo per Form1.
    /// </summary>
    public class FindForm : System.Windows.Forms.Form
    {
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGrid dataGridResult;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonFind;
        private System.Windows.Forms.TextBox textBoxFind;
        private System.Windows.Forms.Button buttonBrowse;
        private System.ComponentModel.IContainer components;
        private CNRService.StreamsFinder.FileInfoData fileInfoData1;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn5;
        private System.Windows.Forms.Splitter splitter1;

        private Thread SearchThread;
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
            this.buttonRemoveSelected = new System.Windows.Forms.Button();
            this.buttonSelectAll = new System.Windows.Forms.Button();
            this.checkBoxSubFolders = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.buttonFind = new System.Windows.Forms.Button();
            this.dataGridResult = new System.Windows.Forms.DataGrid();
            this.fileInfoData1 = new CNRService.StreamsFinder.FileInfoData();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn5 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.timerGrid = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileInfoData1)).BeginInit();
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
            // buttonRemoveSelected
            // 
            this.buttonRemoveSelected.BackColor = System.Drawing.SystemColors.Control;
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
            // dataGridResult
            // 
            this.dataGridResult.CaptionBackColor = System.Drawing.Color.CornflowerBlue;
            this.dataGridResult.CaptionText = "Files Found";
            this.dataGridResult.CausesValidation = false;
            this.dataGridResult.DataMember = "FileInfo";
            this.dataGridResult.DataSource = this.fileInfoData1;
            this.dataGridResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridResult.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridResult.Location = new System.Drawing.Point(0, 112);
            this.dataGridResult.Name = "dataGridResult";
            this.dataGridResult.ReadOnly = true;
            this.dataGridResult.Size = new System.Drawing.Size(792, 454);
            this.dataGridResult.TabIndex = 2;
            this.dataGridResult.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            // 
            // fileInfoData1
            // 
            this.fileInfoData1.DataSetName = "FileInfoData";
            this.fileInfoData1.Locale = new System.Globalization.CultureInfo("en-US");
            this.fileInfoData1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.DataGrid = this.dataGridResult;
            this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn1,
            this.dataGridTextBoxColumn2,
            this.dataGridTextBoxColumn3,
            this.dataGridTextBoxColumn4,
            this.dataGridTextBoxColumn5});
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle1.MappingName = "FileInfo";
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "File Name";
            this.dataGridTextBoxColumn1.MappingName = "File Name";
            this.dataGridTextBoxColumn1.Width = 200;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "Stream";
            this.dataGridTextBoxColumn2.MappingName = "Stream Name";
            this.dataGridTextBoxColumn2.Width = 75;
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.HeaderText = "Size (bytes)";
            this.dataGridTextBoxColumn3.MappingName = "Stream Size";
            this.dataGridTextBoxColumn3.Width = 75;
            // 
            // dataGridTextBoxColumn4
            // 
            this.dataGridTextBoxColumn4.Format = "";
            this.dataGridTextBoxColumn4.FormatInfo = null;
            this.dataGridTextBoxColumn4.HeaderText = "Location";
            this.dataGridTextBoxColumn4.MappingName = "Location";
            this.dataGridTextBoxColumn4.Width = 150;
            // 
            // dataGridTextBoxColumn5
            // 
            this.dataGridTextBoxColumn5.Format = "";
            this.dataGridTextBoxColumn5.FormatInfo = null;
            this.dataGridTextBoxColumn5.HeaderText = "Created";
            this.dataGridTextBoxColumn5.MappingName = "Creation Date";
            this.dataGridTextBoxColumn5.Width = 75;
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
            this.timerGrid.Enabled = true;
            this.timerGrid.Interval = 300;
            this.timerGrid.Tick += new System.EventHandler(this.timerGrid_Tick);
            // 
            // FindForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.dataGridResult);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FindForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search for NTFS Streams";
            this.Load += new System.EventHandler(this.FindForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileInfoData1)).EndInit();
            this.ResumeLayout(false);

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
            if (SearchThread != null)
            {
                if (SearchThread.ThreadState == ThreadState.Running)
                    SearchThread.Abort();
            }
            if (this.buttonFind.Text == "Stop search")
            {
                this.buttonFind.Text = "Start search";
            }
            else
            {
                this.buttonFind.Text = "Stop search";

                this.fileInfoData1.FileInfo.Rows.Clear();

                Thread t = new Thread(new ThreadStart(FindFiles));
                SearchThread = t;
                SearchThread.Start();

                Thread.Sleep(200);

            }
        }

        private delegate void FindFilesCallback();
        private void FindFiles()
        {
            if (this.textBoxFind.InvokeRequired)
            {
                DirSearch(this.textBoxFind.Text, this.checkBoxSubFolders.Checked);
                FindFilesCallback ff = new FindFilesCallback(FindFiles);
                this.Invoke(ff);
            }
            else
            {
                this.buttonFind.Text = "Start search";
            }
        }

        private void DirSearch(string sDir, bool subFolders)
        {
            try
            {
                foreach (string f in Directory.GetFiles(sDir))
                {
                    FileInfo FSInfo = new FileInfo(f);
                    NTFS.FileStreams FS = new NTFS.FileStreams(f);

                    foreach (NTFS.StreamInfo s in FS)
                    {
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
                String caption = "Results:  (" + this.ArrayFileInfo.Count.ToString() + ")";
                this.dataGridResult.CaptionText = caption;

                if (subFolders)
                {
                    foreach (string d in Directory.GetDirectories(sDir))
                    {
                        DirSearch(d, subFolders);
                    }
                }
            }
            catch
            {
            }
        }

        private void FindForm_Load(object sender, System.EventArgs e)
        {
            DataView dw = this.fileInfoData1.FileInfo.DefaultView;
            dw.AllowEdit = false;
            dw.AllowDelete = false;
            dw.AllowNew = false;
            this.dataGridResult.DataSource = dw;
        }

        private void RemoveSelectedStreams()
        {
            CurrencyManager cm = 
                (CurrencyManager)this.BindingContext[dataGridResult.DataSource, dataGridResult.DataMember];
            List<FileInfoData.FileInfoRow> rowsToDelete = new List<FileInfoData.FileInfoRow>();

            DataView dv = (DataView)cm.List;
            for (int i = 0; i < dv.Count; ++i)
            {
                if (dataGridResult.IsSelected(i))
                {
                    FileInfoData.FileInfoRow r = (FileInfoData.FileInfoRow)dv[i].Row;

                    NTFS.FileStreams FS = new NTFS.FileStreams(r.File_Name);

                    foreach (NTFS.StreamInfo s in FS)
                    {
                        if (s.Name == r.Stream_Name)
                        {
                            s.Delete();
                        }
                    }

                    rowsToDelete.Add(r);
                }
            }

            if (rowsToDelete.Count > 0)
                foreach (FileInfoData.FileInfoRow tmpRow in rowsToDelete)
                    tmpRow.Delete();
        }

        public ArrayList GetSelectedRows(DataGrid dg)
        {
            ArrayList al = new ArrayList();

            CurrencyManager cm = (CurrencyManager)this.BindingContext[dg.DataSource, dg.DataMember];

            DataView dv = (DataView)cm.List;
            for (int i = 0; i < dv.Count; ++i)
            {
                if (dg.IsSelected(i))
                    al.Add(i);
            }
            return al;
        }

        private void buttonBrowse_Click(object sender, System.EventArgs e)
        {
            if (this.folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                this.textBoxFind.Text = this.folderBrowserDialog1.SelectedPath;
        }

        private void timerGrid_Tick(object sender, System.EventArgs e)
        {
            this.timerGrid.Enabled = false;

            int cnt = ArrayFileInfo.Count;


            for (int i = lastIndexAdded; i < cnt; i++)
            {
                FileInfoStruct fis = (FileInfoStruct)ArrayFileInfo[i];

                FileInfoData.FileInfoRow r = this.fileInfoData1.FileInfo.NewFileInfoRow();
                r.BeginEdit();
                r.File_Name = fis.File_Name;
                r.Stream_Name = fis.Stream_Name;
                r.Stream_Size = fis.Stream_Size;
                r.Location = fis.Location;
                r.Creation_Date = fis.Creation_Date;
                r.EndEdit();
                this.fileInfoData1.FileInfo.AddFileInfoRow(r);
            }
            lastIndexAdded = cnt;
            this.timerGrid.Enabled = true;
        }

        private void buttonSelectAll_Click(object sender, EventArgs e)
        {
            CurrencyManager cm = (CurrencyManager)this.BindingContext[dataGridResult.DataSource, dataGridResult.DataMember];

            DataView dv = (DataView)cm.List;
            for (int i = 0; i < dv.Count; ++i)
            {
                dataGridResult.Select(i);
            }
        }

        private void buttonRemoveSelected_Click(object sender, EventArgs e)
        {
            string msg = "Do you want to delete the selected Streams?";

            if (MessageBox.Show(msg, "Delete Streams", MessageBoxButtons.YesNo) == DialogResult.Yes)
                RemoveSelectedStreams();
        }
    }
}
