﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSSSStaffManagement
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }
        public AdminForm(string id, string name)
        {
            InitializeComponent();
            FillTextBoxes(id, name);
        }

        bool confirmed;

        #region Control Methods
        private async void UpdateID(int key)
        {
            //confirmed = false;
            statusLabel.Text = "Press ENTER to confirm.";
            toolTipAdmin.ToolTipTitle = "Update";
            toolTipAdmin.ToolTipIcon = ToolTipIcon.Warning;
            ShowToolTip("Update ID " + key + "?", textBoxPhoneAdmin, 20, 20);
            await ConfirmTask(this);
            if (confirmed)
            {
                var sw = Stopwatch.StartNew();
                var dict = GeneralForm.MasterFile;
                if (dict.ContainsKey(key))
                {
                    dict[key] = textBoxNameAdmin.Text;
                    sw.Stop();
                    Trace.TraceInformation(sw.ElapsedTicks + " Ticks | UpdateID() Dictionary");
                    statusLabel.Text = "ID " + key + " Name Updated to " + textBoxNameAdmin.Text;
                }
                else
                {
                    MissingID();
                    ClearTextBoxes();
                }
            }
            else
                statusLabel.Text = "ID Name not updated.";
        }
        private async void RemoveItem(int key)
        {
            //confirmed = false;
            statusLabel.Text = "Press ENTER to confirm.";
            toolTipAdmin.ToolTipTitle = "Delete";
            toolTipAdmin.ToolTipIcon = ToolTipIcon.Warning;
            ShowToolTip("Remove ID?", textBoxPhoneAdmin, 20, 20);
            await ConfirmTask(this);
            if (confirmed)
                if (GeneralForm.MasterFile.ContainsKey(key))
                {
                    var sw = Stopwatch.StartNew();
                    GeneralForm.MasterFile.Remove(key);
                    statusLabel.Text = "ID " + key + " removed.";
                    ClearTextBoxes();
                    sw.Stop();
                    Trace.TraceInformation(sw.ElapsedTicks + " Ticks | RemoveItem() Dictionary");
                }
                else 
                {
                    MissingID();
                    ClearTextBoxes();
                }
            else
                statusLabel.Text = "Keeping ID & Value.";

        }
        private async void CreateID()
        {
            Stopwatch sw = new Stopwatch();
            if (textBoxPhoneAdmin.Text.Length != 9)
            {
                sw.Restart();
                textBoxPhoneAdmin.Text = GenerateNewIDSimple().ToString();
                sw.Stop();
                Trace.TraceInformation(sw.ElapsedTicks + " ticks | GenerateIDSimple() Dictionary");
            }
            if (!string.IsNullOrEmpty(textBoxNameAdmin.Text))
            {
                //confirmed = false;
                toolTipAdmin.ToolTipTitle = "Create ID";
                toolTipAdmin.ToolTipIcon = ToolTipIcon.Info;
                statusLabel.Text = "Press ENTER to confirm.";
                ShowToolTip("Add new ID?", textBoxDetailsAdmin, 100, 20);
                await ConfirmTask(this);
                if (confirmed)
                {
                    sw.Restart();
                    GeneralForm.MasterFile.Add(int.Parse(textBoxPhoneAdmin.Text), textBoxNameAdmin.Text);
                    statusLabel.Text = textBoxPhoneAdmin.Text + " " + textBoxNameAdmin.Text + " added to List.";
                    ClearTextBoxes();
                    sw.Stop();
                    Trace.TraceInformation(sw.ElapsedTicks + " ticks. | CreateID() Dictionary");
                }
                else
                {
                    ClearTextBoxes();
                    statusLabel.Text = "New ID canceled.";
                }
            }
            else
            {
                toolTipAdmin.ToolTipTitle = "Create New Staff ID Name";
                ShowToolTip("Enter name to create new staff ID.", textBoxNameAdmin, 20, 20);
                textBoxNameAdmin.Focus();
            }
        }
        #endregion

        #region Utility Methods
        private int GenerateNewIDSimple()
        {
            int newID = 770000000;
            while (GeneralForm.MasterFile.ContainsKey(newID))
                newID--;
            return newID;
        }
        private int GenerateNewID()
        {   // For a sorted setup.
            int newID = 7999;
            int numInterval = 0;
            foreach (var item in GeneralForm.MasterFile)
            {
                if (numInterval == 3) 
                {   newID--; numInterval = 0; }
                if (item.Key.ToString().Substring(0, 4) == newID.ToString())
                    numInterval++;
                else
                {
                    var rand = new Random();
                    newID = int.Parse(newID.ToString() + rand.Next(10000, 99999).ToString());
                    break;
                }
            }
            if (GeneralForm.MasterFile.ContainsKey(newID))
                newID = GenerateNewID();
            return newID;
        }
        private int GenerateNewIDUnsorted()
        {
            int newID = 7999;
            int numInterval = 0;
            foreach (var item in GeneralForm.MasterFile)
            {
                if (numInterval == 3)
                { newID--; numInterval = 0; }
                if (item.Key.ToString().Substring(0, 4) == newID.ToString())
                    numInterval++;
            }
            var rand = new Random();
            newID = int.Parse(newID.ToString() + rand.Next(10000, 99999).ToString());
            if (GeneralForm.MasterFile.ContainsKey(newID))
                newID = GenerateNewIDUnsorted();
            return newID;
        }
        private async Task ConfirmTask(Control form)
        {   // Makes a Task Completion Source that forces the application to wait for a keydown event.
            var tcs = new TaskCompletionSource<bool>();
            void LocalHandler(object s, KeyEventArgs a)
            {
                if (a.KeyCode == Keys.Enter)
                    confirmed = true;
                else
                    confirmed = false;
                tcs.SetResult(true);
            }
            form.KeyDown += LocalHandler;
            await tcs.Task;
            form.KeyDown -= LocalHandler;
            
        }
        private void ClearTextBoxes()
        {
            textBoxPhoneAdmin.Clear();
            textBoxNameAdmin.Clear();
        }
        public void FillTextBoxes(string id, string name)
        {
            textBoxPhoneAdmin.Text = id;
            textBoxNameAdmin.Text = name;
        }
        public void ShowToolTip(string message, Control control, int x, int y)
        {
            toolTipAdmin.Show(message, control, x, y, 5000);
            toolTipAdmin.Show(message, control, x, y, 5000);
        }
        private void MissingID()
        {
            toolTipAdmin.ToolTipTitle = "Error";
            toolTipAdmin.ToolTipIcon = ToolTipIcon.Error;
            ShowToolTip("ID doesn't exist.", textBoxPhoneAdmin, 20, 20);
        }
        #endregion

        #region Form Events
        private void AdminForm_KeyDown(object sender, KeyEventArgs e)
        {
            confirmed = false;
            if (e.Alt && e.KeyCode == Keys.X)
            {   // Sets focus to Name Box.
                textBoxNameAdmin.Enabled = true;
                textBoxNameAdmin.Focus();
            }
            if (e.Alt && e.KeyCode == Keys.C)
            {   // Sets focus to Phone ID Box.
                ClearTextBoxes();
                toolTipAdmin.ToolTipTitle = "Search ID";
                ShowToolTip("Enter full ID to match existing ID.", textBoxPhoneAdmin, 20, 20);
                textBoxPhoneAdmin.Enabled = true;
                textBoxPhoneAdmin.Focus();
                
            }
            if (e.Alt && e.KeyCode == Keys.F)
            {   // Creates new staff ID.
                textBoxNameAdmin.Enabled = true;
                CreateID();
            }
            if (e.Alt && e.KeyCode == Keys.S)
            {   // Removes item from dictionary.
                if (!string.IsNullOrEmpty(textBoxPhoneAdmin.Text))
                    RemoveItem(int.Parse(textBoxPhoneAdmin.Text));
                else
                {
                    toolTipAdmin.ToolTipTitle = "Missing ID Input!";
                    ShowToolTip("No ID to remove.", textBoxPhoneAdmin, 20, 20);
                }
            }
            if (e.Alt && e.KeyCode == Keys.V)
            {   // Updates ID record.
                if (!string.IsNullOrEmpty(textBoxPhoneAdmin.Text))
                    UpdateID(int.Parse(textBoxPhoneAdmin.Text));
                else
                {
                    toolTipAdmin.ToolTipTitle = "Missing ID Input!";
                    ShowToolTip("No ID to update.", textBoxPhoneAdmin, 20, 20);
                }
            }
            if (e.Alt && e.KeyCode == Keys.T)
            {
                statusLabel.Text = "Rolling back.";
                toolTipAdmin.ToolTipTitle = "Data Rollback";
                ShowToolTip("Rolled Back to Launch State", groupBoxKeyBinds, 80, 100);
                GeneralForm.SetDictionary(GeneralForm.backupDict);
            }
            if (e.Alt && e.KeyCode == Keys.L)
                Close();

        }
        private void AdminForm_Load(object sender, EventArgs e)
        {   // Somehow accomodate rollback
            textBoxNameAdmin.Enabled = true;
            textBoxNameAdmin.Focus();
        }
        private void AdminForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            GeneralForm.SaveDataSBNoStreamWriter(@"MalinStaffNamesV2.csv");
        }
        private void textBox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxPhoneAdmin.Text) && GeneralForm.MasterFile.ContainsKey(int.Parse(textBoxPhoneAdmin.Text)))
                textBoxNameAdmin.Text = GeneralForm.MasterFile[int.Parse(textBoxPhoneAdmin.Text)];
            textBoxDetailsAdmin.Text = textBoxPhoneAdmin.Text + " " + textBoxNameAdmin.Text;
        }
        private void textBox_Leave(object sender, EventArgs e)
        {
            (sender as TextBox).Enabled = false;
        }



        #endregion



    }
}
