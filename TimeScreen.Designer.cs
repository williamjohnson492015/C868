namespace C868
{
    partial class TimeScreen
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
            this.TimeScreen_TimeID_Text = new System.Windows.Forms.TextBox();
            this.TimeScreen_Save_Btn = new System.Windows.Forms.Button();
            this.TimeScreen_Cancel_Btn = new System.Windows.Forms.Button();
            this.TimeScreen_TimeID_Label = new System.Windows.Forms.Label();
            this.TimeScreen_Customer_Label = new System.Windows.Forms.Label();
            this.TimeScreen_Start_Label = new System.Windows.Forms.Label();
            this.TimeScreen_Customer_Combo = new System.Windows.Forms.ComboBox();
            this.TimeScreen_Type_Combo = new System.Windows.Forms.ComboBox();
            this.TimeScreen_Type_Label = new System.Windows.Forms.Label();
            this.TimeScreen_End_Label = new System.Windows.Forms.Label();
            this.TimeScreen_Start_DatePicker = new System.Windows.Forms.DateTimePicker();
            this.TimeScreen_End_DatePicker = new System.Windows.Forms.DateTimePicker();
            this.TimeScreen_Notes_Text = new System.Windows.Forms.TextBox();
            this.TimeScreen_Notes_Label = new System.Windows.Forms.Label();
            this.TimeScreen_Billable_CheckBox = new System.Windows.Forms.CheckBox();
            this.TimeScreen_Billable_Label = new System.Windows.Forms.Label();
            this.TimeScreen_Organization_Combo = new System.Windows.Forms.ComboBox();
            this.TimeScreen_Organization_Label = new System.Windows.Forms.Label();
            this.TimeScreen_ChargeTo_Combo = new System.Windows.Forms.ComboBox();
            this.TimeScreen_ChargeTo_Label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TimeScreen_TimeID_Text
            // 
            this.TimeScreen_TimeID_Text.Location = new System.Drawing.Point(129, 23);
            this.TimeScreen_TimeID_Text.Name = "TimeScreen_TimeID_Text";
            this.TimeScreen_TimeID_Text.ReadOnly = true;
            this.TimeScreen_TimeID_Text.Size = new System.Drawing.Size(85, 22);
            this.TimeScreen_TimeID_Text.TabIndex = 12;
            this.TimeScreen_TimeID_Text.TabStop = false;
            // 
            // TimeScreen_Save_Btn
            // 
            this.TimeScreen_Save_Btn.Location = new System.Drawing.Point(552, 315);
            this.TimeScreen_Save_Btn.Name = "TimeScreen_Save_Btn";
            this.TimeScreen_Save_Btn.Size = new System.Drawing.Size(118, 30);
            this.TimeScreen_Save_Btn.TabIndex = 9;
            this.TimeScreen_Save_Btn.Text = "Save";
            this.TimeScreen_Save_Btn.UseVisualStyleBackColor = true;
            this.TimeScreen_Save_Btn.Click += new System.EventHandler(this.TimeScreen_Save_Btn_Click);
            // 
            // TimeScreen_Cancel_Btn
            // 
            this.TimeScreen_Cancel_Btn.Location = new System.Drawing.Point(676, 315);
            this.TimeScreen_Cancel_Btn.Name = "TimeScreen_Cancel_Btn";
            this.TimeScreen_Cancel_Btn.Size = new System.Drawing.Size(118, 30);
            this.TimeScreen_Cancel_Btn.TabIndex = 10;
            this.TimeScreen_Cancel_Btn.Text = "Cancel";
            this.TimeScreen_Cancel_Btn.UseVisualStyleBackColor = true;
            this.TimeScreen_Cancel_Btn.Click += new System.EventHandler(this.TimeScreen_Cancel_Btn_Click);
            // 
            // TimeScreen_TimeID_Label
            // 
            this.TimeScreen_TimeID_Label.AutoSize = true;
            this.TimeScreen_TimeID_Label.Location = new System.Drawing.Point(57, 26);
            this.TimeScreen_TimeID_Label.Name = "TimeScreen_TimeID_Label";
            this.TimeScreen_TimeID_Label.Size = new System.Drawing.Size(54, 16);
            this.TimeScreen_TimeID_Label.TabIndex = 11;
            this.TimeScreen_TimeID_Label.Text = "TimeID:";
            // 
            // TimeScreen_Customer_Label
            // 
            this.TimeScreen_Customer_Label.AutoSize = true;
            this.TimeScreen_Customer_Label.Location = new System.Drawing.Point(44, 151);
            this.TimeScreen_Customer_Label.Name = "TimeScreen_Customer_Label";
            this.TimeScreen_Customer_Label.Size = new System.Drawing.Size(67, 16);
            this.TimeScreen_Customer_Label.TabIndex = 15;
            this.TimeScreen_Customer_Label.Text = "Customer:";
            // 
            // TimeScreen_Start_Label
            // 
            this.TimeScreen_Start_Label.AutoSize = true;
            this.TimeScreen_Start_Label.Location = new System.Drawing.Point(74, 196);
            this.TimeScreen_Start_Label.Name = "TimeScreen_Start_Label";
            this.TimeScreen_Start_Label.Size = new System.Drawing.Size(37, 16);
            this.TimeScreen_Start_Label.TabIndex = 16;
            this.TimeScreen_Start_Label.Text = "Start:";
            // 
            // TimeScreen_Customer_Combo
            // 
            this.TimeScreen_Customer_Combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TimeScreen_Customer_Combo.FormattingEnabled = true;
            this.TimeScreen_Customer_Combo.Location = new System.Drawing.Point(129, 148);
            this.TimeScreen_Customer_Combo.Name = "TimeScreen_Customer_Combo";
            this.TimeScreen_Customer_Combo.Size = new System.Drawing.Size(244, 24);
            this.TimeScreen_Customer_Combo.TabIndex = 3;
            // 
            // TimeScreen_Type_Combo
            // 
            this.TimeScreen_Type_Combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TimeScreen_Type_Combo.FormattingEnabled = true;
            this.TimeScreen_Type_Combo.Location = new System.Drawing.Point(129, 63);
            this.TimeScreen_Type_Combo.Name = "TimeScreen_Type_Combo";
            this.TimeScreen_Type_Combo.Size = new System.Drawing.Size(213, 24);
            this.TimeScreen_Type_Combo.TabIndex = 1;
            this.TimeScreen_Type_Combo.SelectedIndexChanged += new System.EventHandler(this.TimeScreen_Type_Combo_SelectedValueChanged);
            // 
            // TimeScreen_Type_Label
            // 
            this.TimeScreen_Type_Label.AutoSize = true;
            this.TimeScreen_Type_Label.Location = new System.Drawing.Point(69, 66);
            this.TimeScreen_Type_Label.Name = "TimeScreen_Type_Label";
            this.TimeScreen_Type_Label.Size = new System.Drawing.Size(42, 16);
            this.TimeScreen_Type_Label.TabIndex = 13;
            this.TimeScreen_Type_Label.Text = "Type:";
            // 
            // TimeScreen_End_Label
            // 
            this.TimeScreen_End_Label.AutoSize = true;
            this.TimeScreen_End_Label.Location = new System.Drawing.Point(77, 239);
            this.TimeScreen_End_Label.Name = "TimeScreen_End_Label";
            this.TimeScreen_End_Label.Size = new System.Drawing.Size(34, 16);
            this.TimeScreen_End_Label.TabIndex = 17;
            this.TimeScreen_End_Label.Text = "End:";
            // 
            // TimeScreen_Start_DatePicker
            // 
            this.TimeScreen_Start_DatePicker.CustomFormat = "MM\'/\'dd\'/\'yyyy hh\':\'mm tt";
            this.TimeScreen_Start_DatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.TimeScreen_Start_DatePicker.Location = new System.Drawing.Point(129, 191);
            this.TimeScreen_Start_DatePicker.Name = "TimeScreen_Start_DatePicker";
            this.TimeScreen_Start_DatePicker.Size = new System.Drawing.Size(244, 22);
            this.TimeScreen_Start_DatePicker.TabIndex = 4;
            this.TimeScreen_Start_DatePicker.ValueChanged += new System.EventHandler(this.TimeScreen_Start_DatePicker_ValueChanged);
            // 
            // TimeScreen_End_DatePicker
            // 
            this.TimeScreen_End_DatePicker.CustomFormat = "MM\'/\'dd\'/\'yyyy hh\':\'mm tt";
            this.TimeScreen_End_DatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.TimeScreen_End_DatePicker.Location = new System.Drawing.Point(129, 234);
            this.TimeScreen_End_DatePicker.Name = "TimeScreen_End_DatePicker";
            this.TimeScreen_End_DatePicker.Size = new System.Drawing.Size(244, 22);
            this.TimeScreen_End_DatePicker.TabIndex = 5;
            this.TimeScreen_End_DatePicker.ValueChanged += new System.EventHandler(this.TimeScreen_End_DatePicker_ValueChanged);
            // 
            // TimeScreen_Notes_Text
            // 
            this.TimeScreen_Notes_Text.Location = new System.Drawing.Point(414, 23);
            this.TimeScreen_Notes_Text.Multiline = true;
            this.TimeScreen_Notes_Text.Name = "TimeScreen_Notes_Text";
            this.TimeScreen_Notes_Text.Size = new System.Drawing.Size(380, 278);
            this.TimeScreen_Notes_Text.TabIndex = 8;
            // 
            // TimeScreen_Notes_Label
            // 
            this.TimeScreen_Notes_Label.AutoSize = true;
            this.TimeScreen_Notes_Label.Location = new System.Drawing.Point(352, 26);
            this.TimeScreen_Notes_Label.Name = "TimeScreen_Notes_Label";
            this.TimeScreen_Notes_Label.Size = new System.Drawing.Size(46, 16);
            this.TimeScreen_Notes_Label.TabIndex = 20;
            this.TimeScreen_Notes_Label.Text = "Notes:";
            // 
            // TimeScreen_Billable_CheckBox
            // 
            this.TimeScreen_Billable_CheckBox.AutoSize = true;
            this.TimeScreen_Billable_CheckBox.Checked = true;
            this.TimeScreen_Billable_CheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TimeScreen_Billable_CheckBox.Location = new System.Drawing.Point(317, 28);
            this.TimeScreen_Billable_CheckBox.Name = "TimeScreen_Billable_CheckBox";
            this.TimeScreen_Billable_CheckBox.Size = new System.Drawing.Size(18, 17);
            this.TimeScreen_Billable_CheckBox.TabIndex = 7;
            this.TimeScreen_Billable_CheckBox.UseVisualStyleBackColor = true;
            // 
            // TimeScreen_Billable_Label
            // 
            this.TimeScreen_Billable_Label.AutoSize = true;
            this.TimeScreen_Billable_Label.Location = new System.Drawing.Point(247, 27);
            this.TimeScreen_Billable_Label.Name = "TimeScreen_Billable_Label";
            this.TimeScreen_Billable_Label.Size = new System.Drawing.Size(55, 16);
            this.TimeScreen_Billable_Label.TabIndex = 19;
            this.TimeScreen_Billable_Label.Text = "Billable:";
            // 
            // TimeScreen_Organization_Combo
            // 
            this.TimeScreen_Organization_Combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TimeScreen_Organization_Combo.FormattingEnabled = true;
            this.TimeScreen_Organization_Combo.Location = new System.Drawing.Point(129, 105);
            this.TimeScreen_Organization_Combo.Name = "TimeScreen_Organization_Combo";
            this.TimeScreen_Organization_Combo.Size = new System.Drawing.Size(244, 24);
            this.TimeScreen_Organization_Combo.TabIndex = 2;
            this.TimeScreen_Organization_Combo.SelectedValueChanged += new System.EventHandler(this.TimeScreen_Organization_Combo_SelectedValueChanged);
            // 
            // TimeScreen_Organization_Label
            // 
            this.TimeScreen_Organization_Label.AutoSize = true;
            this.TimeScreen_Organization_Label.Location = new System.Drawing.Point(26, 108);
            this.TimeScreen_Organization_Label.Name = "TimeScreen_Organization_Label";
            this.TimeScreen_Organization_Label.Size = new System.Drawing.Size(85, 16);
            this.TimeScreen_Organization_Label.TabIndex = 14;
            this.TimeScreen_Organization_Label.Text = "Organization:";
            // 
            // TimeScreen_ChargeTo_Combo
            // 
            this.TimeScreen_ChargeTo_Combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TimeScreen_ChargeTo_Combo.FormattingEnabled = true;
            this.TimeScreen_ChargeTo_Combo.Location = new System.Drawing.Point(129, 276);
            this.TimeScreen_ChargeTo_Combo.Name = "TimeScreen_ChargeTo_Combo";
            this.TimeScreen_ChargeTo_Combo.Size = new System.Drawing.Size(244, 24);
            this.TimeScreen_ChargeTo_Combo.TabIndex = 6;
            // 
            // TimeScreen_ChargeTo_Label
            // 
            this.TimeScreen_ChargeTo_Label.AutoSize = true;
            this.TimeScreen_ChargeTo_Label.Location = new System.Drawing.Point(37, 279);
            this.TimeScreen_ChargeTo_Label.Name = "TimeScreen_ChargeTo_Label";
            this.TimeScreen_ChargeTo_Label.Size = new System.Drawing.Size(74, 16);
            this.TimeScreen_ChargeTo_Label.TabIndex = 18;
            this.TimeScreen_ChargeTo_Label.Text = "Charge To:";
            // 
            // TimeScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 357);
            this.Controls.Add(this.TimeScreen_ChargeTo_Combo);
            this.Controls.Add(this.TimeScreen_ChargeTo_Label);
            this.Controls.Add(this.TimeScreen_Organization_Combo);
            this.Controls.Add(this.TimeScreen_Organization_Label);
            this.Controls.Add(this.TimeScreen_Notes_Text);
            this.Controls.Add(this.TimeScreen_Notes_Label);
            this.Controls.Add(this.TimeScreen_Billable_CheckBox);
            this.Controls.Add(this.TimeScreen_Billable_Label);
            this.Controls.Add(this.TimeScreen_End_DatePicker);
            this.Controls.Add(this.TimeScreen_Start_DatePicker);
            this.Controls.Add(this.TimeScreen_End_Label);
            this.Controls.Add(this.TimeScreen_Type_Combo);
            this.Controls.Add(this.TimeScreen_Type_Label);
            this.Controls.Add(this.TimeScreen_Customer_Combo);
            this.Controls.Add(this.TimeScreen_Start_Label);
            this.Controls.Add(this.TimeScreen_Customer_Label);
            this.Controls.Add(this.TimeScreen_TimeID_Label);
            this.Controls.Add(this.TimeScreen_Cancel_Btn);
            this.Controls.Add(this.TimeScreen_Save_Btn);
            this.Controls.Add(this.TimeScreen_TimeID_Text);
            this.Name = "TimeScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Time";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox TimeScreen_TimeID_Text;
        private System.Windows.Forms.Button TimeScreen_Save_Btn;
        private System.Windows.Forms.Button TimeScreen_Cancel_Btn;
        private System.Windows.Forms.Label TimeScreen_TimeID_Label;
        private System.Windows.Forms.Label TimeScreen_Customer_Label;
        private System.Windows.Forms.Label TimeScreen_Start_Label;
        private System.Windows.Forms.ComboBox TimeScreen_Customer_Combo;
        private System.Windows.Forms.ComboBox TimeScreen_Type_Combo;
        private System.Windows.Forms.Label TimeScreen_Type_Label;
        private System.Windows.Forms.Label TimeScreen_End_Label;
        private System.Windows.Forms.DateTimePicker TimeScreen_Start_DatePicker;
        private System.Windows.Forms.DateTimePicker TimeScreen_End_DatePicker;
        private System.Windows.Forms.TextBox TimeScreen_Notes_Text;
        private System.Windows.Forms.Label TimeScreen_Notes_Label;
        private System.Windows.Forms.CheckBox TimeScreen_Billable_CheckBox;
        private System.Windows.Forms.Label TimeScreen_Billable_Label;
        private System.Windows.Forms.ComboBox TimeScreen_Organization_Combo;
        private System.Windows.Forms.Label TimeScreen_Organization_Label;
        private System.Windows.Forms.ComboBox TimeScreen_ChargeTo_Combo;
        private System.Windows.Forms.Label TimeScreen_ChargeTo_Label;
    }
}

