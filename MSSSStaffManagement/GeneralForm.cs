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
        public static string ReadFile(string path)
        {
            try
            {
                var sw = new Stopwatch();
                sw.Start();
                using (var reader = new StreamReader(File.Open(path, FileMode.Open), Encoding.UTF8, false))
                {
                    Trace.TraceInformation("Loading from " + path);
                    while (!reader.EndOfStream)
                    {
                        string[] items = reader.ReadLine().Split(',');
                        MasterFile.Add(items[0], items[1]);
                    }
                    sw.Stop();
                    Trace.TraceInformation(sw.ElapsedTicks + " ticks | Dictionary ReadFile()");
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
        public static void SaveData(string path)
        {
            try
            {
                var sw = new Stopwatch();
                Trace.TraceInformation("Stopwatch start.");
                sw.Start();
                using (StreamWriter writer = new StreamWriter(File.Open(path, FileMode.Open), Encoding.UTF8))
                {
                    foreach (var item in MasterFile)
                        writer.WriteLine(item.Key + "," + item.Value);
                }
                sw.Stop();
                Trace.TraceInformation(sw.ElapsedMilliseconds + "ms | Dictionary SaveData()");
                Trace.TraceInformation("Saved to file. Path: " + path);
            }
            catch
            {
                Trace.TraceInformation("Error occurred during saving");
            }
        }
        public static void SetDictionary(Dictionary<string, string> dict)
        {
            MasterFile = dict;
        }
        #endregion

        #region Utility Methods     
        private void DisplayTextBox(string item)
        {
            string[] kvp = item.Split(new char[] { ' ' }, 2);
            textBoxPhone.Text = kvp[0];
            textBoxName.Text = kvp[1];
            statusLabel.Text = item + " selected.";
        }
        private void DisplayItems(ListBox listBox)
        {
            listBox.Items.Clear();
            foreach (var item in MasterFile)
            {
                listBox.Items.Add(item.Key + " " + item.Value);
            }
        }
        public void ShowToolTip(string message, Control control, int x, int y)
        {
            toolTipGen.Show(message, control, x, y, 3500);
            toolTipGen.Show(message, control, x, y, 3500);
        }
        private void FocusTextBox(TextBox textBox)
        {
            textBox.ReadOnly = false;
            textBox.Enabled = true;
            textBox.Focus();

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
                    adminForm.ShowDialog();
                    DisplayItems(listBoxRead);
                    statusLabel.Text = "List has been updated.";
                    listBoxFiltered.Items.Clear();
                }
            }
            if (e.Alt && e.KeyCode == Keys.X)
            {   // Sets focus to Name Box.
                textBoxPhone.Clear();
                textBoxName.Clear();
                FocusTextBox(textBoxName);    
                toolTipGen.ToolTipTitle = "Filter Name";
                ShowToolTip("Enter Name to search.", textBoxName, 20, 17);
            }
            if (e.Alt && e.KeyCode == Keys.C)
            {   // Sets focus to Phone Box.
                textBoxName.Clear();
                FocusTextBox(textBoxPhone);
                toolTipGen.ToolTipTitle = "Filter Phone ID";
                ShowToolTip("Enter Phone ID to search.", textBoxPhone, 20, 17);
            }
            if (e.Alt && e.KeyCode == Keys.L)
            {   // Exit.
                Trace.Flush();
                Close();
            }
            if (e.KeyCode == Keys.Right)
            {   // Move focus to listBoxFiltered first record.
                listBoxFiltered.SelectionMode = SelectionMode.One;
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
        {   // Change ReadFile method here.
            Trace.Listeners.Add(new TextWriterTraceListener("TraceLog.txt", "myListener"));
            statusLabel.Text = ReadFile(path);
            DisplayItems(listBoxRead);
            textBoxPhone.Focus();
            toolTipGen.Show("Enter Phone ID to search.", textBoxPhone, 2000);

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
        private void listBoxFiltered_MouseClick(object sender, MouseEventArgs e)
        {
            (sender as ListBox).SelectionMode = SelectionMode.None;
        }
        private void textBox_Leave(object sender, EventArgs e)
        {
            (sender as TextBox).Enabled = false;
        }



        #endregion



    }
}

