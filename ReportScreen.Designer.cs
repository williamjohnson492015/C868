namespace C868
{
    partial class ReportScreen
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
            this.ReportScreen_ReportGridView = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ReportScreen_Exit_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.ReportScreen_ReportGridView)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ReportScreen_ReportGridView
            // 
            this.ReportScreen_ReportGridView.AllowUserToAddRows = false;
            this.ReportScreen_ReportGridView.AllowUserToDeleteRows = false;
            this.ReportScreen_ReportGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ReportScreen_ReportGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.ReportScreen_ReportGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ReportScreen_ReportGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.ReportScreen_ReportGridView.EnableHeadersVisualStyles = false;
            this.ReportScreen_ReportGridView.Location = new System.Drawing.Point(12, 42);
            this.ReportScreen_ReportGridView.MultiSelect = false;
            this.ReportScreen_ReportGridView.Name = "ReportScreen_ReportGridView";
            this.ReportScreen_ReportGridView.RowHeadersVisible = false;
            this.ReportScreen_ReportGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.ReportScreen_ReportGridView.RowTemplate.Height = 24;
            this.ReportScreen_ReportGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ReportScreen_ReportGridView.Size = new System.Drawing.Size(853, 503);
            this.ReportScreen_ReportGridView.TabIndex = 12;
            this.ReportScreen_ReportGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.ReportScreen_ReportGridView_DataBindingComplete);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ReportScreen_Exit_MenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(877, 28);
            this.menuStrip1.TabIndex = 22;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ReportScreen_Exit_MenuItem
            // 
            this.ReportScreen_Exit_MenuItem.Name = "ReportScreen_Exit_MenuItem";
            this.ReportScreen_Exit_MenuItem.Size = new System.Drawing.Size(47, 24);
            this.ReportScreen_Exit_MenuItem.Text = "Exit";
            this.ReportScreen_Exit_MenuItem.Click += new System.EventHandler(this.ReportScreen_Exit_MenuItem_Click);
            // 
            // ReportScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 557);
            this.Controls.Add(this.ReportScreen_ReportGridView);
            this.Controls.Add(this.menuStrip1);
            this.Name = "ReportScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Report";
            ((System.ComponentModel.ISupportInitialize)(this.ReportScreen_ReportGridView)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView ReportScreen_ReportGridView;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ReportScreen_Exit_MenuItem;
    }
}

