namespace SetPUBVolume
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.volumeA = new System.Windows.Forms.TextBox();
            this.volumeB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtProcessName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbShortcut = new System.Windows.Forms.ComboBox();
            this.cmbProcessName = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtProcessFound = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // volumeA
            // 
            this.volumeA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.volumeA.Location = new System.Drawing.Point(129, 90);
            this.volumeA.MaxLength = 3;
            this.volumeA.Name = "volumeA";
            this.volumeA.Size = new System.Drawing.Size(50, 20);
            this.volumeA.TabIndex = 0;
            this.volumeA.Text = "100";
            this.volumeA.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // volumeB
            // 
            this.volumeB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.volumeB.Location = new System.Drawing.Point(129, 115);
            this.volumeB.MaxLength = 3;
            this.volumeB.Name = "volumeB";
            this.volumeB.Size = new System.Drawing.Size(50, 20);
            this.volumeB.TabIndex = 1;
            this.volumeB.Text = "25";
            this.volumeB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Volume A %";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Volume B %";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Processes Saved";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // txtProcessName
            // 
            this.txtProcessName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProcessName.Location = new System.Drawing.Point(270, 12);
            this.txtProcessName.Name = "txtProcessName";
            this.txtProcessName.Size = new System.Drawing.Size(135, 20);
            this.txtProcessName.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Keyboard Shortcut";
            // 
            // cmbShortcut
            // 
            this.cmbShortcut.AccessibleDescription = "Key to use as shortcut";
            this.cmbShortcut.AccessibleName = "Keyboard Shorcut";
            this.cmbShortcut.AccessibleRole = System.Windows.Forms.AccessibleRole.ComboBox;
            this.cmbShortcut.BackColor = System.Drawing.SystemColors.Window;
            this.cmbShortcut.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbShortcut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbShortcut.FormattingEnabled = true;
            this.cmbShortcut.Location = new System.Drawing.Point(129, 63);
            this.cmbShortcut.Name = "cmbShortcut";
            this.cmbShortcut.Size = new System.Drawing.Size(50, 21);
            this.cmbShortcut.TabIndex = 8;
            this.cmbShortcut.SelectedValueChanged += new System.EventHandler(this.cmbShortcut_SelectedValueChanged);
            // 
            // cmbProcessName
            // 
            this.cmbProcessName.AccessibleDescription = "Process name";
            this.cmbProcessName.AccessibleName = "Process name";
            this.cmbProcessName.AccessibleRole = System.Windows.Forms.AccessibleRole.ComboBox;
            this.cmbProcessName.BackColor = System.Drawing.SystemColors.Window;
            this.cmbProcessName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProcessName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbProcessName.FormattingEnabled = true;
            this.cmbProcessName.Location = new System.Drawing.Point(129, 12);
            this.cmbProcessName.Name = "cmbProcessName";
            this.cmbProcessName.Size = new System.Drawing.Size(135, 21);
            this.cmbProcessName.TabIndex = 9;
            this.cmbProcessName.SelectedValueChanged += new System.EventHandler(this.cmbProcessName_SelectedValueChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(270, 40);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Save  profile";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Process";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // txtProcessFound
            // 
            this.txtProcessFound.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtProcessFound.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProcessFound.Enabled = false;
            this.txtProcessFound.Location = new System.Drawing.Point(129, 40);
            this.txtProcessFound.Name = "txtProcessFound";
            this.txtProcessFound.Size = new System.Drawing.Size(135, 20);
            this.txtProcessFound.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 140);
            this.Controls.Add(this.txtProcessFound);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmbProcessName);
            this.Controls.Add(this.cmbShortcut);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtProcessName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.volumeB);
            this.Controls.Add(this.volumeA);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox volumeA;
        private System.Windows.Forms.TextBox volumeB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtProcessName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbShortcut;
        private System.Windows.Forms.ComboBox cmbProcessName;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtProcessFound;
    }
}

