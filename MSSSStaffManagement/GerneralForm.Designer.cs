namespace MSSSStaffManagement
{
    partial class GerneralForm
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
            this.listBoxRead = new System.Windows.Forms.ListBox();
            this.listBoxFiltered = new System.Windows.Forms.ListBox();
            this.textBoxPhoneGen = new System.Windows.Forms.TextBox();
            this.textBoxNameGen = new System.Windows.Forms.TextBox();
            this.labelPhoneGen = new System.Windows.Forms.Label();
            this.labelNameGen = new System.Windows.Forms.Label();
            this.labelKeyBindingsGen = new System.Windows.Forms.Label();
            this.textBoxKeyBindingGen = new System.Windows.Forms.TextBox();
            this.groupBoxInput = new System.Windows.Forms.GroupBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBoxInput.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxRead
            // 
            this.listBoxRead.FormattingEnabled = true;
            this.listBoxRead.Location = new System.Drawing.Point(12, 12);
            this.listBoxRead.Name = "listBoxRead";
            this.listBoxRead.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBoxRead.Size = new System.Drawing.Size(179, 238);
            this.listBoxRead.TabIndex = 0;
            // 
            // listBoxFiltered
            // 
            this.listBoxFiltered.FormattingEnabled = true;
            this.listBoxFiltered.Location = new System.Drawing.Point(381, 12);
            this.listBoxFiltered.Name = "listBoxFiltered";
            this.listBoxFiltered.Size = new System.Drawing.Size(179, 238);
            this.listBoxFiltered.TabIndex = 1;
            // 
            // textBoxPhoneGen
            // 
            this.textBoxPhoneGen.Location = new System.Drawing.Point(61, 25);
            this.textBoxPhoneGen.Name = "textBoxPhoneGen";
            this.textBoxPhoneGen.Size = new System.Drawing.Size(102, 20);
            this.textBoxPhoneGen.TabIndex = 2;
            this.textBoxPhoneGen.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // textBoxNameGen
            // 
            this.textBoxNameGen.Location = new System.Drawing.Point(61, 62);
            this.textBoxNameGen.Name = "textBoxNameGen";
            this.textBoxNameGen.Size = new System.Drawing.Size(102, 20);
            this.textBoxNameGen.TabIndex = 3;
            this.textBoxNameGen.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // labelPhoneGen
            // 
            this.labelPhoneGen.AutoSize = true;
            this.labelPhoneGen.Location = new System.Drawing.Point(6, 30);
            this.labelPhoneGen.Name = "labelPhoneGen";
            this.labelPhoneGen.Size = new System.Drawing.Size(52, 13);
            this.labelPhoneGen.TabIndex = 4;
            this.labelPhoneGen.Text = "Phone ID";
            // 
            // labelNameGen
            // 
            this.labelNameGen.AutoSize = true;
            this.labelNameGen.Location = new System.Drawing.Point(7, 66);
            this.labelNameGen.Name = "labelNameGen";
            this.labelNameGen.Size = new System.Drawing.Size(35, 13);
            this.labelNameGen.TabIndex = 5;
            this.labelNameGen.Text = "Name";
            // 
            // labelKeyBindingsGen
            // 
            this.labelKeyBindingsGen.AutoSize = true;
            this.labelKeyBindingsGen.Location = new System.Drawing.Point(252, 15);
            this.labelKeyBindingsGen.Name = "labelKeyBindingsGen";
            this.labelKeyBindingsGen.Size = new System.Drawing.Size(68, 13);
            this.labelKeyBindingsGen.TabIndex = 6;
            this.labelKeyBindingsGen.Text = "Key Bindings";
            // 
            // textBoxKeyBindingGen
            // 
            this.textBoxKeyBindingGen.Location = new System.Drawing.Point(212, 35);
            this.textBoxKeyBindingGen.Multiline = true;
            this.textBoxKeyBindingGen.Name = "textBoxKeyBindingGen";
            this.textBoxKeyBindingGen.Size = new System.Drawing.Size(151, 52);
            this.textBoxKeyBindingGen.TabIndex = 7;
            this.textBoxKeyBindingGen.Text = "Alt+X -> Name box\r\nAlt+C -> Phone ID box\r\nAlt+A -> Admin Form";
            this.textBoxKeyBindingGen.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBoxInput
            // 
            this.groupBoxInput.Controls.Add(this.textBoxNameGen);
            this.groupBoxInput.Controls.Add(this.textBoxPhoneGen);
            this.groupBoxInput.Controls.Add(this.labelPhoneGen);
            this.groupBoxInput.Controls.Add(this.labelNameGen);
            this.groupBoxInput.Location = new System.Drawing.Point(197, 102);
            this.groupBoxInput.Name = "groupBoxInput";
            this.groupBoxInput.Size = new System.Drawing.Size(178, 100);
            this.groupBoxInput.TabIndex = 8;
            this.groupBoxInput.TabStop = false;
            this.groupBoxInput.Text = "Filter";
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
            // GerneralForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 280);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.groupBoxInput);
            this.Controls.Add(this.textBoxKeyBindingGen);
            this.Controls.Add(this.labelKeyBindingsGen);
            this.Controls.Add(this.listBoxFiltered);
            this.Controls.Add(this.listBoxRead);
            this.KeyPreview = true;
            this.Name = "GerneralForm";
            this.Text = "Staff Management Form";
            this.Load += new System.EventHandler(this.GerneralForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GerneralForm_KeyDown);
            this.groupBoxInput.ResumeLayout(false);
            this.groupBoxInput.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxRead;
        private System.Windows.Forms.ListBox listBoxFiltered;
        private System.Windows.Forms.TextBox textBoxPhoneGen;
        private System.Windows.Forms.TextBox textBoxNameGen;
        private System.Windows.Forms.Label labelPhoneGen;
        private System.Windows.Forms.Label labelNameGen;
        private System.Windows.Forms.Label labelKeyBindingsGen;
        private System.Windows.Forms.TextBox textBoxKeyBindingGen;
        private System.Windows.Forms.GroupBox groupBoxInput;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
    }
}

