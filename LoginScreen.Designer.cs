namespace C868
{
    partial class LoginScreen
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
            this.LoginScreen_Username_Label = new System.Windows.Forms.Label();
            this.LoginScreen_Password_Label = new System.Windows.Forms.Label();
            this.LoginScreen_Username_Text = new System.Windows.Forms.TextBox();
            this.LoginScreen_Password_Text = new System.Windows.Forms.TextBox();
            this.LoginScreen_Submit_Btn = new System.Windows.Forms.Button();
            this.LoginScreen_Cancel_Btn = new System.Windows.Forms.Button();
            this.LoginScreen_Location_Label = new System.Windows.Forms.Label();
            this.LoginScreen_English_Label = new System.Windows.Forms.Label();
            this.LoginScreen_Divider_Label = new System.Windows.Forms.Label();
            this.LoginScreen_Czech_Label = new System.Windows.Forms.Label();
            this.LoginScreen_Location_Derived = new System.Windows.Forms.Label();
            this.LoginScreen_Title_Label = new System.Windows.Forms.Label();
            this.LoginScreen_Error_Label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LoginScreen_Username_Label
            // 
            this.LoginScreen_Username_Label.AutoSize = true;
            this.LoginScreen_Username_Label.Location = new System.Drawing.Point(40, 106);
            this.LoginScreen_Username_Label.Name = "LoginScreen_Username_Label";
            this.LoginScreen_Username_Label.Size = new System.Drawing.Size(73, 16);
            this.LoginScreen_Username_Label.TabIndex = 0;
            this.LoginScreen_Username_Label.Text = "Username:";
            // 
            // LoginScreen_Password_Label
            // 
            this.LoginScreen_Password_Label.AutoSize = true;
            this.LoginScreen_Password_Label.Location = new System.Drawing.Point(43, 166);
            this.LoginScreen_Password_Label.Name = "LoginScreen_Password_Label";
            this.LoginScreen_Password_Label.Size = new System.Drawing.Size(70, 16);
            this.LoginScreen_Password_Label.TabIndex = 1;
            this.LoginScreen_Password_Label.Text = "Password:";
            // 
            // LoginScreen_Username_Text
            // 
            this.LoginScreen_Username_Text.Location = new System.Drawing.Point(173, 103);
            this.LoginScreen_Username_Text.Name = "LoginScreen_Username_Text";
            this.LoginScreen_Username_Text.Size = new System.Drawing.Size(210, 22);
            this.LoginScreen_Username_Text.TabIndex = 2;
            // 
            // LoginScreen_Password_Text
            // 
            this.LoginScreen_Password_Text.Location = new System.Drawing.Point(173, 163);
            this.LoginScreen_Password_Text.Name = "LoginScreen_Password_Text";
            this.LoginScreen_Password_Text.PasswordChar = '*';
            this.LoginScreen_Password_Text.Size = new System.Drawing.Size(210, 22);
            this.LoginScreen_Password_Text.TabIndex = 3;
            this.LoginScreen_Password_Text.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LoginScreen_Password_Text_KeyDown);
            // 
            // LoginScreen_Submit_Btn
            // 
            this.LoginScreen_Submit_Btn.Location = new System.Drawing.Point(173, 244);
            this.LoginScreen_Submit_Btn.Name = "LoginScreen_Submit_Btn";
            this.LoginScreen_Submit_Btn.Size = new System.Drawing.Size(75, 30);
            this.LoginScreen_Submit_Btn.TabIndex = 4;
            this.LoginScreen_Submit_Btn.Text = "Submit";
            this.LoginScreen_Submit_Btn.UseVisualStyleBackColor = true;
            this.LoginScreen_Submit_Btn.Click += new System.EventHandler(this.LoginScreen_Submit_Btn_Click);
            // 
            // LoginScreen_Cancel_Btn
            // 
            this.LoginScreen_Cancel_Btn.Location = new System.Drawing.Point(308, 244);
            this.LoginScreen_Cancel_Btn.Name = "LoginScreen_Cancel_Btn";
            this.LoginScreen_Cancel_Btn.Size = new System.Drawing.Size(75, 30);
            this.LoginScreen_Cancel_Btn.TabIndex = 5;
            this.LoginScreen_Cancel_Btn.Text = "Cancel";
            this.LoginScreen_Cancel_Btn.UseVisualStyleBackColor = true;
            this.LoginScreen_Cancel_Btn.Click += new System.EventHandler(this.LoginScreen_Cancel_Btn_Click);
            // 
            // LoginScreen_Location_Label
            // 
            this.LoginScreen_Location_Label.AutoSize = true;
            this.LoginScreen_Location_Label.Location = new System.Drawing.Point(337, 313);
            this.LoginScreen_Location_Label.Name = "LoginScreen_Location_Label";
            this.LoginScreen_Location_Label.Size = new System.Drawing.Size(61, 16);
            this.LoginScreen_Location_Label.TabIndex = 6;
            this.LoginScreen_Location_Label.Text = "Location:";
            // 
            // LoginScreen_English_Label
            // 
            this.LoginScreen_English_Label.AutoSize = true;
            this.LoginScreen_English_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginScreen_English_Label.Location = new System.Drawing.Point(12, 313);
            this.LoginScreen_English_Label.Name = "LoginScreen_English_Label";
            this.LoginScreen_English_Label.Size = new System.Drawing.Size(58, 16);
            this.LoginScreen_English_Label.TabIndex = 7;
            this.LoginScreen_English_Label.Text = "English";
            this.LoginScreen_English_Label.Click += new System.EventHandler(this.LoginScreen_English_Label_Click);
            // 
            // LoginScreen_Divider_Label
            // 
            this.LoginScreen_Divider_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginScreen_Divider_Label.Location = new System.Drawing.Point(88, 308);
            this.LoginScreen_Divider_Label.Name = "LoginScreen_Divider_Label";
            this.LoginScreen_Divider_Label.Size = new System.Drawing.Size(13, 20);
            this.LoginScreen_Divider_Label.TabIndex = 8;
            this.LoginScreen_Divider_Label.Text = "|";
            // 
            // LoginScreen_Czech_Label
            // 
            this.LoginScreen_Czech_Label.AutoSize = true;
            this.LoginScreen_Czech_Label.Location = new System.Drawing.Point(116, 313);
            this.LoginScreen_Czech_Label.Name = "LoginScreen_Czech_Label";
            this.LoginScreen_Czech_Label.Size = new System.Drawing.Size(44, 16);
            this.LoginScreen_Czech_Label.TabIndex = 9;
            this.LoginScreen_Czech_Label.Text = "Czech";
            this.LoginScreen_Czech_Label.Click += new System.EventHandler(this.LoginScreen_Czech_Label_Click);
            // 
            // LoginScreen_Location_Derived
            // 
            this.LoginScreen_Location_Derived.AutoSize = true;
            this.LoginScreen_Location_Derived.Location = new System.Drawing.Point(404, 313);
            this.LoginScreen_Location_Derived.Name = "LoginScreen_Location_Derived";
            this.LoginScreen_Location_Derived.Size = new System.Drawing.Size(80, 16);
            this.LoginScreen_Location_Derived.TabIndex = 10;
            this.LoginScreen_Location_Derived.Text = "Unavailable";
            // 
            // LoginScreen_Title_Label
            // 
            this.LoginScreen_Title_Label.AutoSize = true;
            this.LoginScreen_Title_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginScreen_Title_Label.Location = new System.Drawing.Point(226, 26);
            this.LoginScreen_Title_Label.Name = "LoginScreen_Title_Label";
            this.LoginScreen_Title_Label.Size = new System.Drawing.Size(87, 29);
            this.LoginScreen_Title_Label.TabIndex = 11;
            this.LoginScreen_Title_Label.Text = "Sign In";
            // 
            // LoginScreen_Error_Label
            // 
            this.LoginScreen_Error_Label.AutoSize = true;
            this.LoginScreen_Error_Label.ForeColor = System.Drawing.Color.Red;
            this.LoginScreen_Error_Label.Location = new System.Drawing.Point(170, 208);
            this.LoginScreen_Error_Label.Name = "LoginScreen_Error_Label";
            this.LoginScreen_Error_Label.Size = new System.Drawing.Size(0, 16);
            this.LoginScreen_Error_Label.TabIndex = 12;
            // 
            // LoginScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 351);
            this.Controls.Add(this.LoginScreen_Error_Label);
            this.Controls.Add(this.LoginScreen_Title_Label);
            this.Controls.Add(this.LoginScreen_Location_Derived);
            this.Controls.Add(this.LoginScreen_Czech_Label);
            this.Controls.Add(this.LoginScreen_Divider_Label);
            this.Controls.Add(this.LoginScreen_English_Label);
            this.Controls.Add(this.LoginScreen_Location_Label);
            this.Controls.Add(this.LoginScreen_Cancel_Btn);
            this.Controls.Add(this.LoginScreen_Submit_Btn);
            this.Controls.Add(this.LoginScreen_Password_Text);
            this.Controls.Add(this.LoginScreen_Username_Text);
            this.Controls.Add(this.LoginScreen_Password_Label);
            this.Controls.Add(this.LoginScreen_Username_Label);
            this.Name = "LoginScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LoginScreen_Username_Label;
        private System.Windows.Forms.Label LoginScreen_Password_Label;
        private System.Windows.Forms.TextBox LoginScreen_Username_Text;
        private System.Windows.Forms.TextBox LoginScreen_Password_Text;
        private System.Windows.Forms.Button LoginScreen_Submit_Btn;
        private System.Windows.Forms.Button LoginScreen_Cancel_Btn;
        private System.Windows.Forms.Label LoginScreen_Location_Label;
        private System.Windows.Forms.Label LoginScreen_English_Label;
        private System.Windows.Forms.Label LoginScreen_Divider_Label;
        private System.Windows.Forms.Label LoginScreen_Czech_Label;
        private System.Windows.Forms.Label LoginScreen_Location_Derived;
        private System.Windows.Forms.Label LoginScreen_Title_Label;
        private System.Windows.Forms.Label LoginScreen_Error_Label;
    }
}

