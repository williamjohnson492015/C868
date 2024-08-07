namespace C868
{
    partial class AppointmentScreen
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
            this.AppointmentScreen_AppointmentID_Text = new System.Windows.Forms.TextBox();
            this.AppointmentScreen_Save_Btn = new System.Windows.Forms.Button();
            this.AppointmentScreen_Cancel_Btn = new System.Windows.Forms.Button();
            this.AppointmentScreen_AppointmentID_Label = new System.Windows.Forms.Label();
            this.AppointmentScreen_Customer_Label = new System.Windows.Forms.Label();
            this.AppointmentScreen_Start_Label = new System.Windows.Forms.Label();
            this.AppointmentScreen_Customer_Combo = new System.Windows.Forms.ComboBox();
            this.AppointmentScreen_Type_Combo = new System.Windows.Forms.ComboBox();
            this.AppointmentScreen_Type_Label = new System.Windows.Forms.Label();
            this.AppointmentScreen_End_Label = new System.Windows.Forms.Label();
            this.AppointmentScreen_Start_DatePicker = new System.Windows.Forms.DateTimePicker();
            this.AppointmentScreen_End_DatePicker = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // AppointmentScreen_AppointmentID_Text
            // 
            this.AppointmentScreen_AppointmentID_Text.Location = new System.Drawing.Point(129, 23);
            this.AppointmentScreen_AppointmentID_Text.Name = "AppointmentScreen_AppointmentID_Text";
            this.AppointmentScreen_AppointmentID_Text.ReadOnly = true;
            this.AppointmentScreen_AppointmentID_Text.Size = new System.Drawing.Size(85, 22);
            this.AppointmentScreen_AppointmentID_Text.TabIndex = 11;
            // 
            // AppointmentScreen_Save_Btn
            // 
            this.AppointmentScreen_Save_Btn.Location = new System.Drawing.Point(49, 238);
            this.AppointmentScreen_Save_Btn.Name = "AppointmentScreen_Save_Btn";
            this.AppointmentScreen_Save_Btn.Size = new System.Drawing.Size(118, 30);
            this.AppointmentScreen_Save_Btn.TabIndex = 5;
            this.AppointmentScreen_Save_Btn.Text = "Save";
            this.AppointmentScreen_Save_Btn.UseVisualStyleBackColor = true;
            this.AppointmentScreen_Save_Btn.Click += new System.EventHandler(this.AppointmentScreen_Save_Btn_Click);
            // 
            // AppointmentScreen_Cancel_Btn
            // 
            this.AppointmentScreen_Cancel_Btn.Location = new System.Drawing.Point(224, 238);
            this.AppointmentScreen_Cancel_Btn.Name = "AppointmentScreen_Cancel_Btn";
            this.AppointmentScreen_Cancel_Btn.Size = new System.Drawing.Size(118, 30);
            this.AppointmentScreen_Cancel_Btn.TabIndex = 6;
            this.AppointmentScreen_Cancel_Btn.Text = "Cancel";
            this.AppointmentScreen_Cancel_Btn.UseVisualStyleBackColor = true;
            this.AppointmentScreen_Cancel_Btn.Click += new System.EventHandler(this.AppointmentScreen_Cancel_Btn_Click);
            // 
            // AppointmentScreen_AppointmentID_Label
            // 
            this.AppointmentScreen_AppointmentID_Label.AutoSize = true;
            this.AppointmentScreen_AppointmentID_Label.Location = new System.Drawing.Point(13, 26);
            this.AppointmentScreen_AppointmentID_Label.Name = "AppointmentScreen_AppointmentID_Label";
            this.AppointmentScreen_AppointmentID_Label.Size = new System.Drawing.Size(98, 16);
            this.AppointmentScreen_AppointmentID_Label.TabIndex = 10;
            this.AppointmentScreen_AppointmentID_Label.Text = "AppointmentID:";
            // 
            // AppointmentScreen_Customer_Label
            // 
            this.AppointmentScreen_Customer_Label.AutoSize = true;
            this.AppointmentScreen_Customer_Label.Location = new System.Drawing.Point(44, 110);
            this.AppointmentScreen_Customer_Label.Name = "AppointmentScreen_Customer_Label";
            this.AppointmentScreen_Customer_Label.Size = new System.Drawing.Size(67, 16);
            this.AppointmentScreen_Customer_Label.TabIndex = 13;
            this.AppointmentScreen_Customer_Label.Text = "Customer:";
            // 
            // AppointmentScreen_Start_Label
            // 
            this.AppointmentScreen_Start_Label.AutoSize = true;
            this.AppointmentScreen_Start_Label.Location = new System.Drawing.Point(74, 155);
            this.AppointmentScreen_Start_Label.Name = "AppointmentScreen_Start_Label";
            this.AppointmentScreen_Start_Label.Size = new System.Drawing.Size(37, 16);
            this.AppointmentScreen_Start_Label.TabIndex = 14;
            this.AppointmentScreen_Start_Label.Text = "Start:";
            // 
            // AppointmentScreen_Customer_Combo
            // 
            this.AppointmentScreen_Customer_Combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AppointmentScreen_Customer_Combo.FormattingEnabled = true;
            this.AppointmentScreen_Customer_Combo.Location = new System.Drawing.Point(129, 107);
            this.AppointmentScreen_Customer_Combo.Name = "AppointmentScreen_Customer_Combo";
            this.AppointmentScreen_Customer_Combo.Size = new System.Drawing.Size(244, 24);
            this.AppointmentScreen_Customer_Combo.TabIndex = 2;
            // 
            // AppointmentScreen_Type_Combo
            // 
            this.AppointmentScreen_Type_Combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AppointmentScreen_Type_Combo.FormattingEnabled = true;
            this.AppointmentScreen_Type_Combo.Location = new System.Drawing.Point(129, 63);
            this.AppointmentScreen_Type_Combo.Name = "AppointmentScreen_Type_Combo";
            this.AppointmentScreen_Type_Combo.Size = new System.Drawing.Size(213, 24);
            this.AppointmentScreen_Type_Combo.TabIndex = 1;
            // 
            // AppointmentScreen_Type_Label
            // 
            this.AppointmentScreen_Type_Label.AutoSize = true;
            this.AppointmentScreen_Type_Label.Location = new System.Drawing.Point(69, 66);
            this.AppointmentScreen_Type_Label.Name = "AppointmentScreen_Type_Label";
            this.AppointmentScreen_Type_Label.Size = new System.Drawing.Size(42, 16);
            this.AppointmentScreen_Type_Label.TabIndex = 12;
            this.AppointmentScreen_Type_Label.Text = "Type:";
            // 
            // AppointmentScreen_End_Label
            // 
            this.AppointmentScreen_End_Label.AutoSize = true;
            this.AppointmentScreen_End_Label.Location = new System.Drawing.Point(77, 198);
            this.AppointmentScreen_End_Label.Name = "AppointmentScreen_End_Label";
            this.AppointmentScreen_End_Label.Size = new System.Drawing.Size(34, 16);
            this.AppointmentScreen_End_Label.TabIndex = 15;
            this.AppointmentScreen_End_Label.Text = "End:";
            // 
            // AppointmentScreen_Start_DatePicker
            // 
            this.AppointmentScreen_Start_DatePicker.CustomFormat = "MM\'/\'dd\'/\'yyyy hh\':\'mm tt";
            this.AppointmentScreen_Start_DatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.AppointmentScreen_Start_DatePicker.Location = new System.Drawing.Point(129, 150);
            this.AppointmentScreen_Start_DatePicker.Name = "AppointmentScreen_Start_DatePicker";
            this.AppointmentScreen_Start_DatePicker.Size = new System.Drawing.Size(244, 22);
            this.AppointmentScreen_Start_DatePicker.TabIndex = 3;
            // 
            // AppointmentScreen_End_DatePicker
            // 
            this.AppointmentScreen_End_DatePicker.CustomFormat = "MM\'/\'dd\'/\'yyyy hh\':\'mm tt";
            this.AppointmentScreen_End_DatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.AppointmentScreen_End_DatePicker.Location = new System.Drawing.Point(129, 193);
            this.AppointmentScreen_End_DatePicker.Name = "AppointmentScreen_End_DatePicker";
            this.AppointmentScreen_End_DatePicker.Size = new System.Drawing.Size(244, 22);
            this.AppointmentScreen_End_DatePicker.TabIndex = 4;
            // 
            // AppointmentScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 287);
            this.Controls.Add(this.AppointmentScreen_End_DatePicker);
            this.Controls.Add(this.AppointmentScreen_Start_DatePicker);
            this.Controls.Add(this.AppointmentScreen_End_Label);
            this.Controls.Add(this.AppointmentScreen_Type_Combo);
            this.Controls.Add(this.AppointmentScreen_Type_Label);
            this.Controls.Add(this.AppointmentScreen_Customer_Combo);
            this.Controls.Add(this.AppointmentScreen_Start_Label);
            this.Controls.Add(this.AppointmentScreen_Customer_Label);
            this.Controls.Add(this.AppointmentScreen_AppointmentID_Label);
            this.Controls.Add(this.AppointmentScreen_Cancel_Btn);
            this.Controls.Add(this.AppointmentScreen_Save_Btn);
            this.Controls.Add(this.AppointmentScreen_AppointmentID_Text);
            this.Name = "AppointmentScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Appointment";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox AppointmentScreen_AppointmentID_Text;
        private System.Windows.Forms.Button AppointmentScreen_Save_Btn;
        private System.Windows.Forms.Button AppointmentScreen_Cancel_Btn;
        private System.Windows.Forms.Label AppointmentScreen_AppointmentID_Label;
        private System.Windows.Forms.Label AppointmentScreen_Customer_Label;
        private System.Windows.Forms.Label AppointmentScreen_Start_Label;
        private System.Windows.Forms.ComboBox AppointmentScreen_Customer_Combo;
        private System.Windows.Forms.ComboBox AppointmentScreen_Type_Combo;
        private System.Windows.Forms.Label AppointmentScreen_Type_Label;
        private System.Windows.Forms.Label AppointmentScreen_End_Label;
        private System.Windows.Forms.DateTimePicker AppointmentScreen_Start_DatePicker;
        private System.Windows.Forms.DateTimePicker AppointmentScreen_End_DatePicker;
    }
}

