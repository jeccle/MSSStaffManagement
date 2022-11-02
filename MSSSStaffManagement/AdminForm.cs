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
        public AdminForm(string id, string name)    // [Q5.2]
        {
            InitializeComponent();
            FillTextBoxes(id, name);
        }

        bool confirmed;

        #region Control Methods
        // [Q5.4]
        /// <summary>
        /// Takes a key as an integer and checks if the key exists within the dictionary, the 
        /// value of the specified key is set to the contents of the Name textBox.
        /// </summary>
        /// <param name="key">Key to be Updated</param>
        private async void UpdateID(int key)
        {
            statusLabel.Text = "Press ENTER to confirm.";                       // Tooltips prompt user for input.
            toolTipAdmin.ToolTipTitle = "Update";                               
            toolTipAdmin.ToolTipIcon = ToolTipIcon.Warning;
            ShowToolTip("Update ID " + key + "?", textBoxPhoneAdmin, 20, 20);
            await ConfirmTask(this);                                            // Awaits 'enter' response.
            if (confirmed)
            {
                var dict = GeneralForm.MasterFile;
                if (dict.ContainsKey(key))
                {
                    dict[key] = textBoxNameAdmin.Text;  // Edits value
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
        // [Q5.5]
        /// <summary>
        /// Takes a key as an integer and checks if the key exists within the dictionary, the 
        /// specified KVP are then removed from the dictionary.
        /// Textboxes are cleared.
        /// </summary>
        /// <param name="key">Key to be Removed</param>
        private async void RemoveItem(int key)
        {
            statusLabel.Text = "Press ENTER to confirm.";                       // Tooltips prompt user for input.
            toolTipAdmin.ToolTipTitle = "Delete";
            toolTipAdmin.ToolTipIcon = ToolTipIcon.Warning;
            ShowToolTip("Remove ID?", textBoxPhoneAdmin, 20, 20);
            await ConfirmTask(this);                                            // Awaits 'enter' response.
            if (confirmed)
                if (GeneralForm.MasterFile.ContainsKey(key))
                {
                    GeneralForm.MasterFile.Remove(key); // Deletes value     
                    statusLabel.Text = "ID " + key + " removed.";
                    ClearTextBoxes();
                }
                else 
                {
                    MissingID();
                    ClearTextBoxes();
                }
            else
                statusLabel.Text = "Keeping ID & Value.";

        }
        // [Q5.3]
        /// <summary>
        /// Generates a new phoneID as a new entry using GenerateNewIDSimple().
        /// Awaits confirmation response from user and adds new Key value pairs to dictionary.
        /// Prompts user for text input if the name is empty.
        /// </summary>
        private async void CreateID()
        {
            if (textBoxPhoneAdmin.Text.Length != 9)
                textBoxPhoneAdmin.Text = GenerateNewIDSimple().ToString();
            if (!string.IsNullOrEmpty(textBoxNameAdmin.Text))
            {
                toolTipAdmin.ToolTipTitle = "Create ID";
                toolTipAdmin.ToolTipIcon = ToolTipIcon.Info;
                statusLabel.Text =  "Press ENTER to confirm.";
                ShowToolTip("Add new ID?", textBoxDetailsAdmin, 100, 20);
                await ConfirmTask(this);                                        // Awaits 'enter' response.
                if (confirmed)
                {
                    GeneralForm.MasterFile.Add(int.Parse(textBoxPhoneAdmin.Text), textBoxNameAdmin.Text);
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
                toolTipAdmin.ToolTipTitle = "Create New Staff ID Name";
                ShowToolTip("Enter name to create new staff ID.", textBoxNameAdmin, 20, 20);
                textBoxNameAdmin.Focus();
            }
        }
        #endregion

        #region Utility Methods
        /// <summary>
        ///  Generates an ID starting from the largest number, decrementing, then 
        ///  returns a key that is not within the dictionary.
        /// </summary>
        /// <returns>New Integer key</returns>
        private int GenerateNewIDSimple()
        {
            int newID = 770000000;
            while (GeneralForm.MasterFile.ContainsKey(newID))
                newID--;
            return newID;
        }
        /// <summary>
        /// Generates a new ID by stepping down from 7999, a pointer value keeps track of how 
        /// many times the current 4 digit ID appears within the dictionary. The interval is
        /// every 3 records (based on a pattern I saw within the data). Last 5 digits of the ID
        /// is randomly generated.
        /// This method has an already sorted setup in mind.
        /// </summary>
        /// <returns>New Integer key</returns>
        private int GenerateNewID()
        {   // For a sorted setup.
            int newID = 7999;
            int numInterval = 0;
            foreach (var item in GeneralForm.MasterFile)
            {
                if (numInterval == 3) 
                {   
                    newID--; 
                    numInterval = 0; 
                }
                if (item.Key.ToString().Substring(0, 4) == newID.ToString())
                    numInterval++;
                else
                {   // When the newID varible no longer matches existing key values.
                    var rand = new Random();
                    newID = int.Parse(newID.ToString() + rand.Next(10000, 99999).ToString());
                    break;
                }
            }
            if (GeneralForm.MasterFile.ContainsKey(newID))
                newID = GenerateNewID();
            return newID;
        }
        /// <summary>
        /// Generates a new ID by stepping down from 7999, a pointer value keeps track of how 
        /// many times the current 4 digit ID appears within the dictionary. The interval is
        /// every 3 records (based on a pattern I saw within the data). Last 5 digits of the ID
        /// is randomly generated.
        /// </summary>
        /// <returns>New Integer key</returns>
        private int GenerateNewIDUnsorted()
        {
            int newID = 7999;
            int numInterval = 0;
            foreach (var item in GeneralForm.MasterFile)
            {
                if (numInterval == 3)
                {   
                    newID--; 
                    numInterval = 0; 
                }
                if (item.Key.ToString().Substring(0, 4) == newID.ToString())
                    numInterval++;
            }
            var rand = new Random();
            newID = int.Parse(newID.ToString() + rand.Next(10000, 99999).ToString());
            if (GeneralForm.MasterFile.ContainsKey(newID))
                newID = GenerateNewIDUnsorted();
            return newID;
        }
        /// <summary>
        /// Creates an async task that awaits user input to set the confirmed boolean value.
        /// Takes an instance of a TaskCompletionSource, creates a localHandler that is then added
        /// to the form.KeyDown key event handler. Program then waits for input, when the task is complete
        /// the LocalHandler is removed from the key event handler.
        /// </summary>
        /// <param name="form">The form that is requesting confirmation.</param>
        /// <returns>Task</returns>
        private async Task ConfirmTask(Control form)
        {   // Makes a Task Completion Source that forces the application to wait for a keydown event.
            var tcs = new TaskCompletionSource<bool>();
            void LocalHandler(object s, KeyEventArgs a)     // Makes a local event handler method that takes a keypress and checks its value.
            {                                               // If the keypress is equal to 'ENTER' it will confirm the action within the form by changing the confirmed bool.
                if (a.KeyCode == Keys.Enter)
                    confirmed = true;
                else
                    confirmed = false;
                tcs.SetResult(true);
            }
            form.KeyDown += LocalHandler;                   // Adds the LocalHandler to the form.keyDown event handler.
            await tcs.Task;                                 // Awaits the completion of the task.
            form.KeyDown -= LocalHandler;                   // Removes the handler.
            
        }
        /// <summary>
        /// Clears both textboxes within admin form.
        /// </summary>
        private void ClearTextBoxes()
        {
            textBoxPhoneAdmin.Clear();
            textBoxNameAdmin.Clear();
        }
        /// <summary>
        /// Fills both text boxes with string values.
        /// </summary>
        /// <param name="id">String ID value</param>
        /// <param name="name">String Name value</param>
        public void FillTextBoxes(string id, string name)
        {
            textBoxPhoneAdmin.Text = id;
            textBoxNameAdmin.Text = name;
        }
        /// <summary>
        /// Shows a messages within a tooltip pointing toward a specific control, x and y parameters are used to 
        /// fine tune position of the tooltip.
        /// </summary>
        /// <param name="message">String message value</param>
        /// <param name="control">Control in focus</param>
        /// <param name="x">X-Axis value</param>
        /// <param name="y">Y-Axis value</param>
        public void ShowToolTip(string message, Control control, int x, int y)
        {
            toolTipAdmin.Show(message, control, x, y, 3500);
            toolTipAdmin.Show(message, control, x, y, 3500);
        }
        /// <summary>
        /// Indicates within a tooltip that an ID does not exist.
        /// </summary>
        private void MissingID()
        {
            toolTipAdmin.ToolTipTitle = "Error";
            toolTipAdmin.ToolTipIcon = ToolTipIcon.Error;
            ShowToolTip("ID doesn't exist.", textBoxPhoneAdmin, 20, 20);
        }
        #endregion

        #region Form Events
        // [Q5.7]
        /// <summary>
        /// KeyDown control scheme which uses a KeyDown event. 
        /// Method controls all functions within the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                Close();
            }
            if (e.Alt && e.KeyCode == Keys.L)   // [Q5.7]
                Close();

        }
        /// <summary>
        /// Sets the focus to the nameAdmin text box upon opening the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AdminForm_Load(object sender, EventArgs e)
        {
            textBoxNameAdmin.Enabled = true;
            textBoxNameAdmin.Focus();
        }
        /// <summary>
        /// Saves data to file upon closing.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AdminForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            GeneralForm.SaveData(@"MalinStaffNamesV2.csv");
        }
        /// <summary>
        /// Checks if inputted IDs are present within the dictionary, autofills Name when
        /// ID is found.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxPhoneAdmin.Text) && GeneralForm.MasterFile.ContainsKey(int.Parse(textBoxPhoneAdmin.Text)))
                textBoxNameAdmin.Text = GeneralForm.MasterFile[int.Parse(textBoxPhoneAdmin.Text)];
            textBoxDetailsAdmin.Text = textBoxPhoneAdmin.Text + " " + textBoxNameAdmin.Text;
        }
        /// <summary>
        /// When the sender leaves focus it is disabled.
        /// </summary>
        /// <param name="sender">TextBox control</param>
        /// <param name="e"></param>
        private void textBox_Leave(object sender, EventArgs e)
        {
            (sender as TextBox).Enabled = false;
        }
        /// <summary>
        /// Restricts keypress to values under 9 and only digits.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxPhoneAdmin_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = textBoxPhoneAdmin.Text.Length > 9 || !char.IsDigit(e.KeyChar);
        }
        /// <summary>
        /// Keypress values to restrict digits within the name box..
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxNameAdmin_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsDigit(e.KeyChar);
        }


        #endregion
    }
}
