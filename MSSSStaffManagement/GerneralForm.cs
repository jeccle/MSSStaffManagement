using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSSSStaffManagement
{
    public partial class GerneralForm : Form
    {
        public GerneralForm()
        {
            InitializeComponent();

        }
        Dictionary<string, string> MasterFile = new Dictionary<string, string>();

        private void ReadFile(string path)
        {
            try
            {
                using (var reader = new StreamReader(File.Open(path, FileMode.Open), Encoding.UTF8, false))
                {
                    Trace.TraceInformation("Loading from " + path);
                    while (!reader.EndOfStream)
                    {
                        string[] items = reader.ReadLine().Split(',');
                        MasterFile.Add(items[0], items[1]);
                    }
                }
            }
            catch (ArgumentException)
            {
                statusLabel.Text = "Values already exist within list.";
            }
        }

        private void DisplayItems(ListBox listBox, Dictionary<string, string> keyValues)
        {
            listBox.Items.Clear();
            foreach (var item in keyValues)
            {
                listBox.Items.Add(item.Key + " " + item.Value);
            }
        }

        private void GerneralForm_KeyDown(object sender, KeyEventArgs e)
        {   // Activiate KeyPreview property
            if (e.Alt && e.KeyCode.Equals(Keys.A))
            {
                AdminForm adminForm = new AdminForm(); // Parse parameters when you get up to it.
            }
            if (e.Alt && e.KeyCode.Equals(Keys.D))
            {
                ReadFile(@"MalinStaffNamesV2.csv");
                DisplayItems(listBoxRead, MasterFile);
            }
        }

    }
}
