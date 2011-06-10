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

/*
 * Big parts of this project were rewritten by Benjamin Höglinger aka Nefarius
 * 
 */

using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Be.Windows.Forms;

namespace CNRService.StreamsFinder
{
    /// <summary>
    /// Descrizione di riepilogo per Form1.
    /// </summary>
    public partial class FindForm : System.Windows.Forms.Form
    {
        private ArrayList ArrayFileInfo;
        private int lastIndexAdded = 0;

        public FindForm()
        {
            InitializeComponent();

            ArrayFileInfo = new ArrayList();
#if DEBUG
            textBoxFind.Text = @"E:\Downloads";
#endif
        }

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
                try
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
                }
                catch (IOException ioe)
                {
                    MessageBox.Show(ioe.Message, "An error occurred",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                buttonFind.Text = "Stop search";
                labelUsageInfo.Visible = true;

                lastIndexAdded = 0;
                ArrayFileInfo.Clear();
                fileInfoDataStreams.FileInfo.Rows.Clear();
                labelDirectory.Visible = true;
                labelCurrentDirectory.Visible = true;

                backgroundWorkerScan.RunWorkerAsync();
                timerGrid.Enabled = true;
            }
        }

        /// <summary>
        /// Scans a given directory for alternate data streams.
        /// </summary>
        /// <param name="sDir">The directory root.</param>
        /// <param name="subFolders">Scan subdirectories recursive?</param>
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
            if (this.folderBrowserDialog.ShowDialog() == DialogResult.OK)
                this.textBoxFind.Text = this.folderBrowserDialog.SelectedPath;
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
        /// <param name="dirname">The path (name) of the current directory.</param>
        private delegate void ReportDirNameCallback(String dirname);
        /// <summary>
        /// Updates the current directory display label.
        /// </summary>
        /// <param name="dirname">The path (name) of the current directory.</param>
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
        /// Show about box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkLabelAbout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new AboutBox().ShowDialog();
        }

        /// <summary>
        /// If the user deletes one or more rows, delete the streams on the file system.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridResult_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DataRowView drv = e.Row.DataBoundItem as DataRowView;
            FileInfoData.FileInfoRow fir = drv.Row as FileInfoData.FileInfoRow;
            NTFS.FileStreams FS = new NTFS.FileStreams(fir.File_Name);

            foreach (NTFS.StreamInfo s in FS)
                if (s.Name == fir.Stream_Name)
                    s.Delete();
        }

        /// <summary>
        /// Opens hex editor on row double click.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridResult_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            DataRowView drv = dgv.Rows[e.RowIndex].DataBoundItem as DataRowView;
            FileInfoData.FileInfoRow fir = drv.Row as FileInfoData.FileInfoRow;

            HexEditor he = new HexEditor();

            NTFS.FileStreams FS = new NTFS.FileStreams(fir.File_Name);

            foreach (NTFS.StreamInfo s in FS)
            {
                if (s.Name == fir.Stream_Name)
                {
                    using (FileStream fs = s.Open(FileMode.Open))
                    {
                        if (fs == null)
                        {
                            MessageBox.Show("Accessing acquired file failed, " +
                                "maybe you have insufficient rights or the file is in use.",
                                "Access failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        he.labelFileName.Text = fir.File_Name;
                        he.labelStreamName.Text = fir.Stream_Name;
                        he.fileStream = fs;
                        he.hexBoxFileContent.ByteProvider = new DynamicFileByteProvider(fs);
                        he.ShowDialog();
                    }
                }
            }

            he.Dispose();
            he = null;
        }

        /// <summary>
        /// Selects a row and displays a context menu with stream actions.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridResult_MouseUp(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hitTestInfo;
            DataGridView dgv = sender as DataGridView;

            if (e.Button == MouseButtons.Right)
            {
                hitTestInfo = dgv.HitTest(e.X, e.Y);

                if (hitTestInfo.Type == DataGridViewHitTestType.Cell)
                {
                    foreach (DataGridViewCell cell in dgv.SelectedCells)
                        cell.Selected = false;

                    dgv.Rows[hitTestInfo.RowIndex].Selected = true;
                    contextMenuStripGrid.Show(dgv, new Point(e.X, e.Y));
                }
            }
        }

        /// <summary>
        /// Exports a streams' content to a file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exportStreamToFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataRowView drv = dataGridResult.SelectedRows[0].DataBoundItem as DataRowView;
            FileInfoData.FileInfoRow fir = drv.Row as FileInfoData.FileInfoRow;
            NTFS.FileStreams FS = new NTFS.FileStreams(fir.File_Name);

            foreach (NTFS.StreamInfo s in FS)
            {
                if (s.Name == fir.Stream_Name)
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

        /// <summary>
        /// Executes or opens the selected file with the default application.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openDefaultStreamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataRowView drv = dataGridResult.SelectedRows[0].DataBoundItem as DataRowView;
            FileInfoData.FileInfoRow fir = drv.Row as FileInfoData.FileInfoRow;

            try
            {
                Process.Start(fir.File_Name);
            }
            catch (System.ComponentModel.Win32Exception) { }
        }

        /// <summary>
        /// Opens the containing folder of the file's location.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openContainingFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataRowView drv = dataGridResult.SelectedRows[0].DataBoundItem as DataRowView;
            FileInfoData.FileInfoRow fir = drv.Row as FileInfoData.FileInfoRow;

            try
            {
                Process.Start(fir.Location);
            }
            catch (System.ComponentModel.Win32Exception) { }
        }
    }
}
