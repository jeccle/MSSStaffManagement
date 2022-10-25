﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
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
        public static Dictionary<int, string> backupDict = MasterFile;
        string path = @"MalinStaffNamesV2.csv";

        #region Global Methods

            #region Read File Methods
        public static string ReadFileDefault(string path)
        {
            try
            {
                var sw = Stopwatch.StartNew();
                using (var reader = new StreamReader(File.OpenRead(path), Encoding.UTF8, false))
                { 
                    Trace.TraceInformation("Loading from " + path);
                    while (!reader.EndOfStream)
                    {
                        string[] items = reader.ReadLine().Split(',');
                        MasterFile.Add(int.Parse(items[0]), items[1]);
                    }
                    sw.Stop();                                           
                    Trace.TraceInformation(sw.ElapsedTicks + " ticks | ReadFileDefault() Dictionary");
                    return "Staff List Loaded.";
                }
            }
            catch (ArgumentException)
            {
                return "Values already exist within list.";
            }
        }
        public static string ReadFileSROpenText(string path)
        {
            try
            {
                string[] items;
                var sw = Stopwatch.StartNew();
                using (StreamReader sr = File.OpenText(path))
                { 
                    Trace.TraceInformation("Loading from " + path);
                    while (!sr.EndOfStream)
                    {
                        items = sr.ReadLine().Split(',');
                        MasterFile.Add(int.Parse(items[0]), items[1]);
                    }
                    sw.Stop(); Trace.TraceInformation(sw.ElapsedTicks + " ticks | ReadFileSROpenText() Dictionary");
                    return "Staff List Loaded.";
                }
                
            }
            catch (ArgumentException)
            {
                return "Values already exist within list.";
            }
        }
        public static string ReadFileReadAllLines(string path)
        {
            try
            { Trace.TraceInformation("Loading from " + path);
                var sw = Stopwatch.StartNew();
                var allLines = File.ReadAllLines(path);
                foreach (var line in allLines)
                {
                    string[] items = line.Split(',');
                    MasterFile.Add(int.Parse(items[0]), items[1]);
                }
                sw.Stop();                                       Trace.TraceInformation(sw.ElapsedTicks + " ticks | ReadFileReadAllLines() Dictionary");
                return "Staff List Loaded.";
            }
            catch (ArgumentException)
            {
                return "Values already exist within list.";
            }
        }
        public static string ReadFileSROpenReadReadLine(string path)
        {
            try
            {
                Trace.TraceInformation("Loading from " + path);
                var sw = Stopwatch.StartNew();
                using (StreamReader sr = new StreamReader(File.OpenRead(path)))
                {
                    while(!sr.EndOfStream)
                    {
                        string[] items = sr.ReadLine().Split(',');
                        MasterFile.Add(int.Parse(items[0]), items[1]);
                    }
                    sw.Stop(); Trace.TraceInformation(sw.ElapsedTicks + " ticks | ReadFileSROpenReadReadLine() Dictionary");
                    return "Staff List Loaded.";
                }
                
            }
            catch (ArgumentException)
            {
                return "Values already exist within list.";
            }
        }
        public static string ReadFileTROpenText(string path)
        {
            try
            {
                Trace.TraceInformation("Loading from " + path);
                var sw = Stopwatch.StartNew();
                using (TextReader tr = File.OpenText(path))
                {
                    while (tr.ReadLine() != null)
                    {
                        string[] items = tr.ReadLine().Split(',');
                        MasterFile.Add(int.Parse(items[0]), items[1]);
                    }
                    sw.Stop(); Trace.TraceInformation(sw.ElapsedTicks + " ticks | ReadFileTROpenText() Dictionary");
                    return "Staff List Loaded.";
                }
               
            }
            catch (ArgumentException)
            {
                return "Values already exist within list.";
            }
        }
        #endregion
        #region SaveData Methods
        public static void SaveDataDefault(string path)
        {
            try
            {
                var sw = Stopwatch.StartNew(); 
                using (StreamWriter writer = new StreamWriter(File.Open(path, FileMode.Open), Encoding.UTF8))
                {
                    foreach (var item in MasterFile)
                        writer.WriteLine(item.Key + "," + item.Value);
                }
                sw.Stop();                                                                                  Trace.TraceInformation(sw.ElapsedTicks + " ticks | SaveDataDefault() Dictionary");
                Trace.TraceInformation("Saved to file. Path: " + path + "\n");
            }
            catch
            {
                Trace.TraceInformation("Error occurred during saving");
            }
        }
        public static void SaveDataStringBuilder(string path)
        {
            try
            {
                var sw = Stopwatch.StartNew();
                var csv = new StringBuilder();
                using (StreamWriter writer = new StreamWriter(File.Open(path, FileMode.Open), Encoding.UTF8))
                {
                    foreach (var item in MasterFile)
                        csv.AppendLine(item.Key + "," + item.Value);
                    writer.Write(csv.ToString());
                }
                sw.Stop(); 
                Trace.TraceInformation(sw.ElapsedTicks + " ticks | SaveDataStringBuilder() Dictionary");
                Trace.TraceInformation("Saved to file. Path: " + path + "\n");
            }
            catch
            {
                Trace.TraceInformation("Error occurred during saving");
            }
        }
        public static void SaveDataSBNoStreamWriter(string path)
        {
            try
            {
                var sw = Stopwatch.StartNew();

                var csv = new StringBuilder();
                foreach (var item in MasterFile)
                    csv.AppendLine(item.Key + "," + item.Value);
                File.AppendAllText(path, csv.ToString());
                
                sw.Stop(); 
                Trace.TraceInformation(sw.ElapsedTicks + " ticks | SaveDataSBNoStreamWriter() Dictionary");
                Trace.TraceInformation("Saved to file. Path: " + path + "\n");
            }
            catch
            {
                Trace.TraceInformation("Error occurred during saving");
            }
        }
        #endregion
        public static void SetDictionary(Dictionary<int, string> dict)
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
            toolTipGen.Show(message, control, x, y, 5000);
            toolTipGen.Show(message, control, x, y, 5000);
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
            Trace.Write("\n");
            statusLabel.Text = ReadFileDefault(path);
            DisplayItems(listBoxRead);
        }
        private void GeneralForm_Shown(object sender, EventArgs e)
        {
            FocusTextBox(textBoxName);
            ShowToolTip("Enter Phone ID to search.", textBoxPhone, 20, 20);
            RunAllTests();
        }
        private void textBox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty((sender as TextBox).Text))
            {
                listBoxFiltered.Items.Clear();
                var sw = Stopwatch.StartNew();
                //foreach (var item in MasterFile)
                //{
                //    if (item.Key.ToString().StartsWith((sender as TextBox).Text))
                //        listBoxFiltered.Items.Add(item.Key + " " + item.Value);
                //    if (item.Value.ToUpper().StartsWith((sender as TextBox).Text.ToUpper()))
                //        listBoxFiltered.Items.Add(item.Key + " " + item.Value);
                //}
                //sw.Stop(); Trace.TraceInformation(sw.ElapsedTicks + " ticks | #1 Foreach List Filter");

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
                sw.Stop(); Trace.TraceInformation(sw.ElapsedTicks + " ticks | #2 Switch List Filter");
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

        #region Form Test
        private async void RunAllTests()
        {
            await OpenAdminForm();
            await AddID("testOne");
            await UpdateID(770000000, "testUser");
            await DeleteID(770000000);
            CloseForm();
            CloseForm();
        }
        private Task OpenAdminForm()
        {   // Remove comments if the program is not being focused.
            //SendKeys.SendWait("%+{TAB}");
            SendKeys.Send("%+{A}");
            return Task.CompletedTask;
        }
        private Task AddID(string name)
        {
            SendKeys.Send("%+{F}");
            SendKeys.Send(name);
            SendKeys.Send("%+{F}");
            SendKeys.Send("{ENTER}");
            return Task.CompletedTask;
        }
        private Task DeleteID(int ID)
        {
            SendKeys.Send("%+{C}");
            SendKeys.Send(ID.ToString());
            SendKeys.Send("%+{S}");
            SendKeys.Send("{ENTER}");
            return Task.CompletedTask;
        }
        private Task UpdateID(int ID, string newName)
        {
            SendKeys.Send("%+{C}");
            SendKeys.Send(ID.ToString());
            SendKeys.Send("%+{X}");
            SendKeys.Send(newName);
            SendKeys.Send("%+{V}");
            SendKeys.Send("{ENTER}");
            return Task.CompletedTask;
        }
        private void CloseForm()
        {
            SendKeys.Send("%+{L}");
        }
        #endregion


    }
}

