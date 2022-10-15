namespace MSSSStaffManagement
{
    partial class GeneralForm
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
            this.listBoxRead = new System.Windows.Forms.ListBox();
            this.listBoxFiltered = new System.Windows.Forms.ListBox();
            this.textBoxPhone = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelPhone = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.textBoxKeyBinds = new System.Windows.Forms.TextBox();
            this.groupBoxInput = new System.Windows.Forms.GroupBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTipGen = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBoxInput.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxRead
            // 
            this.listBoxRead.FormattingEnabled = true;
            this.listBoxRead.Location = new System.Drawing.Point(12, 12);
            this.listBoxRead.Name = "listBoxRead";
            this.listBoxRead.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBoxRead.Size = new System.Drawing.Size(180, 238);
            this.listBoxRead.TabIndex = 0;
            // 
            // listBoxFiltered
            // 
            this.listBoxFiltered.FormattingEnabled = true;
            this.listBoxFiltered.Location = new System.Drawing.Point(379, 12);
            this.listBoxFiltered.Name = "listBoxFiltered";
            this.listBoxFiltered.Size = new System.Drawing.Size(180, 238);
            this.listBoxFiltered.TabIndex = 1;
            // 
            // textBoxPhone
            // 
            this.textBoxPhone.Location = new System.Drawing.Point(61, 25);
            this.textBoxPhone.Name = "textBoxPhone";
            this.textBoxPhone.Size = new System.Drawing.Size(102, 20);
            this.textBoxPhone.TabIndex = 2;
            this.textBoxPhone.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(61, 62);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(102, 20);
            this.textBoxName.TabIndex = 3;
            this.textBoxName.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // labelPhone
            // 
            this.labelPhone.AutoSize = true;
            this.labelPhone.Location = new System.Drawing.Point(6, 30);
            this.labelPhone.Name = "labelPhone";
            this.labelPhone.Size = new System.Drawing.Size(52, 13);
            this.labelPhone.TabIndex = 4;
            this.labelPhone.Text = "Phone ID";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(7, 66);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(35, 13);
            this.labelName.TabIndex = 5;
            this.labelName.Text = "Name";
            // 
            // textBoxKeyBinds
            // 
            this.textBoxKeyBinds.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxKeyBinds.Location = new System.Drawing.Point(13, 19);
            this.textBoxKeyBinds.Multiline = true;
            this.textBoxKeyBinds.Name = "textBoxKeyBinds";
            this.textBoxKeyBinds.Size = new System.Drawing.Size(156, 83);
            this.textBoxKeyBinds.TabIndex = 7;
            this.textBoxKeyBinds.Text = "Alt+C » Navigate to Phone ID\r\nAlt+X » Navigate to Name\r\nAlt+A » Open Admin Form\r\n" +
    "Right Arrow Key » Enter List\r\nEnter » Select ID from List\r\nAlt+L » Exit";
            // 
            // groupBoxInput
            // 
            this.groupBoxInput.Controls.Add(this.textBoxName);
            this.groupBoxInput.Controls.Add(this.textBoxPhone);
            this.groupBoxInput.Controls.Add(this.labelPhone);
            this.groupBoxInput.Controls.Add(this.labelName);
            this.groupBoxInput.Location = new System.Drawing.Point(198, 36);
            this.groupBoxInput.Name = "groupBoxInput";
            this.groupBoxInput.Size = new System.Drawing.Size(175, 100);
            this.groupBoxInput.TabIndex = 8;
            this.groupBoxInput.TabStop = false;
            this.groupBoxInput.Text = "Filter Staff";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 258);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(571, 22);
            this.statusStrip.TabIndex = 9;
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // toolTipGen
            // 
            this.toolTipGen.AutoPopDelay = 5000;
            this.toolTipGen.InitialDelay = 500;
            this.toolTipGen.IsBalloon = true;
            this.toolTipGen.ReshowDelay = 2000;
            this.toolTipGen.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTipGen.ToolTipTitle = "Filter Staff Records";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxKeyBinds);
            this.groupBox1.Location = new System.Drawing.Point(198, 142);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(175, 108);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Key Bindings";
            // 
            // GeneralForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 280);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.groupBoxInput);
            this.Controls.Add(this.listBoxFiltered);
            this.Controls.Add(this.listBoxRead);
            this.KeyPreview = true;
            this.Name = "GeneralForm";
            this.Text = "Staff Management Form";
            this.Load += new System.EventHandler(this.GerneralForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GerneralForm_KeyDown);
            this.groupBoxInput.ResumeLayout(false);
            this.groupBoxInput.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxRead;
        private System.Windows.Forms.ListBox listBoxFiltered;
        private System.Windows.Forms.TextBox textBoxPhone;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelPhone;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox textBoxKeyBinds;
        private System.Windows.Forms.GroupBox groupBoxInput;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ToolTip toolTipGen;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

