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
    public partial class Form_Add_Stata : MetroFramework.Forms.MetroForm
    {
        private string connectionString = WindowsFormsApplication1.Properties.Settings.Default.Videoportal1ConnectionString;
        Videoportal1DataSetTableAdapters.StataTableAdapter stataTableAdapter;
        Videoportal1DataSet dataSet;
        public Form_Add_Stata()
        {
            InitializeComponent();
        }
        public Form_Add_Stata(Videoportal1DataSetTableAdapters.StataTableAdapter stataTableAdapter, Videoportal1DataSet dataSet)
        {
            InitializeComponent();
            this.stataTableAdapter = stataTableAdapter;
            this.dataSet = dataSet;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            int video_id, stata_likes, stata_dislikes, stata_views;
            video_id = int.Parse(textBox1.Text);
            stata_likes = int.Parse(textBox2.Text);
            stata_dislikes = int.Parse(textBox3.Text);
            stata_views = int.Parse(textBox4.Text);


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
                    string query = "INSERT INTO Stata (Video_ID, Stata_likes, Stata_dislikes, Stata_views) VALUES ( @Video_id, @Stata_likes, @Stata_dislikes, @Stata_views)";
                    SqlCommand cmd = new SqlCommand(query, connection);

                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@Video_id", video_id);
                    cmd.Parameters.AddWithValue("@Stata_likes", stata_likes);
                    cmd.Parameters.AddWithValue("@Stata_dislikes", stata_dislikes);
                    cmd.Parameters.AddWithValue("@Stata_views", stata_views);

                    adapter.UpdateCommand = cmd;
                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        MetroMessageBox.Show(this, "Запись успешно добавлена.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        stataTableAdapter.Update(dataSet.Stata);
                        stataTableAdapter.Fill(dataSet.Stata);
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
