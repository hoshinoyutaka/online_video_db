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
    public partial class Form_Add_Privacy : MetroFramework.Forms.MetroForm
    {
        private string connectionString = WindowsFormsApplication1.Properties.Settings.Default.Videoportal1ConnectionString;
        Videoportal1DataSetTableAdapters.PrivacyTableAdapter privacyTableAdapter;
        Videoportal1DataSet dataSet;
        public Form_Add_Privacy()
        {
            InitializeComponent();
        }
        public Form_Add_Privacy(Videoportal1DataSetTableAdapters.PrivacyTableAdapter privacyTableAdapter, Videoportal1DataSet dataSet)
        {
            InitializeComponent();
            this.privacyTableAdapter = privacyTableAdapter;
            this.dataSet = dataSet;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string privacy_title;
            privacy_title = textBox1.Text;

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
                    string query = "INSERT INTO Privacy (Privacy_ID, Privacy_title) VALUES ((SELECT ISNULL (MAX(Privacy.Privacy_ID)+1, 1) FROM Privacy), @Privacy_title)";
                    SqlCommand cmd = new SqlCommand(query, connection);

                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@Privacy_title", privacy_title);

                    adapter.UpdateCommand = cmd;
                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        MetroMessageBox.Show(this, "Запись успешно добавлена.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        privacyTableAdapter.Update(dataSet.Privacy);
                        privacyTableAdapter.Fill(dataSet.Privacy);
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

        /*        private void button1_Click(object sender, EventArgs e)
                {
                    string Privacy_title;
                    Privacy_title = textBox1.Text;

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
                            string query = "INSERT INTO [Privacy] (Privacy_ID, Privacy_title) VALUES (MAX([Privacy].[Privacy_ID])+1, @Privacy_title)";
                            SqlCommand cmd = new SqlCommand(query, connection);

                            cmd.CommandText = query;
                            cmd.Parameters.AddWithValue("@Privacy_title", Privacy_title);

                            adapter.UpdateCommand = cmd;
                            if (cmd.ExecuteNonQuery() == 1)
                            {
                                MetroMessageBox.Show(this, "Запись успешно добавлена.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                privacyTableAdapter.Update(dataSet.Privacy);
                                privacyTableAdapter.Fill(dataSet.Privacy);
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
                } */
    }
}
