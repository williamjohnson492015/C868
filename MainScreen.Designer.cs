using System.ComponentModel;

namespace C868
{
    partial class MainScreen
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.MainScreen_CustomerSearch_Text = new System.Windows.Forms.TextBox();
            this.MainScreen_CustomerGridView = new System.Windows.Forms.DataGridView();
            this.MainScreen_AddNewCustomer_Btn = new System.Windows.Forms.Button();
            this.MainScreen_EditCustomer_Btn = new System.Windows.Forms.Button();
            this.MainScreen_DeleteCustomer_Btn = new System.Windows.Forms.Button();
            this.MainScreen_AppointmentGridView = new System.Windows.Forms.DataGridView();
            this.MainScreen_AddNewAppointment_Btn = new System.Windows.Forms.Button();
            this.MainScreen_EditAppointment_Btn = new System.Windows.Forms.Button();
            this.MainScreen_DeleteAppointment_Btn = new System.Windows.Forms.Button();
            this.MainScreen_Date_Label = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MainScreen_Reports_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainScreen_AppointmentTypesByMonth_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainScreen_SchedulesByCustomer_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainScreen_SchedulesByUser_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainScreen_Config_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainScreen_Organizations_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainScreen_Exit_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainScreen_DatePicker = new System.Windows.Forms.DateTimePicker();
            this.MainScreen_CustomerSearch_Label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.MainScreen_CustomerGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainScreen_AppointmentGridView)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainScreen_CustomerSearch_Text
            // 
            this.MainScreen_CustomerSearch_Text.Location = new System.Drawing.Point(101, 39);
            this.MainScreen_CustomerSearch_Text.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MainScreen_CustomerSearch_Text.Name = "MainScreen_CustomerSearch_Text";
            this.MainScreen_CustomerSearch_Text.Size = new System.Drawing.Size(193, 22);
            this.MainScreen_CustomerSearch_Text.TabIndex = 2;
            this.MainScreen_CustomerSearch_Text.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainScreen_CustomerSearch_Text_KeyDown);
            // 
            // MainScreen_CustomerGridView
            // 
            this.MainScreen_CustomerGridView.AllowUserToAddRows = false;
            this.MainScreen_CustomerGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.MainScreen_CustomerGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.MainScreen_CustomerGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MainScreen_CustomerGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.MainScreen_CustomerGridView.EnableHeadersVisualStyles = false;
            this.MainScreen_CustomerGridView.Location = new System.Drawing.Point(25, 68);
            this.MainScreen_CustomerGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MainScreen_CustomerGridView.MultiSelect = false;
            this.MainScreen_CustomerGridView.Name = "MainScreen_CustomerGridView";
            this.MainScreen_CustomerGridView.RowHeadersVisible = false;
            this.MainScreen_CustomerGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.MainScreen_CustomerGridView.RowTemplate.Height = 24;
            this.MainScreen_CustomerGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.MainScreen_CustomerGridView.Size = new System.Drawing.Size(271, 391);
            this.MainScreen_CustomerGridView.TabIndex = 12;
            this.MainScreen_CustomerGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.MainScreen_CustomerGridView_DataBindingComplete);
            // 
            // MainScreen_AddNewCustomer_Btn
            // 
            this.MainScreen_AddNewCustomer_Btn.Location = new System.Drawing.Point(25, 465);
            this.MainScreen_AddNewCustomer_Btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MainScreen_AddNewCustomer_Btn.Name = "MainScreen_AddNewCustomer_Btn";
            this.MainScreen_AddNewCustomer_Btn.Size = new System.Drawing.Size(271, 30);
            this.MainScreen_AddNewCustomer_Btn.TabIndex = 13;
            this.MainScreen_AddNewCustomer_Btn.Text = "+ Add New Customer";
            this.MainScreen_AddNewCustomer_Btn.UseVisualStyleBackColor = true;
            this.MainScreen_AddNewCustomer_Btn.Click += new System.EventHandler(this.MainScreen_AddNewCustomer_Btn_Click);
            // 
            // MainScreen_EditCustomer_Btn
            // 
            this.MainScreen_EditCustomer_Btn.Location = new System.Drawing.Point(25, 501);
            this.MainScreen_EditCustomer_Btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MainScreen_EditCustomer_Btn.Name = "MainScreen_EditCustomer_Btn";
            this.MainScreen_EditCustomer_Btn.Size = new System.Drawing.Size(133, 30);
            this.MainScreen_EditCustomer_Btn.TabIndex = 14;
            this.MainScreen_EditCustomer_Btn.Text = "Edit Customer";
            this.MainScreen_EditCustomer_Btn.UseVisualStyleBackColor = true;
            this.MainScreen_EditCustomer_Btn.Click += new System.EventHandler(this.MainScreen_EditCustomer_Btn_Click);
            // 
            // MainScreen_DeleteCustomer_Btn
            // 
            this.MainScreen_DeleteCustomer_Btn.Location = new System.Drawing.Point(164, 501);
            this.MainScreen_DeleteCustomer_Btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MainScreen_DeleteCustomer_Btn.Name = "MainScreen_DeleteCustomer_Btn";
            this.MainScreen_DeleteCustomer_Btn.Size = new System.Drawing.Size(132, 30);
            this.MainScreen_DeleteCustomer_Btn.TabIndex = 15;
            this.MainScreen_DeleteCustomer_Btn.Text = "Delete Customer";
            this.MainScreen_DeleteCustomer_Btn.UseVisualStyleBackColor = true;
            this.MainScreen_DeleteCustomer_Btn.Click += new System.EventHandler(this.MainScreen_DeleteCustomer_Btn_Click);
            // 
            // MainScreen_AppointmentGridView
            // 
            this.MainScreen_AppointmentGridView.AllowUserToAddRows = false;
            this.MainScreen_AppointmentGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.MainScreen_AppointmentGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.MainScreen_AppointmentGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MainScreen_AppointmentGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.MainScreen_AppointmentGridView.EnableHeadersVisualStyles = false;
            this.MainScreen_AppointmentGridView.Location = new System.Drawing.Point(313, 68);
            this.MainScreen_AppointmentGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MainScreen_AppointmentGridView.MultiSelect = false;
            this.MainScreen_AppointmentGridView.Name = "MainScreen_AppointmentGridView";
            this.MainScreen_AppointmentGridView.RowHeadersVisible = false;
            this.MainScreen_AppointmentGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.MainScreen_AppointmentGridView.RowTemplate.Height = 24;
            this.MainScreen_AppointmentGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.MainScreen_AppointmentGridView.Size = new System.Drawing.Size(537, 391);
            this.MainScreen_AppointmentGridView.TabIndex = 16;
            this.MainScreen_AppointmentGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.MainScreen_AppointmentGridView_DataBindingComplete);
            // 
            // MainScreen_AddNewAppointment_Btn
            // 
            this.MainScreen_AddNewAppointment_Btn.Location = new System.Drawing.Point(579, 465);
            this.MainScreen_AddNewAppointment_Btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MainScreen_AddNewAppointment_Btn.Name = "MainScreen_AddNewAppointment_Btn";
            this.MainScreen_AddNewAppointment_Btn.Size = new System.Drawing.Size(271, 30);
            this.MainScreen_AddNewAppointment_Btn.TabIndex = 17;
            this.MainScreen_AddNewAppointment_Btn.Text = "+ Add New Appointment";
            this.MainScreen_AddNewAppointment_Btn.UseVisualStyleBackColor = true;
            this.MainScreen_AddNewAppointment_Btn.Click += new System.EventHandler(this.MainScreen_AddNewAppointment_Btn_Click);
            // 
            // MainScreen_EditAppointment_Btn
            // 
            this.MainScreen_EditAppointment_Btn.Location = new System.Drawing.Point(579, 502);
            this.MainScreen_EditAppointment_Btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MainScreen_EditAppointment_Btn.Name = "MainScreen_EditAppointment_Btn";
            this.MainScreen_EditAppointment_Btn.Size = new System.Drawing.Size(132, 30);
            this.MainScreen_EditAppointment_Btn.TabIndex = 18;
            this.MainScreen_EditAppointment_Btn.Text = "Edit Appointment";
            this.MainScreen_EditAppointment_Btn.UseVisualStyleBackColor = true;
            this.MainScreen_EditAppointment_Btn.Click += new System.EventHandler(this.MainScreen_EditAppointment_Btn_Click);
            // 
            // MainScreen_DeleteAppointment_Btn
            // 
            this.MainScreen_DeleteAppointment_Btn.Location = new System.Drawing.Point(717, 501);
            this.MainScreen_DeleteAppointment_Btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MainScreen_DeleteAppointment_Btn.Name = "MainScreen_DeleteAppointment_Btn";
            this.MainScreen_DeleteAppointment_Btn.Size = new System.Drawing.Size(133, 30);
            this.MainScreen_DeleteAppointment_Btn.TabIndex = 19;
            this.MainScreen_DeleteAppointment_Btn.Text = "Delete Appointment";
            this.MainScreen_DeleteAppointment_Btn.UseVisualStyleBackColor = true;
            this.MainScreen_DeleteAppointment_Btn.Click += new System.EventHandler(this.MainScreen_DeleteAppointment_Btn_Click);
            // 
            // MainScreen_Date_Label
            // 
            this.MainScreen_Date_Label.AutoSize = true;
            this.MainScreen_Date_Label.Location = new System.Drawing.Point(544, 43);
            this.MainScreen_Date_Label.Name = "MainScreen_Date_Label";
            this.MainScreen_Date_Label.Size = new System.Drawing.Size(39, 16);
            this.MainScreen_Date_Label.TabIndex = 21;
            this.MainScreen_Date_Label.Text = "Date:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MainScreen_Reports_MenuItem,
            this.MainScreen_Config_MenuItem,
            this.MainScreen_Exit_MenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(877, 28);
            this.menuStrip1.TabIndex = 22;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MainScreen_Reports_MenuItem
            // 
            this.MainScreen_Reports_MenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MainScreen_AppointmentTypesByMonth_MenuItem,
            this.MainScreen_SchedulesByCustomer_MenuItem,
            this.MainScreen_SchedulesByUser_MenuItem});
            this.MainScreen_Reports_MenuItem.Name = "MainScreen_Reports_MenuItem";
            this.MainScreen_Reports_MenuItem.Size = new System.Drawing.Size(74, 24);
            this.MainScreen_Reports_MenuItem.Text = "Reports";
            // 
            // MainScreen_AppointmentTypesByMonth_MenuItem
            // 
            this.MainScreen_AppointmentTypesByMonth_MenuItem.Name = "MainScreen_AppointmentTypesByMonth_MenuItem";
            this.MainScreen_AppointmentTypesByMonth_MenuItem.Size = new System.Drawing.Size(288, 26);
            this.MainScreen_AppointmentTypesByMonth_MenuItem.Text = "Appointment Types by Month";
            this.MainScreen_AppointmentTypesByMonth_MenuItem.Click += new System.EventHandler(this.MainScreen_AppointmentTypesByMonth_MenuItem_Click);
            // 
            // MainScreen_SchedulesByCustomer_MenuItem
            // 
            this.MainScreen_SchedulesByCustomer_MenuItem.Name = "MainScreen_SchedulesByCustomer_MenuItem";
            this.MainScreen_SchedulesByCustomer_MenuItem.Size = new System.Drawing.Size(288, 26);
            this.MainScreen_SchedulesByCustomer_MenuItem.Text = "Schedules by Customer";
            this.MainScreen_SchedulesByCustomer_MenuItem.Click += new System.EventHandler(this.MainScreen_SchedulesByCustomer_MenuItem_Click);
            // 
            // MainScreen_SchedulesByUser_MenuItem
            // 
            this.MainScreen_SchedulesByUser_MenuItem.Name = "MainScreen_SchedulesByUser_MenuItem";
            this.MainScreen_SchedulesByUser_MenuItem.Size = new System.Drawing.Size(288, 26);
            this.MainScreen_SchedulesByUser_MenuItem.Text = "Schedules by User";
            this.MainScreen_SchedulesByUser_MenuItem.Click += new System.EventHandler(this.MainScreen_SchedulesByUser_MenuItem_Click);
            // 
            // MainScreen_Config_MenuItem
            // 
            this.MainScreen_Config_MenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MainScreen_Organizations_MenuItem});
            this.MainScreen_Config_MenuItem.Name = "MainScreen_Config_MenuItem";
            this.MainScreen_Config_MenuItem.Size = new System.Drawing.Size(67, 24);
            this.MainScreen_Config_MenuItem.Text = "Config";
            // 
            // MainScreen_Organizations_MenuItem
            // 
            this.MainScreen_Organizations_MenuItem.Name = "MainScreen_Organizations_MenuItem";
            this.MainScreen_Organizations_MenuItem.Size = new System.Drawing.Size(224, 26);
            this.MainScreen_Organizations_MenuItem.Text = "Organizations";
            this.MainScreen_Organizations_MenuItem.Click += new System.EventHandler(this.MainScreen_Organizations_MenuItem_Click);
            // 
            // MainScreen_Exit_MenuItem
            // 
            this.MainScreen_Exit_MenuItem.Name = "MainScreen_Exit_MenuItem";
            this.MainScreen_Exit_MenuItem.Size = new System.Drawing.Size(47, 24);
            this.MainScreen_Exit_MenuItem.Text = "Exit";
            this.MainScreen_Exit_MenuItem.Click += new System.EventHandler(this.MainScreen_Exit_MenuItem_Click);
            // 
            // MainScreen_DatePicker
            // 
            this.MainScreen_DatePicker.Location = new System.Drawing.Point(605, 39);
            this.MainScreen_DatePicker.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MainScreen_DatePicker.Name = "MainScreen_DatePicker";
            this.MainScreen_DatePicker.Size = new System.Drawing.Size(244, 22);
            this.MainScreen_DatePicker.TabIndex = 23;
            this.MainScreen_DatePicker.ValueChanged += new System.EventHandler(this.MainScreen_DatePicker_ValueChanged);
            // 
            // MainScreen_CustomerSearch_Label
            // 
            this.MainScreen_CustomerSearch_Label.AutoSize = true;
            this.MainScreen_CustomerSearch_Label.Location = new System.Drawing.Point(21, 43);
            this.MainScreen_CustomerSearch_Label.Name = "MainScreen_CustomerSearch_Label";
            this.MainScreen_CustomerSearch_Label.Size = new System.Drawing.Size(53, 16);
            this.MainScreen_CustomerSearch_Label.TabIndex = 24;
            this.MainScreen_CustomerSearch_Label.Text = "Search:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Showcard Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(328, 498);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 37);
            this.label1.TabIndex = 25;
            this.label1.Text = "SCHEDULE IT";
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 557);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MainScreen_CustomerSearch_Label);
            this.Controls.Add(this.MainScreen_DatePicker);
            this.Controls.Add(this.MainScreen_Date_Label);
            this.Controls.Add(this.MainScreen_DeleteAppointment_Btn);
            this.Controls.Add(this.MainScreen_EditAppointment_Btn);
            this.Controls.Add(this.MainScreen_AddNewAppointment_Btn);
            this.Controls.Add(this.MainScreen_AppointmentGridView);
            this.Controls.Add(this.MainScreen_DeleteCustomer_Btn);
            this.Controls.Add(this.MainScreen_EditCustomer_Btn);
            this.Controls.Add(this.MainScreen_AddNewCustomer_Btn);
            this.Controls.Add(this.MainScreen_CustomerGridView);
            this.Controls.Add(this.MainScreen_CustomerSearch_Text);
            this.Controls.Add(this.menuStrip1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SCHEDULE IT";
            this.Shown += new System.EventHandler(this.MainScreen_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.MainScreen_CustomerGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainScreen_AppointmentGridView)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox MainScreen_CustomerSearch_Text;
        private System.Windows.Forms.DataGridView MainScreen_CustomerGridView;
        private System.Windows.Forms.Button MainScreen_AddNewCustomer_Btn;
        private System.Windows.Forms.Button MainScreen_EditCustomer_Btn;
        private System.Windows.Forms.Button MainScreen_DeleteCustomer_Btn;
        private System.Windows.Forms.DataGridView MainScreen_AppointmentGridView;
        private System.Windows.Forms.Button MainScreen_AddNewAppointment_Btn;
        private System.Windows.Forms.Button MainScreen_EditAppointment_Btn;
        private System.Windows.Forms.Button MainScreen_DeleteAppointment_Btn;
        private System.Windows.Forms.Label MainScreen_Date_Label;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MainScreen_Reports_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem MainScreen_Config_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem MainScreen_SchedulesByCustomer_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem MainScreen_AppointmentTypesByMonth_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem MainScreen_SchedulesByUser_MenuItem;
        private System.Windows.Forms.DateTimePicker MainScreen_DatePicker;
        private System.Windows.Forms.Label MainScreen_CustomerSearch_Label;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem MainScreen_Exit_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem MainScreen_Organizations_MenuItem;
    }
}

