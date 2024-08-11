using System.ComponentModel;

namespace C868
{
    partial class OrganizationSearchScreen
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
            this.OrganizationSearchScreen_OrganizationSearch_Text = new System.Windows.Forms.TextBox();
            this.OrganizationSearchScreen_OrganizationGridView = new System.Windows.Forms.DataGridView();
            this.OrganizationSearchScreen_AddNewOrganization_Btn = new System.Windows.Forms.Button();
            this.OrganizationSearchScreen_EditOrganization_Btn = new System.Windows.Forms.Button();
            this.OrganizationSearchScreen_DeleteOrganization_Btn = new System.Windows.Forms.Button();
            this.OrganizationSearchScreen_OrganizationSearch_Label = new System.Windows.Forms.Label();
            this.OrganizationSearchScreen_Cancel_Btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.OrganizationSearchScreen_OrganizationGridView)).BeginInit();
            MainScreen.Organizations.ListChanged += new ListChangedEventHandler(Organizations_ListChanged);
            this.SuspendLayout();
            // 
            // OrganizationSearchScreen_OrganizationSearch_Text
            // 
            this.OrganizationSearchScreen_OrganizationSearch_Text.Location = new System.Drawing.Point(103, 20);
            this.OrganizationSearchScreen_OrganizationSearch_Text.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.OrganizationSearchScreen_OrganizationSearch_Text.Name = "OrganizationSearchScreen_OrganizationSearch_Text";
            this.OrganizationSearchScreen_OrganizationSearch_Text.Size = new System.Drawing.Size(209, 22);
            this.OrganizationSearchScreen_OrganizationSearch_Text.TabIndex = 2;
            this.OrganizationSearchScreen_OrganizationSearch_Text.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OrganizationSearchScreen_OrganizationSearch_Text_KeyDown);
            // 
            // OrganizationSearchScreen_OrganizationGridView
            // 
            this.OrganizationSearchScreen_OrganizationGridView.AllowUserToAddRows = false;
            this.OrganizationSearchScreen_OrganizationGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.OrganizationSearchScreen_OrganizationGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.OrganizationSearchScreen_OrganizationGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.OrganizationSearchScreen_OrganizationGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.OrganizationSearchScreen_OrganizationGridView.EnableHeadersVisualStyles = false;
            this.OrganizationSearchScreen_OrganizationGridView.Location = new System.Drawing.Point(25, 46);
            this.OrganizationSearchScreen_OrganizationGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.OrganizationSearchScreen_OrganizationGridView.MultiSelect = false;
            this.OrganizationSearchScreen_OrganizationGridView.Name = "OrganizationSearchScreen_OrganizationGridView";
            this.OrganizationSearchScreen_OrganizationGridView.RowHeadersVisible = false;
            this.OrganizationSearchScreen_OrganizationGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.OrganizationSearchScreen_OrganizationGridView.RowTemplate.Height = 24;
            this.OrganizationSearchScreen_OrganizationGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.OrganizationSearchScreen_OrganizationGridView.Size = new System.Drawing.Size(287, 391);
            this.OrganizationSearchScreen_OrganizationGridView.TabIndex = 12;
            this.OrganizationSearchScreen_OrganizationGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.OrganizationSearchScreen_OrganizationGridView_DataBindingComplete);
            // 
            // OrganizationSearchScreen_AddNewOrganization_Btn
            // 
            this.OrganizationSearchScreen_AddNewOrganization_Btn.Location = new System.Drawing.Point(25, 441);
            this.OrganizationSearchScreen_AddNewOrganization_Btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.OrganizationSearchScreen_AddNewOrganization_Btn.Name = "OrganizationSearchScreen_AddNewOrganization_Btn";
            this.OrganizationSearchScreen_AddNewOrganization_Btn.Size = new System.Drawing.Size(287, 30);
            this.OrganizationSearchScreen_AddNewOrganization_Btn.TabIndex = 13;
            this.OrganizationSearchScreen_AddNewOrganization_Btn.Text = "+ Add New Organization";
            this.OrganizationSearchScreen_AddNewOrganization_Btn.UseVisualStyleBackColor = true;
            this.OrganizationSearchScreen_AddNewOrganization_Btn.Click += new System.EventHandler(this.OrganizationSearchScreen_AddNewOrganization_Btn_Click);
            // 
            // OrganizationSearchScreen_EditOrganization_Btn
            // 
            this.OrganizationSearchScreen_EditOrganization_Btn.Location = new System.Drawing.Point(25, 475);
            this.OrganizationSearchScreen_EditOrganization_Btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.OrganizationSearchScreen_EditOrganization_Btn.Name = "OrganizationSearchScreen_EditOrganization_Btn";
            this.OrganizationSearchScreen_EditOrganization_Btn.Size = new System.Drawing.Size(133, 30);
            this.OrganizationSearchScreen_EditOrganization_Btn.TabIndex = 14;
            this.OrganizationSearchScreen_EditOrganization_Btn.Text = "Edit Organization";
            this.OrganizationSearchScreen_EditOrganization_Btn.UseVisualStyleBackColor = true;
            this.OrganizationSearchScreen_EditOrganization_Btn.Click += new System.EventHandler(this.OrganizationSearchScreen_EditOrganization_Btn_Click);
            // 
            // OrganizationSearchScreen_DeleteOrganization_Btn
            // 
            this.OrganizationSearchScreen_DeleteOrganization_Btn.Location = new System.Drawing.Point(164, 475);
            this.OrganizationSearchScreen_DeleteOrganization_Btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.OrganizationSearchScreen_DeleteOrganization_Btn.Name = "OrganizationSearchScreen_DeleteOrganization_Btn";
            this.OrganizationSearchScreen_DeleteOrganization_Btn.Size = new System.Drawing.Size(148, 30);
            this.OrganizationSearchScreen_DeleteOrganization_Btn.TabIndex = 15;
            this.OrganizationSearchScreen_DeleteOrganization_Btn.Text = "Delete Organization";
            this.OrganizationSearchScreen_DeleteOrganization_Btn.UseVisualStyleBackColor = true;
            this.OrganizationSearchScreen_DeleteOrganization_Btn.Click += new System.EventHandler(this.OrganizationSearchScreen_DeleteOrganization_Btn_Click);
            // 
            // OrganizationSearchScreen_OrganizationSearch_Label
            // 
            this.OrganizationSearchScreen_OrganizationSearch_Label.AutoSize = true;
            this.OrganizationSearchScreen_OrganizationSearch_Label.Location = new System.Drawing.Point(22, 23);
            this.OrganizationSearchScreen_OrganizationSearch_Label.Name = "OrganizationSearchScreen_OrganizationSearch_Label";
            this.OrganizationSearchScreen_OrganizationSearch_Label.Size = new System.Drawing.Size(53, 16);
            this.OrganizationSearchScreen_OrganizationSearch_Label.TabIndex = 24;
            this.OrganizationSearchScreen_OrganizationSearch_Label.Text = "Search:";
            // 
            // OrganizationSearchScreen_Cancel_Btn
            // 
            this.OrganizationSearchScreen_Cancel_Btn.Location = new System.Drawing.Point(25, 509);
            this.OrganizationSearchScreen_Cancel_Btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.OrganizationSearchScreen_Cancel_Btn.Name = "OrganizationSearchScreen_Cancel_Btn";
            this.OrganizationSearchScreen_Cancel_Btn.Size = new System.Drawing.Size(287, 30);
            this.OrganizationSearchScreen_Cancel_Btn.TabIndex = 25;
            this.OrganizationSearchScreen_Cancel_Btn.Text = "Cancel";
            this.OrganizationSearchScreen_Cancel_Btn.UseVisualStyleBackColor = true;
            this.OrganizationSearchScreen_Cancel_Btn.Click += new System.EventHandler(this.OrganizationSearchScreen_Cancel_Btn_Click);
            // 
            // OrganizationSearchScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 557);
            this.Controls.Add(this.OrganizationSearchScreen_Cancel_Btn);
            this.Controls.Add(this.OrganizationSearchScreen_OrganizationSearch_Label);
            this.Controls.Add(this.OrganizationSearchScreen_DeleteOrganization_Btn);
            this.Controls.Add(this.OrganizationSearchScreen_EditOrganization_Btn);
            this.Controls.Add(this.OrganizationSearchScreen_AddNewOrganization_Btn);
            this.Controls.Add(this.OrganizationSearchScreen_OrganizationGridView);
            this.Controls.Add(this.OrganizationSearchScreen_OrganizationSearch_Text);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "OrganizationSearchScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Organization Search";
            ((System.ComponentModel.ISupportInitialize)(this.OrganizationSearchScreen_OrganizationGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox OrganizationSearchScreen_OrganizationSearch_Text;
        private System.Windows.Forms.DataGridView OrganizationSearchScreen_OrganizationGridView;
        private System.Windows.Forms.Button OrganizationSearchScreen_AddNewOrganization_Btn;
        private System.Windows.Forms.Button OrganizationSearchScreen_EditOrganization_Btn;
        private System.Windows.Forms.Button OrganizationSearchScreen_DeleteOrganization_Btn;
        private System.Windows.Forms.Label OrganizationSearchScreen_OrganizationSearch_Label;
        private System.Windows.Forms.Button OrganizationSearchScreen_Cancel_Btn;
    }
}

