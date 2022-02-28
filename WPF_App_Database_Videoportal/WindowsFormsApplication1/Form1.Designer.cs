namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tb_login = new MetroFramework.Controls.MetroTextBox();
            this.tb_password = new MetroFramework.Controls.MetroTextBox();
            this.btn_enter = new MetroFramework.Controls.MetroButton();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tb_login
            // 
            // 
            // 
            // 
            this.tb_login.CustomButton.Image = null;
            this.tb_login.CustomButton.Location = new System.Drawing.Point(84, 1);
            this.tb_login.CustomButton.Name = "";
            this.tb_login.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.tb_login.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tb_login.CustomButton.TabIndex = 1;
            this.tb_login.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tb_login.CustomButton.UseSelectable = true;
            this.tb_login.CustomButton.Visible = false;
            this.tb_login.Lines = new string[0];
            this.tb_login.Location = new System.Drawing.Point(167, 79);
            this.tb_login.MaxLength = 32767;
            this.tb_login.Name = "tb_login";
            this.tb_login.PasswordChar = '\0';
            this.tb_login.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tb_login.SelectedText = "";
            this.tb_login.SelectionLength = 0;
            this.tb_login.SelectionStart = 0;
            this.tb_login.ShortcutsEnabled = true;
            this.tb_login.ShowClearButton = true;
            this.tb_login.Size = new System.Drawing.Size(106, 23);
            this.tb_login.TabIndex = 0;
            this.tb_login.UseSelectable = true;
            this.tb_login.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tb_login.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // tb_password
            // 
            // 
            // 
            // 
            this.tb_password.CustomButton.Image = null;
            this.tb_password.CustomButton.Location = new System.Drawing.Point(84, 1);
            this.tb_password.CustomButton.Name = "";
            this.tb_password.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.tb_password.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tb_password.CustomButton.TabIndex = 1;
            this.tb_password.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tb_password.CustomButton.UseSelectable = true;
            this.tb_password.CustomButton.Visible = false;
            this.tb_password.Lines = new string[0];
            this.tb_password.Location = new System.Drawing.Point(167, 118);
            this.tb_password.MaxLength = 32767;
            this.tb_password.Name = "tb_password";
            this.tb_password.PasswordChar = '*';
            this.tb_password.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tb_password.SelectedText = "";
            this.tb_password.SelectionLength = 0;
            this.tb_password.SelectionStart = 0;
            this.tb_password.ShortcutsEnabled = true;
            this.tb_password.ShowClearButton = true;
            this.tb_password.Size = new System.Drawing.Size(106, 23);
            this.tb_password.TabIndex = 1;
            this.tb_password.UseSelectable = true;
            this.tb_password.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tb_password.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btn_enter
            // 
            this.btn_enter.Location = new System.Drawing.Point(74, 197);
            this.btn_enter.Name = "btn_enter";
            this.btn_enter.Size = new System.Drawing.Size(75, 23);
            this.btn_enter.TabIndex = 2;
            this.btn_enter.Text = "Вход";
            this.btn_enter.UseSelectable = true;
            this.btn_enter.Click += new System.EventHandler(this.btn_enter_Click);
            // 
            // metroButton2
            // 
            this.metroButton2.Location = new System.Drawing.Point(247, 197);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(75, 23);
            this.metroButton2.TabIndex = 3;
            this.metroButton2.Text = "Выход";
            this.metroButton2.UseSelectable = true;
            this.metroButton2.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(85, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Логин";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(85, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Пароль";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 257);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.metroButton2);
            this.Controls.Add(this.btn_enter);
            this.Controls.Add(this.tb_password);
            this.Controls.Add(this.tb_login);
            this.Name = "Form1";
            this.Style = MetroFramework.MetroColorStyle.Orange;
            this.Text = "Авторизация";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox tb_login;
        private MetroFramework.Controls.MetroTextBox tb_password;
        private MetroFramework.Controls.MetroButton btn_enter;
        private MetroFramework.Controls.MetroButton metroButton2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

