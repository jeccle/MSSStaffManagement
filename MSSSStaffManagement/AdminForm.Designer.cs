﻿namespace MSSSStaffManagement
{
    partial class AdminForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.textBoxKeyBinds = new System.Windows.Forms.TextBox();
            this.groupBoxKeyBinds = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxUpdatedDetail = new System.Windows.Forms.TextBox();
            this.textBoxNameAdmin = new System.Windows.Forms.TextBox();
            this.textBoxPhoneAdmin = new System.Windows.Forms.TextBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTipAdmin = new System.Windows.Forms.ToolTip(this.components);
            this.groupBoxKeyBinds.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxKeyBinds
            // 
            this.textBoxKeyBinds.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxKeyBinds.Location = new System.Drawing.Point(27, 16);
            this.textBoxKeyBinds.Multiline = true;
            this.textBoxKeyBinds.Name = "textBoxKeyBinds";
            this.textBoxKeyBinds.ReadOnly = true;
            this.textBoxKeyBinds.Size = new System.Drawing.Size(180, 109);
            this.textBoxKeyBinds.TabIndex = 10;
            this.textBoxKeyBinds.TabStop = false;
            this.textBoxKeyBinds.Text = "Alt+C » Navigate to Phone ID\r\nAlt+X » Navigate to Name\r\nAlt+F » Create New Staff " +
    "ID\r\nAlt+V » Update Name\r\nAlt+S » Delete ID\r\nAlt+T » Rollback Staff List\r\nAlt+L »" +
    " Exit\r\nEnter » Confirm Changes";
            this.textBoxKeyBinds.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBox_MouseClick);
            // 
            // groupBoxKeyBinds
            // 
            this.groupBoxKeyBinds.Controls.Add(this.textBoxKeyBinds);
            this.groupBoxKeyBinds.Location = new System.Drawing.Point(11, 142);
            this.groupBoxKeyBinds.Name = "groupBoxKeyBinds";
            this.groupBoxKeyBinds.Size = new System.Drawing.Size(232, 131);
            this.groupBoxKeyBinds.TabIndex = 1;
            this.groupBoxKeyBinds.TabStop = false;
            this.groupBoxKeyBinds.Text = "Key Bindings";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.textBoxUpdatedDetail);
            this.groupBox2.Controls.Add(this.textBoxNameAdmin);
            this.groupBox2.Controls.Add(this.textBoxPhoneAdmin);
            this.groupBox2.Location = new System.Drawing.Point(11, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(232, 123);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Staff ID Admin Form";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Phone ID";
            // 
            // textBoxUpdatedDetail
            // 
            this.textBoxUpdatedDetail.Location = new System.Drawing.Point(18, 88);
            this.textBoxUpdatedDetail.Name = "textBoxUpdatedDetail";
            this.textBoxUpdatedDetail.ReadOnly = true;
            this.textBoxUpdatedDetail.Size = new System.Drawing.Size(199, 20);
            this.textBoxUpdatedDetail.TabIndex = 2;
            // 
            // textBoxNameAdmin
            // 
            this.textBoxNameAdmin.Location = new System.Drawing.Point(69, 54);
            this.textBoxNameAdmin.Name = "textBoxNameAdmin";
            this.textBoxNameAdmin.Size = new System.Drawing.Size(148, 20);
            this.textBoxNameAdmin.TabIndex = 0;
            this.textBoxNameAdmin.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBox_MouseClick);
            this.textBoxNameAdmin.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // textBoxPhoneAdmin
            // 
            this.textBoxPhoneAdmin.Location = new System.Drawing.Point(69, 28);
            this.textBoxPhoneAdmin.Name = "textBoxPhoneAdmin";
            this.textBoxPhoneAdmin.ReadOnly = true;
            this.textBoxPhoneAdmin.Size = new System.Drawing.Size(148, 20);
            this.textBoxPhoneAdmin.TabIndex = 1;
            this.textBoxPhoneAdmin.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBox_MouseClick);
            this.textBoxPhoneAdmin.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            this.textBoxPhoneAdmin.Leave += new System.EventHandler(this.textBoxPhoneAdmin_Leave);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 276);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(255, 22);
            this.statusStrip.TabIndex = 3;
            this.statusStrip.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // toolTipAdmin
            // 
            this.toolTipAdmin.AutoPopDelay = 5000;
            this.toolTipAdmin.InitialDelay = 500;
            this.toolTipAdmin.IsBalloon = true;
            this.toolTipAdmin.ReshowDelay = 3000;
            this.toolTipAdmin.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(255, 298);
            this.ControlBox = false;
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBoxKeyBinds);
            this.KeyPreview = true;
            this.Name = "AdminForm";
            this.Text = "MSSS Staff Management Admin Form";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AdminForm_FormClosing);
            this.Load += new System.EventHandler(this.AdminForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AdminForm_KeyDown);
            this.groupBoxKeyBinds.ResumeLayout(false);
            this.groupBoxKeyBinds.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxKeyBinds;
        private System.Windows.Forms.GroupBox groupBoxKeyBinds;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxUpdatedDetail;
        private System.Windows.Forms.TextBox textBoxNameAdmin;
        private System.Windows.Forms.TextBox textBoxPhoneAdmin;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ToolTip toolTipAdmin;
    }
}