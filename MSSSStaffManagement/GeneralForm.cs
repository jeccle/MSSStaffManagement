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
/*
 *  Filter Keypress inputs.
 *  Add tooltips to controls.
 *  Remove mouse click functionality
 *  Figure out how to stop admin form from focusing key binding textbox.
 *  Format tab indexes
 * 
 */
namespace MSSSStaffManagement
{
    public partial class GeneralForm : Form
    {
        public GeneralForm()
        {
            InitializeComponent();
        }
        public static Dictionary<string, string> MasterFile = new Dictionary<string, string>();
        public static Dictionary<string, string> backupDict = MasterFile;
        string path = @"MalinStaffNamesV2.csv";

        #region Global Methods
        public static string ReadFile(string path, Dictionary<string, string> MasterFile)
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
                    return "Staff List Loaded.";
                }
            }
            catch (ArgumentException)
            {
                 return "Values already exist within list.";
            }
        }
        public static Dictionary<string, string> GetDictionary()
        {
            return MasterFile;
        }
        public static void SetDictionary(Dictionary<string, string> dict)
        {
            MasterFile = dict;
        }
        #endregion

        #region Utility Methods
        private void SaveData(string path, Dictionary<string, string> keyValues)
        {
            using (StreamWriter writer = new StreamWriter(File.Open(path, FileMode.Open), Encoding.UTF8))
            {
                foreach (var item in keyValues)
                    writer.WriteLine(item.Key + "," + item.Value);
            }
            Trace.TraceInformation("Saved to file. Path: " + path);
        }
        private void DisplayTextBox(string item)
        {
            string[] kvp = item.Split(new char[] { ' ' }, 2);
            textBoxPhone.Text = kvp[0];
            textBoxName.Text = kvp[1];
            statusLabel.Text = item + " selected.";
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

        #region Form Event/Controls
        private void GerneralForm_KeyDown(object sender, KeyEventArgs e)
        {   // Activiate KeyPreview property
            if (e.Alt && e.KeyCode == Keys.A)
            {
                if (!string.IsNullOrEmpty(listBoxFiltered.SelectedIndex.ToString()))
                {
                    AdminForm adminForm = new AdminForm(textBoxPhone.Text, textBoxName.Text); // Parse parameters when you get up to it.
                    adminForm.FormClosed += AdminForm_Closed;
                    adminForm.ShowDialog();
                }
            }
            if (e.Alt && e.KeyCode == Keys.X)
            {   // Sets focus to Name Box.
                textBoxName.Focus();
                textBoxName.Clear();
                textBoxPhone.Clear();
                toolTipGen.Show("Enter Name to search.", textBoxName, 10, -75, 5000);
            }
            if (e.Alt && e.KeyCode == Keys.C)
            {   // Sets focus to Phone Box.
                textBoxPhone.Focus();
                textBoxPhone.Clear();
                textBoxName.Clear();
                toolTipGen.Show("Enter Phone ID to search.", textBoxPhone, 10, -75, 5000);
            }
            if (e.Alt && e.KeyCode == Keys.G)
            {   // Save & Exit.
                
                this.Close();
            }
            if (e.KeyCode == Keys.Right)
            {   // Move focus to listBoxFiltered first record.
                
                if (listBoxFiltered.Items.Count > 0)
                {
                    listBoxFiltered.Focus();
                    listBoxFiltered.SetSelected(0, true);
                }
            }
            if (e.KeyCode == Keys.Left)
            {   // Move focus to listBoxFiltered first record.
                listBoxRead.Focus();
            }
            if (e.KeyCode == Keys.Enter && listBoxFiltered.Focused)
            {   // Selects item from listBox.
                DisplayTextBox(listBoxFiltered.SelectedItem.ToString());
                listBoxFiltered.SetSelected(0, true);
            }
            
        }
        private void GerneralForm_Load(object sender, EventArgs e)
        {
            statusLabel.Text = ReadFile(path, MasterFile);
            DisplayItems(listBoxRead, MasterFile);
            textBoxPhone.Focus();
            toolTipGen.Show("Enter Phone ID to search.", textBoxPhone, 2000);
        }
        private void AdminForm_Closed(object sender, FormClosedEventArgs e)
        {
            DisplayItems(listBoxRead, MasterFile);
            statusLabel.Text = "List has been updated.";
            listBoxFiltered.Items.Clear();
            SaveData(path, MasterFile);
        }
        private void textBox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty((sender as TextBox).Text))
            {
                listBoxFiltered.Items.Clear();
                foreach (var item in MasterFile)
                {
                    if (item.Key.StartsWith((sender as TextBox).Text))
                        listBoxFiltered.Items.Add(item.Key + " " + item.Value);
                    if (item.Value.ToUpper().StartsWith((sender as TextBox).Text.ToUpper()))
                        listBoxFiltered.Items.Add(item.Key + " " + item.Value);
                }
            }
        }
        #endregion




    }
}
