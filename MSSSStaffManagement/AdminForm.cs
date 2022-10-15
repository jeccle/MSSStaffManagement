using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        private async void UpdateID(string key)
        {
            confirmed = false;
            statusLabel.Text = "Update ID " + key + "? Enter to Confirm";
            await ConfirmTask(this);
            if (confirmed)
            {
                var dict = GeneralForm.GetDictionary();
                if (dict.ContainsKey(key))
                {
                    dict[key] = textBoxNameAdmin.Text;
                    statusLabel.Text = "ID " + key + " Name Updated to " + textBoxNameAdmin.Text;
                }
            }
            else
                statusLabel.Text = "ID not updated.";
        }
        private async void RemoveItem(string key)
        {
            confirmed = false;
            statusLabel.Text = "Remove Specified Data? Enter to Confirm";
            await ConfirmTask(this);
            if (confirmed)
                if (GeneralForm.GetDictionary().ContainsKey(key))
                {
                    GeneralForm.GetDictionary().Remove(key);
                    statusLabel.Text = "ID " + key + " removed.";
                    ClearTextBoxes();
                    
                }
                else
                    statusLabel.Text = "ID doesn't exist.";
            else
                statusLabel.Text = "Keeping ID & Value.";

        }
        private async void CreateID()
        {
            if (!string.IsNullOrEmpty(textBoxNameAdmin.Text))
            {
                textBoxPhoneAdmin.Text = GenerateNewIDUnsorted().ToString();
                confirmed = false;
                statusLabel.Text = "Add " + textBoxPhoneAdmin.Text + " " + textBoxNameAdmin.Text + "? Enter to Confirm";
                await ConfirmTask(this);
                if (confirmed)
                {
                    GeneralForm.GetDictionary().Add(textBoxPhoneAdmin.Text, textBoxNameAdmin.Text);
                    statusLabel.Text = textBoxPhoneAdmin.Text + " " + textBoxNameAdmin.Text + " added to List.";
                    ClearTextBoxes();
                }
                else
                {
                    ClearTextBoxes();
                    statusLabel.Text = "New ID canceled.";
                }
            }
            else
            {
                toolTipAdmin.ToolTipTitle = "Create New Staff ID";
                toolTipAdmin.Show("Enter name to create new staff ID.", textBoxNameAdmin);
                textBoxNameAdmin.Focus();
            }
        }
        #endregion

        #region Utility Methods
        private int GenerateNewID()
        {   // For a sorted setup.
            int newID = 79999;
            int numInterval = 0;
            foreach (var item in GeneralForm.GetDictionary())
            {
                if (numInterval == 3) 
                {   newID--; numInterval = 0; }
                if (item.Key.Substring(0, 5) == newID.ToString())
                    numInterval++;
                else
                {
                    var rand = new Random();
                    newID = int.Parse(newID.ToString() + rand.Next(1000, 9999).ToString());
                    break;
                }
            }
            return newID;
        }
        private int GenerateNewIDUnsorted()
        {
            int newID = 79999;
            int numInterval = 0;
            foreach (var item in GeneralForm.GetDictionary())
            {
                if (numInterval == 3)
                { newID--; numInterval = 0; }
                if (item.Key.Substring(0, 5) == newID.ToString())
                    numInterval++;
            }
            var rand = new Random();
            newID = int.Parse(newID.ToString() + rand.Next(1000, 9999).ToString());
            return newID;
        }
        private async Task ConfirmTask(Control form)
        {   // Makes a Task Completion Source that forces the application to wait for a keydown event.
            var tcs = new TaskCompletionSource<bool>();
            async void LocalHandler(object s, KeyEventArgs a)
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
        #endregion

        #region Form Events
        private void AdminForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.X)
            {   // Sets focus to Name Box.
                textBoxNameAdmin.Focus();
            }
            if (e.Alt && e.KeyCode == Keys.C)
            {   // Sets focus to Phone ID Box.                
                textBoxPhoneAdmin.Focus();
            }
            if (e.Alt && e.KeyCode == Keys.F)
            {   // Creates new staff ID.
                CreateID();
            }
            if (e.Alt && e.KeyCode == Keys.S)
            {   // Removes item from dictionary.
                RemoveItem(textBoxPhoneAdmin.Text);
            }
            if (e.Alt && e.KeyCode == Keys.V)
            {   // Updates ID record.
                UpdateID(textBoxPhoneAdmin.Text);
            }
            if (e.Alt && e.KeyCode == Keys.T)
            {
                statusLabel.Text = "Rolling back.";
                GeneralForm.SetDictionary(GeneralForm.backupDict);
            }
            if (e.Alt && e.KeyCode == Keys.G)
                this.Close();

        }
        private void AdminForm_Load(object sender, EventArgs e)
        {   // Somehow accomodate rollback
            textBoxNameAdmin.Focus();
        }
        private void textBox_TextChanged(object sender, EventArgs e)
        {
            switch ((sender as TextBox).Name)
            {
                case "textBoxPhoneAdmin":
                    if (GeneralForm.GetDictionary().ContainsKey(textBoxPhoneAdmin.Text))
                        textBoxNameAdmin.Text = GeneralForm.GetDictionary()[textBoxPhoneAdmin.Text];
                    break;
                case "textBoxNameAdmin":
                    if (GeneralForm.GetDictionary().ContainsKey(textBoxNameAdmin.Text))
                        textBoxPhoneAdmin.Text = GeneralForm.GetDictionary()[textBoxNameAdmin.Text];
                    break;
            }
            textBoxUpdatedDetail.Text = textBoxPhoneAdmin.Text + " " + textBoxNameAdmin.Text;
        }
        #endregion
    }
}
