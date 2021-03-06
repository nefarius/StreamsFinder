﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace CNRService.StreamsFinder
{
    public partial class HexEditor : Form
    {
        public FileStream fileStream = null;

        public HexEditor()
        {
            InitializeComponent();
        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            this.hexBoxFileContent.ByteProvider.ApplyChanges();
        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void HexEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            // TODO: ???
        }

        private void toolStripButtonEmpty_Click(object sender, EventArgs e)
        {
            hexBoxFileContent.ByteProvider.DeleteBytes(0, hexBoxFileContent.ByteProvider.Length);
            hexBoxFileContent.Refresh();
        }

        private void toolStripButtonCut_Click(object sender, EventArgs e)
        {
            hexBoxFileContent.Cut();
        }

        private void toolStripButtonCopy_Click(object sender, EventArgs e)
        {
            hexBoxFileContent.Copy();
        }

        private void toolStripButtonPaste_Click(object sender, EventArgs e)
        {
            hexBoxFileContent.Paste();
        }
    }
}
