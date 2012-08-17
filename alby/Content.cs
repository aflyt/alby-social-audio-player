using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Alby
{
    public partial class Content : Form
    {
        Dictionary<String, String[]> Library = new Dictionary<string, string[]>();

        public Content()
        {
            InitializeComponent();
        }

        private void index_Click(object sender, EventArgs e)
        {
            Library indexer = new Library();
            indexer.Index();
            Library = indexer.ReturnIndex();

            foreach (KeyValuePair<String, String[]> entry in Library)
            {
                nowPlayingList.Items.Add(entry.Key + entry.Value);
            }
        }
    }
}
