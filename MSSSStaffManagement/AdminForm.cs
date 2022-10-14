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

        public void FillTextBoxes(string id, string name)
        {
            textBoxPhoneAdmin.Text = id;
            textBoxNameAdmin.Text = name;
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            textBoxUpdatedDetail.Text = textBoxPhoneAdmin.Text + " " + textBoxNameAdmin.Text;
        }
    }
}
