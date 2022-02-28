using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;

namespace WindowsFormsApplication1
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {

        private string connectionString = WindowsFormsApplication1.Properties.Settings.Default.Videoportal1ConnectionString;

        private bool isAdmin=false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_enter_Click(object sender, EventArgs e)
        {
            string login, password;
            login = tb_login.Text;
            password = tb_password.Text;

            string queryStringIsUser = "SELECT  COUNT(*) FROM [User] WHERE [User].User_nickname=\'" + login + "\' AND [User].User_password=\'" + password + "\'";
            string queryStringIsAdmin = "SELECT COUNT(*) FROM [User] WHERE [User].User_nickname=\'" + login + "\' AND [User].User_password=\'" + password + "\' AND [User].User_status=N'Admin'";

            if (IsUser(queryStringIsUser, login, password))
            {
                isAdmin = IsUser(queryStringIsAdmin, login, password);
                new Form_main(isAdmin).ShowDialog();
            }
            else
            {
                MetroMessageBox.Show(this, "Неверные данные для авторизации", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            

        }


        private bool IsUser(string queryString, string login, string pass) {
            bool flag = false;
            int temp = 0;

            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();
            }
            catch (SqlException e) {
                MetroMessageBox.Show(this, "Ошибка подключения : " + e.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            SqlCommand command = new SqlCommand(queryString, conn);
            using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
            {
                while (reader.Read())
                {
                    temp = (int)reader[0];
                }

                if (temp > 0)
                    flag = true;
            }

            conn.Close();
            conn.Dispose();



            return flag;
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
