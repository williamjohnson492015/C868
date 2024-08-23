using System.ComponentModel;

namespace C868
{
    partial class OrganizationScreen
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.OrganizationScreen_OrganizationID_Text = new System.Windows.Forms.TextBox();
            this.OrganizationScreen_Save_Btn = new System.Windows.Forms.Button();
            this.OrganizationScreen_Cancel_Btn = new System.Windows.Forms.Button();
            this.OrganizationScreen_OrganizationID_Label = new System.Windows.Forms.Label();
            this.OrganizationScreen_BillingContactName_Label = new System.Windows.Forms.Label();
            this.OrganizationScreen_BillingContactPhone_Label = new System.Windows.Forms.Label();
            this.OrganizationScreen_OrganizationName_Label = new System.Windows.Forms.Label();
            this.OrganizationScreen_BillingContactEmail_Label = new System.Windows.Forms.Label();
            this.OrganizationScreen_Active_Label = new System.Windows.Forms.Label();
            this.OrganizationScreen_Active_CheckBox = new System.Windows.Forms.CheckBox();
            this.OrganizationScreen_BillingContactName_Text = new System.Windows.Forms.TextBox();
            this.OrganizationScreen_BillingContactPhone_Text = new System.Windows.Forms.TextBox();
            this.OrganizationScreen_BillingContactEmail_Text = new System.Windows.Forms.TextBox();
            this.OrganizationScreen_Notes_Label = new System.Windows.Forms.Label();
            this.OrganizationScreen_OrganizationName_Text = new System.Windows.Forms.TextBox();
            this.OrganizationScreen_Notes_Text = new System.Windows.Forms.TextBox();
            this.OrganizationScreen_BillingContractGridView = new System.Windows.Forms.DataGridView();
            this.OrganizationScreen_BillingContracts_Label = new System.Windows.Forms.Label();
            this.OrganizationScreen_AddBillingContract_Btn = new System.Windows.Forms.Button();
            this.OrganizationScreen_EditBillingContract_Btn = new System.Windows.Forms.Button();
            this.OrganizationScreen_DeleteBillingContract_Btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.OrganizationScreen_BillingContractGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // OrganizationScreen_OrganizationID_Text
            // 
            this.OrganizationScreen_OrganizationID_Text.Location = new System.Drawing.Point(168, 23);
            this.OrganizationScreen_OrganizationID_Text.Name = "OrganizationScreen_OrganizationID_Text";
            this.OrganizationScreen_OrganizationID_Text.ReadOnly = true;
            this.OrganizationScreen_OrganizationID_Text.Size = new System.Drawing.Size(85, 22);
            this.OrganizationScreen_OrganizationID_Text.TabIndex = 1;
            // 
            // OrganizationScreen_Save_Btn
            // 
            this.OrganizationScreen_Save_Btn.Location = new System.Drawing.Point(577, 454);
            this.OrganizationScreen_Save_Btn.Name = "OrganizationScreen_Save_Btn";
            this.OrganizationScreen_Save_Btn.Size = new System.Drawing.Size(118, 30);
            this.OrganizationScreen_Save_Btn.TabIndex = 11;
            this.OrganizationScreen_Save_Btn.Text = "Save";
            this.OrganizationScreen_Save_Btn.UseVisualStyleBackColor = true;
            this.OrganizationScreen_Save_Btn.Click += new System.EventHandler(this.OrganizationScreen_Save_Btn_Click);
            // 
            // OrganizationScreen_Cancel_Btn
            // 
            this.OrganizationScreen_Cancel_Btn.Location = new System.Drawing.Point(701, 454);
            this.OrganizationScreen_Cancel_Btn.Name = "OrganizationScreen_Cancel_Btn";
            this.OrganizationScreen_Cancel_Btn.Size = new System.Drawing.Size(118, 30);
            this.OrganizationScreen_Cancel_Btn.TabIndex = 12;
            this.OrganizationScreen_Cancel_Btn.Text = "Cancel";
            this.OrganizationScreen_Cancel_Btn.UseVisualStyleBackColor = true;
            this.OrganizationScreen_Cancel_Btn.Click += new System.EventHandler(this.OrganizationScreen_Cancel_Btn_Click);
            // 
            // OrganizationScreen_OrganizationID_Label
            // 
            this.OrganizationScreen_OrganizationID_Label.AutoSize = true;
            this.OrganizationScreen_OrganizationID_Label.Location = new System.Drawing.Point(48, 26);
            this.OrganizationScreen_OrganizationID_Label.Name = "OrganizationScreen_OrganizationID_Label";
            this.OrganizationScreen_OrganizationID_Label.Size = new System.Drawing.Size(101, 16);
            this.OrganizationScreen_OrganizationID_Label.TabIndex = 13;
            this.OrganizationScreen_OrganizationID_Label.Text = "Organization ID:";
            // 
            // OrganizationScreen_BillingContactName_Label
            // 
            this.OrganizationScreen_BillingContactName_Label.AutoSize = true;
            this.OrganizationScreen_BillingContactName_Label.Location = new System.Drawing.Point(15, 111);
            this.OrganizationScreen_BillingContactName_Label.Name = "OrganizationScreen_BillingContactName_Label";
            this.OrganizationScreen_BillingContactName_Label.Size = new System.Drawing.Size(134, 16);
            this.OrganizationScreen_BillingContactName_Label.TabIndex = 16;
            this.OrganizationScreen_BillingContactName_Label.Text = "Billing Contact Name:";
            // 
            // OrganizationScreen_BillingContactPhone_Label
            // 
            this.OrganizationScreen_BillingContactPhone_Label.AutoSize = true;
            this.OrganizationScreen_BillingContactPhone_Label.Location = new System.Drawing.Point(13, 155);
            this.OrganizationScreen_BillingContactPhone_Label.Name = "OrganizationScreen_BillingContactPhone_Label";
            this.OrganizationScreen_BillingContactPhone_Label.Size = new System.Drawing.Size(136, 16);
            this.OrganizationScreen_BillingContactPhone_Label.TabIndex = 17;
            this.OrganizationScreen_BillingContactPhone_Label.Text = "Billing Contact Phone:";
            // 
            // OrganizationScreen_OrganizationName_Label
            // 
            this.OrganizationScreen_OrganizationName_Label.AutoSize = true;
            this.OrganizationScreen_OrganizationName_Label.Location = new System.Drawing.Point(24, 66);
            this.OrganizationScreen_OrganizationName_Label.Name = "OrganizationScreen_OrganizationName_Label";
            this.OrganizationScreen_OrganizationName_Label.Size = new System.Drawing.Size(125, 16);
            this.OrganizationScreen_OrganizationName_Label.TabIndex = 15;
            this.OrganizationScreen_OrganizationName_Label.Text = "Organization Name:";
            // 
            // OrganizationScreen_BillingContactEmail_Label
            // 
            this.OrganizationScreen_BillingContactEmail_Label.AutoSize = true;
            this.OrganizationScreen_BillingContactEmail_Label.Location = new System.Drawing.Point(18, 198);
            this.OrganizationScreen_BillingContactEmail_Label.Name = "OrganizationScreen_BillingContactEmail_Label";
            this.OrganizationScreen_BillingContactEmail_Label.Size = new System.Drawing.Size(131, 16);
            this.OrganizationScreen_BillingContactEmail_Label.TabIndex = 18;
            this.OrganizationScreen_BillingContactEmail_Label.Text = "Billing Contact Email:";
            // 
            // OrganizationScreen_Active_Label
            // 
            this.OrganizationScreen_Active_Label.AutoSize = true;
            this.OrganizationScreen_Active_Label.Location = new System.Drawing.Point(310, 27);
            this.OrganizationScreen_Active_Label.Name = "OrganizationScreen_Active_Label";
            this.OrganizationScreen_Active_Label.Size = new System.Drawing.Size(47, 16);
            this.OrganizationScreen_Active_Label.TabIndex = 14;
            this.OrganizationScreen_Active_Label.Text = "Active:";
            // 
            // OrganizationScreen_Active_CheckBox
            // 
            this.OrganizationScreen_Active_CheckBox.AutoSize = true;
            this.OrganizationScreen_Active_CheckBox.Checked = true;
            this.OrganizationScreen_Active_CheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.OrganizationScreen_Active_CheckBox.Location = new System.Drawing.Point(363, 28);
            this.OrganizationScreen_Active_CheckBox.Name = "OrganizationScreen_Active_CheckBox";
            this.OrganizationScreen_Active_CheckBox.Size = new System.Drawing.Size(18, 17);
            this.OrganizationScreen_Active_CheckBox.TabIndex = 2;
            this.OrganizationScreen_Active_CheckBox.UseVisualStyleBackColor = true;
            // 
            // OrganizationScreen_BillingContactName_Text
            // 
            this.OrganizationScreen_BillingContactName_Text.Location = new System.Drawing.Point(168, 108);
            this.OrganizationScreen_BillingContactName_Text.Name = "OrganizationScreen_BillingContactName_Text";
            this.OrganizationScreen_BillingContactName_Text.Size = new System.Drawing.Size(213, 22);
            this.OrganizationScreen_BillingContactName_Text.TabIndex = 4;
            // 
            // OrganizationScreen_BillingContactPhone_Text
            // 
            this.OrganizationScreen_BillingContactPhone_Text.Location = new System.Drawing.Point(168, 152);
            this.OrganizationScreen_BillingContactPhone_Text.Name = "OrganizationScreen_BillingContactPhone_Text";
            this.OrganizationScreen_BillingContactPhone_Text.Size = new System.Drawing.Size(213, 22);
            this.OrganizationScreen_BillingContactPhone_Text.TabIndex = 5;
            // 
            // OrganizationScreen_BillingContactEmail_Text
            // 
            this.OrganizationScreen_BillingContactEmail_Text.Location = new System.Drawing.Point(168, 195);
            this.OrganizationScreen_BillingContactEmail_Text.Name = "OrganizationScreen_BillingContactEmail_Text";
            this.OrganizationScreen_BillingContactEmail_Text.Size = new System.Drawing.Size(213, 22);
            this.OrganizationScreen_BillingContactEmail_Text.TabIndex = 6;
            // 
            // OrganizationScreen_Notes_Label
            // 
            this.OrganizationScreen_Notes_Label.AutoSize = true;
            this.OrganizationScreen_Notes_Label.Location = new System.Drawing.Point(387, 26);
            this.OrganizationScreen_Notes_Label.Name = "OrganizationScreen_Notes_Label";
            this.OrganizationScreen_Notes_Label.Size = new System.Drawing.Size(46, 16);
            this.OrganizationScreen_Notes_Label.TabIndex = 20;
            this.OrganizationScreen_Notes_Label.Text = "Notes:";
            // 
            // OrganizationScreen_OrganizationName_Text
            // 
            this.OrganizationScreen_OrganizationName_Text.Location = new System.Drawing.Point(168, 63);
            this.OrganizationScreen_OrganizationName_Text.Name = "OrganizationScreen_OrganizationName_Text";
            this.OrganizationScreen_OrganizationName_Text.Size = new System.Drawing.Size(213, 22);
            this.OrganizationScreen_OrganizationName_Text.TabIndex = 3;
            // 
            // OrganizationScreen_Notes_Text
            // 
            this.OrganizationScreen_Notes_Text.Location = new System.Drawing.Point(441, 23);
            this.OrganizationScreen_Notes_Text.Multiline = true;
            this.OrganizationScreen_Notes_Text.Name = "OrganizationScreen_Notes_Text";
            this.OrganizationScreen_Notes_Text.Size = new System.Drawing.Size(380, 236);
            this.OrganizationScreen_Notes_Text.TabIndex = 7;
            // 
            // OrganizationScreen_BillingContractGridView
            // 
            this.OrganizationScreen_BillingContractGridView.AllowUserToAddRows = false;
            this.OrganizationScreen_BillingContractGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.OrganizationScreen_BillingContractGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.OrganizationScreen_BillingContractGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.OrganizationScreen_BillingContractGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.OrganizationScreen_BillingContractGridView.EnableHeadersVisualStyles = false;
            this.OrganizationScreen_BillingContractGridView.Location = new System.Drawing.Point(47, 276);
            this.OrganizationScreen_BillingContractGridView.MultiSelect = false;
            this.OrganizationScreen_BillingContractGridView.Name = "OrganizationScreen_BillingContractGridView";
            this.OrganizationScreen_BillingContractGridView.RowHeadersVisible = false;
            this.OrganizationScreen_BillingContractGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.OrganizationScreen_BillingContractGridView.RowTemplate.Height = 24;
            this.OrganizationScreen_BillingContractGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.OrganizationScreen_BillingContractGridView.Size = new System.Drawing.Size(772, 136);
            this.OrganizationScreen_BillingContractGridView.TabIndex = 21;
            // 
            // OrganizationScreen_BillingContracts_Label
            // 
            this.OrganizationScreen_BillingContracts_Label.AutoSize = true;
            this.OrganizationScreen_BillingContracts_Label.Location = new System.Drawing.Point(44, 243);
            this.OrganizationScreen_BillingContracts_Label.Name = "OrganizationScreen_BillingContracts_Label";
            this.OrganizationScreen_BillingContracts_Label.Size = new System.Drawing.Size(105, 16);
            this.OrganizationScreen_BillingContracts_Label.TabIndex = 19;
            this.OrganizationScreen_BillingContracts_Label.Text = "Billing Contracts:";
            // 
            // OrganizationScreen_AddBillingContract_Btn
            // 
            this.OrganizationScreen_AddBillingContract_Btn.Location = new System.Drawing.Point(47, 418);
            this.OrganizationScreen_AddBillingContract_Btn.Name = "OrganizationScreen_AddBillingContract_Btn";
            this.OrganizationScreen_AddBillingContract_Btn.Size = new System.Drawing.Size(334, 30);
            this.OrganizationScreen_AddBillingContract_Btn.TabIndex = 8;
            this.OrganizationScreen_AddBillingContract_Btn.Text = "+Add Billing Contract";
            this.OrganizationScreen_AddBillingContract_Btn.UseVisualStyleBackColor = true;
            this.OrganizationScreen_AddBillingContract_Btn.Click += new System.EventHandler(this.OrganizationScreen_AddBillingContract_Btn_Click);
            // 
            // OrganizationScreen_EditBillingContract_Btn
            // 
            this.OrganizationScreen_EditBillingContract_Btn.Location = new System.Drawing.Point(47, 454);
            this.OrganizationScreen_EditBillingContract_Btn.Name = "OrganizationScreen_EditBillingContract_Btn";
            this.OrganizationScreen_EditBillingContract_Btn.Size = new System.Drawing.Size(155, 30);
            this.OrganizationScreen_EditBillingContract_Btn.TabIndex = 9;
            this.OrganizationScreen_EditBillingContract_Btn.Text = "Edit Billing Contract";
            this.OrganizationScreen_EditBillingContract_Btn.UseVisualStyleBackColor = true;
            this.OrganizationScreen_EditBillingContract_Btn.Click += new System.EventHandler(this.OrganizationScreen_EditBillingContract_Btn_Click);
            // 
            // OrganizationScreen_DeleteBillingContract_Btn
            // 
            this.OrganizationScreen_DeleteBillingContract_Btn.Location = new System.Drawing.Point(208, 454);
            this.OrganizationScreen_DeleteBillingContract_Btn.Name = "OrganizationScreen_DeleteBillingContract_Btn";
            this.OrganizationScreen_DeleteBillingContract_Btn.Size = new System.Drawing.Size(173, 30);
            this.OrganizationScreen_DeleteBillingContract_Btn.TabIndex = 10;
            this.OrganizationScreen_DeleteBillingContract_Btn.Text = "Delete Billing Contract";
            this.OrganizationScreen_DeleteBillingContract_Btn.UseVisualStyleBackColor = true;
            this.OrganizationScreen_DeleteBillingContract_Btn.Click += new System.EventHandler(this.OrganizationScreen_DeleteBillingContract_Btn_Click);
            // 
            // OrganizationScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(833, 496);
            this.Controls.Add(this.OrganizationScreen_DeleteBillingContract_Btn);
            this.Controls.Add(this.OrganizationScreen_EditBillingContract_Btn);
            this.Controls.Add(this.OrganizationScreen_AddBillingContract_Btn);
            this.Controls.Add(this.OrganizationScreen_BillingContracts_Label);
            this.Controls.Add(this.OrganizationScreen_BillingContractGridView);
            this.Controls.Add(this.OrganizationScreen_Notes_Text);
            this.Controls.Add(this.OrganizationScreen_OrganizationName_Text);
            this.Controls.Add(this.OrganizationScreen_Notes_Label);
            this.Controls.Add(this.OrganizationScreen_BillingContactEmail_Text);
            this.Controls.Add(this.OrganizationScreen_BillingContactPhone_Text);
            this.Controls.Add(this.OrganizationScreen_BillingContactName_Text);
            this.Controls.Add(this.OrganizationScreen_Active_CheckBox);
            this.Controls.Add(this.OrganizationScreen_Active_Label);
            this.Controls.Add(this.OrganizationScreen_BillingContactEmail_Label);
            this.Controls.Add(this.OrganizationScreen_OrganizationName_Label);
            this.Controls.Add(this.OrganizationScreen_BillingContactPhone_Label);
            this.Controls.Add(this.OrganizationScreen_BillingContactName_Label);
            this.Controls.Add(this.OrganizationScreen_OrganizationID_Label);
            this.Controls.Add(this.OrganizationScreen_Cancel_Btn);
            this.Controls.Add(this.OrganizationScreen_Save_Btn);
            this.Controls.Add(this.OrganizationScreen_OrganizationID_Text);
            this.Name = "OrganizationScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Organization";
            ((System.ComponentModel.ISupportInitialize)(this.OrganizationScreen_BillingContractGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox OrganizationScreen_OrganizationID_Text;
        private System.Windows.Forms.Button OrganizationScreen_Save_Btn;
        private System.Windows.Forms.Button OrganizationScreen_Cancel_Btn;
        private System.Windows.Forms.Label OrganizationScreen_OrganizationID_Label;
        private System.Windows.Forms.Label OrganizationScreen_BillingContactName_Label;
        private System.Windows.Forms.Label OrganizationScreen_BillingContactPhone_Label;
        private System.Windows.Forms.Label OrganizationScreen_OrganizationName_Label;
        private System.Windows.Forms.Label OrganizationScreen_BillingContactEmail_Label;
        private System.Windows.Forms.Label OrganizationScreen_Active_Label;
        private System.Windows.Forms.CheckBox OrganizationScreen_Active_CheckBox;
        private System.Windows.Forms.TextBox OrganizationScreen_BillingContactName_Text;
        private System.Windows.Forms.TextBox OrganizationScreen_BillingContactPhone_Text;
        private System.Windows.Forms.TextBox OrganizationScreen_BillingContactEmail_Text;
        private System.Windows.Forms.Label OrganizationScreen_Notes_Label;
        private System.Windows.Forms.TextBox OrganizationScreen_OrganizationName_Text;
        private System.Windows.Forms.TextBox OrganizationScreen_Notes_Text;
        private System.Windows.Forms.DataGridView OrganizationScreen_BillingContractGridView;
        private System.Windows.Forms.Label OrganizationScreen_BillingContracts_Label;
        private System.Windows.Forms.Button OrganizationScreen_AddBillingContract_Btn;
        private System.Windows.Forms.Button OrganizationScreen_EditBillingContract_Btn;
        private System.Windows.Forms.Button OrganizationScreen_DeleteBillingContract_Btn;
    }
}

