using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CNRService.StreamsFinder
{
    public partial class HexEditor : Form
    {
        public HexEditor()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.hexBoxFileContent.ByteProvider.ApplyChanges();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
