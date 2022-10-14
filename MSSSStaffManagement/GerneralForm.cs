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
        #region Global Methods
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
        #endregion

        #region Utility Methods
        private void DisplayTextBox(string item)
        {
            string[] kvp = item.Split(' ');
            textBoxPhoneGen.Text = kvp[0];
            textBoxNameGen.Text = kvp[1] + " " + kvp[2];
            statusLabel.Text = item + " selected.";
        }
        #endregion


        #region Form Event/Controls
        private void GerneralForm_KeyDown(object sender, KeyEventArgs e)
        {   // Activiate KeyPreview property
            if (e.Alt && e.KeyCode.Equals(Keys.A))
            {
                AdminForm adminForm = new AdminForm(textBoxPhoneGen.Text, textBoxNameGen.Text); // Parse parameters when you get up to it.
                adminForm.ShowDialog();
            }
            if (e.Alt && e.KeyCode.Equals(Keys.X))
            {
                textBoxNameGen.Focus();
                textBoxNameGen.Clear();
                textBoxPhoneGen.Clear();
            }
            if (e.Alt && e.KeyCode.Equals(Keys.C))
            {
                textBoxPhoneGen.Focus();
                textBoxPhoneGen.Clear();
                textBoxNameGen.Clear();
            }
            if (e.KeyCode == Keys.Right)
            {
                listBoxFiltered.Focus();
            }
            if (e.KeyCode == Keys.Enter)
            {
                DisplayTextBox(listBoxFiltered.SelectedItem.ToString());
            }
            
        }
        private void GerneralForm_Load(object sender, EventArgs e)
        {
            ReadFile(@"MalinStaffNamesV2.csv");
            DisplayItems(listBoxRead, MasterFile);
            textBoxPhoneGen.Focus();
        }

        #endregion

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty((sender as TextBox).Text))
            {
                listBoxFiltered.Items.Clear();
                foreach (var item in MasterFile)
                {
                    if (item.Key.StartsWith((sender as TextBox).Text) )
                        listBoxFiltered.Items.Add(item.Key + " " + item.Value);
                    if (item.Value.ToUpper().StartsWith((sender as TextBox).Text.ToUpper()))
                        listBoxFiltered.Items.Add(item.Key + " " + item.Value);
                }
                
            }

        }


    }
}
