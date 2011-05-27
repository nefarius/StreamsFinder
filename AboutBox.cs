using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace CNRService.StreamsFinder
{
    public partial class AboutBox : Form
    {
        public AboutBox()
        {
            InitializeComponent();
        }

        private void linkLabelNefarius_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://nefarius.at/windows/StreamsFinder");
        }

        private void linkLabelCodeproject_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://www.codeproject.com/KB/files/ntfsguiextension.aspx");
        }
    }
}
