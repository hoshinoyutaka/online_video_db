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
    public partial class Form_Add_Video : MetroFramework.Forms.MetroForm
    {
        private string connectionString = WindowsFormsApplication1.Properties.Settings.Default.Videoportal1ConnectionString;
        Videoportal1DataSetTableAdapters.VideoTableAdapter videoTableAdapter;
        Videoportal1DataSet dataSet;
        public Form_Add_Video()
        {
            InitializeComponent();
        }
        public Form_Add_Video(Videoportal1DataSetTableAdapters.VideoTableAdapter videoTableAdapter, Videoportal1DataSet dataSet)
        {
            InitializeComponent();
            this.videoTableAdapter = videoTableAdapter;
            this.dataSet = dataSet;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string video_name, video_description, video_category, video_privacy, video_link, video_cover, video_user_id;
            video_name = textBox1.Text;
            video_description = textBox2.Text;
            video_category = textBox3.Text;
            video_privacy = textBox4.Text;
            video_link = textBox5.Text;
            video_cover = textBox6.Text;
            video_user_id = textBox8.Text;

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
                    string query = "INSERT INTO [Video] (Video_ID, Video_name, Video_description, Category_ID, Privacy_ID, Video_link, Video_cover, [User_ID]) VALUES ((SELECT ISNULL (MAX(Video.Video_ID)+1,1) FROM Video), @Video_name, @Video_description, @Video_category, @Video_privacy, @Video_link, @Video_cover, @Video_user_id)";
                    SqlCommand cmd = new SqlCommand(query, connection);

                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@Video_name", video_name);
                    cmd.Parameters.AddWithValue("@Video_description", video_description);
                    cmd.Parameters.AddWithValue("@Video_category", video_category);
                    cmd.Parameters.AddWithValue("@Video_privacy", video_privacy);
                    cmd.Parameters.AddWithValue("@Video_link", video_link);
                    cmd.Parameters.AddWithValue("@Video_cover", video_cover);
                    cmd.Parameters.AddWithValue("@Video_user_id", video_user_id);

                    adapter.UpdateCommand = cmd;
                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        MetroMessageBox.Show(this, "Запись успешно добавлена.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        videoTableAdapter.Update(dataSet.Video);
                        videoTableAdapter.Fill(dataSet.Video);
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
