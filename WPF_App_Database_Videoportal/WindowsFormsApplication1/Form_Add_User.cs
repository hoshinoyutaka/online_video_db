using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using System.Data.SqlClient;

namespace WindowsFormsApplication1
{
    public partial class Form_Add_User : MetroFramework.Forms.MetroForm
    {
        private string connectionString = WindowsFormsApplication1.Properties.Settings.Default.Videoportal1ConnectionString;
        Videoportal1DataSetTableAdapters.UserTableAdapter userTableAdapter;
        Videoportal1DataSet dataSet;
        public Form_Add_User()
        {
            InitializeComponent();
        }
        public Form_Add_User(Videoportal1DataSetTableAdapters.UserTableAdapter userTableAdapter, Videoportal1DataSet dataSet)
        {
            InitializeComponent();
            this.userTableAdapter = userTableAdapter;
            this.dataSet = dataSet;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string user_nickname, user_email, user_password, user_surname, user_name, user_country, user_phone, user_picture, user_status;
            user_nickname = textBox1.Text;
            user_email = textBox2.Text;
            user_password = textBox3.Text;
            user_surname = textBox4.Text;
            user_name = textBox5.Text;
            user_country = textBox6.Text;
            user_phone = textBox7.Text;
            user_picture = textBox8.Text;
            user_status = textBox9.Text;

            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
            }
            catch (SqlException se)
            {
                MetroMessageBox.Show(this, "Ошибка подключения : " + se.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            {
                try
                {
                    string query = "INSERT INTO [User] (User_nickname, User_email, User_password, User_surname, User_name, User_country, User_phone, User_picture, [User_ID], User_status) VALUES (@User_nickname, @User_email, @User_password, @User_surname, @User_name, @User_country, @User_phone, @User_picture, (SELECT ISNULL (MAX(Video.Video_ID)+1,1) FROM Video), @User_status)";
                    SqlCommand cmd = new SqlCommand(query, connection);

                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@User_nickname", user_nickname);
                    cmd.Parameters.AddWithValue("@User_email", user_email);
                    cmd.Parameters.AddWithValue("@User_password", user_password);
                    cmd.Parameters.AddWithValue("@User_surname", user_surname);
                    cmd.Parameters.AddWithValue("@User_name", user_name);
                    cmd.Parameters.AddWithValue("@User_country", user_country);
                    cmd.Parameters.AddWithValue("@User_phone", user_phone);
                    cmd.Parameters.AddWithValue("@User_picture", user_picture);
                    cmd.Parameters.AddWithValue("@User_status", user_status);

                    adapter.UpdateCommand = cmd;
                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        MetroMessageBox.Show(this, "Запись успешно добавлена.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        userTableAdapter.Update(dataSet.User);
                        userTableAdapter.Fill(dataSet.User);
                        this.Close();
                    }
                }
                catch (SqlException se)
                {
                    MetroMessageBox.Show(this, "Ошибка : " + se.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            connection.Close();
            connection.Dispose();
        }
    }
}
