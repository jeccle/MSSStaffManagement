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
        public static Dictionary<int, string> MasterFile = new Dictionary<int, string>();
        public static Dictionary<int, string> backupDict;
        string path = @"MalinStaffNamesV2.csv";

        #region Global Methods
        /// <summary>
        /// Read content from a specified file path. Content is retrieved from a csv file and added to a global dictionary data structure.
        /// </summary>
        /// <param name="path">Path to data file.</param>
        /// <returns>Returns string value describing process outcome</returns>
        public static string ReadFile(string path)
        {
            try
            {
                using (var reader = new StreamReader(File.Open(path, FileMode.Open), Encoding.UTF8, false))
                {
                    Trace.TraceInformation("Loading from " + path);
                    while (!reader.EndOfStream)                                                                          
                    {
                        string[] items = reader.ReadLine().Split(',');
                        MasterFile.Add(int.Parse(items[0]), items[1]);
                    }
                    backupDict = new Dictionary<int, string>(MasterFile);
                    return "Staff List Loaded.";
                }
            }
            catch (ArgumentException)
            {
                return "Values already exist within list.";
            }
        }
        /// <summary>
        /// Saves data to specified path. Data is written to file using streamwriter.
        /// </summary>
        /// <param name="path">File Path</param>
        public static void SaveData(string path)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(File.Open(path, FileMode.Open), Encoding.UTF8))       
                {
                    foreach (var item in MasterFile)
                        writer.WriteLine(item.Key + "," + item.Value);
                }
                Trace.TraceInformation("Saved to file. Path: " + path + "\n");
            }
            catch
            {
                Trace.TraceInformation("Error occurred during saving");
            }
        }
        /// <summary>
        /// Sets current data structure values.
        /// </summary>
        /// <param name="dict">Dictionary to replace current data.</param>
        public static void SetDictionary(Dictionary<int, string> dict)
        {
            MasterFile = dict;
        }
        #endregion

        #region Utility Methods     
        /// <summary>
        /// Displays selected value in textBoxes.
        /// </summary>
        /// <param name="item">Item to be displayed.</param>
        private void DisplayTextBox(string item)
        {
            string[] kvp = item.Split(new char[] { ' ' }, 2);
            textBoxPhone.Text = kvp[0];
            textBoxName.Text = kvp[1];
            statusLabel.Text = item + " selected.";
        }
        /// <summary>
        /// Displays all items within MasterFile to specified listBox.
        /// </summary>
        /// <param name="listBox">Specified listBox to display items.</param>
        private void DisplayItems(ListBox listBox)
        {
            listBox.Items.Clear();
            foreach (var item in MasterFile)
            {
                listBox.Items.Add(item.Key + " " + item.Value);
            }
        }
        /// <summary>
        /// Outputs tooltip in a bubble form pointingn upwards.
        /// </summary>
        /// <param name="message">String caption to display on tooltip</param>
        /// <param name="control">Associated control involved with process.</param>
        /// <param name="x">X-Axis value</param>
        /// <param name="y">Y-Axis value</param>
        public void ShowToolTip(string message, Control control, int x, int y)
        {
            toolTipGen.Show(message, control, x, y, 3500);
            toolTipGen.Show(message, control, x, y, 3500);
        }
        /// <summary>
        /// Sets textbox properties ReadOnly & Enable to appropriate bool values to enable textBox input.
        /// </summary>
        /// <param name="textBox">TextBox control in focus</param>
        private void FocusTextBox(TextBox textBox)
        {
            textBox.ReadOnly = false;
            textBox.Enabled = true;
            textBox.Focus();
        }
        #endregion

        #region Form Event/Controls
        /// <summary>
        /// Keydown event handler that acts as the control hub for the application.
        /// Responds to all user input and prompts allication behaviour to match specified key bindings.
        /// </summary>
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
            {   // Exit Form.
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
        /// <summary>
        /// On load sets trace listeners and reads from file. Displays items in textboxes after reading from file and outputting
        /// a file read status message.
        /// </summary>
        private void GerneralForm_Load(object sender, EventArgs e)
        {   // Change ReadFile method here.
            Trace.Listeners.Add(new TextWriterTraceListener("TraceLog.txt", "myListener"));
            Trace.Write("\n");
            statusLabel.Text = ReadFile(path);
            DisplayItems(listBoxRead);
        }
        /// <summary>
        /// Checks textboxes for input, when there is input it is matched against each value
        /// within MasterFile and if the values match they are displayed in a filtered listBox.
        /// </summary>
        private void textBox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty((sender as TextBox).Text))
            {
                listBoxFiltered.Items.Clear();
                // #1
                //foreach (var item in MasterFile)
                //{
                //    if (item.Key.ToString().StartsWith((sender as TextBox).Text))
                //        listBoxFiltered.Items.Add(item.Key + " " + item.Value);
                //    if (item.Value.ToUpper().StartsWith((sender as TextBox).Text.ToUpper()))
                //        listBoxFiltered.Items.Add(item.Key + " " + item.Value);
                //}

                // #2
                switch ((sender as TextBox).Name)
                {
                    case "textBoxPhone":
                        foreach (var item in MasterFile.Where(kvp => kvp.Key.ToString().StartsWith(textBoxPhone.Text)))
                            listBoxFiltered.Items.Add(item.Key + " " + item.Value);
                        break;

                    case "textBoxName":
                        foreach (var item in MasterFile.Where(kvp => kvp.Value.ToUpper().StartsWith(textBoxName.Text.ToUpper())))
                            listBoxFiltered.Items.Add(item.Key + " " + item.Value);
                        break;
                    default:
                        break;
                }
            }
        }
        /// <summary>
        /// Sets textBoxes to disabled when focus is left.
        /// </summary>
        private void textBox_Leave(object sender, EventArgs e)
        {
            (sender as TextBox).Enabled = false;
        }
        /// <summary>
        /// When form is first shown appropriate tooltip and focus is enabled.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GeneralForm_Shown(object sender, EventArgs e)
        {
            FocusTextBox(textBoxName);
            ShowToolTip("Enter Phone ID to search.", textBoxPhone, 20, 20);
        }
        private void textBoxPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = textBoxPhone.Text.Length > 9 || !char.IsDigit(e.KeyChar);
        }
        private void textBoxName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsDigit(e.KeyChar);
        }

        #endregion


    }
}

