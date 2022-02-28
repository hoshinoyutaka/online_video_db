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
    public partial class Form_Add_Videofile : MetroFramework.Forms.MetroForm
    {
        private string connectionString = WindowsFormsApplication1.Properties.Settings.Default.Videoportal1ConnectionString;
        Videoportal1DataSetTableAdapters.VideofileTableAdapter videofileTableAdapter;
        Videoportal1DataSet dataSet;
        public Form_Add_Videofile()
        {
            InitializeComponent();
        }
        public Form_Add_Videofile(Videoportal1DataSetTableAdapters.VideofileTableAdapter videofileTableAdapter, Videoportal1DataSet dataSet)
        {
            InitializeComponent();
            this.videofileTableAdapter = videofileTableAdapter;
            this.dataSet = dataSet;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string videofile_length, videofile_resolution, videofile_codec, videofile_aspectratio, videofile_features, videofile_format;
            int videofile_size, video_id;
            videofile_length = textBox1.Text;
            videofile_size = int.Parse(textBox2.Text);
            videofile_resolution = textBox3.Text;
            videofile_codec = textBox4.Text;
            videofile_aspectratio = textBox5.Text;
            videofile_features = textBox6.Text;
            videofile_format = textBox7.Text;
            video_id = int.Parse(textBox8.Text);

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
                    string query = "INSERT INTO [Videofile] (Videofile_length, Videofile_size, Videofile_resolution, Videofile_codec, Videofile_aspectratio, Videofile_features, Videofile_format, Video_ID) VALUES (@Videofile_length, @Videofile_size, @Videofile_resolution, @Videofile_codec, @Videofile_aspectratio, @Videofile_features, @Videofile_format, @Video_ID)";
                    SqlCommand cmd = new SqlCommand(query, connection);

                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@Videofile_length", videofile_length);
                    cmd.Parameters.AddWithValue("@Videofile_size", videofile_size);
                    cmd.Parameters.AddWithValue("@Videofile_resolution", videofile_resolution);
                    cmd.Parameters.AddWithValue("@Videofile_codec", videofile_codec);
                    cmd.Parameters.AddWithValue("@Videofile_aspectratio", videofile_aspectratio);
                    cmd.Parameters.AddWithValue("@Videofile_features", videofile_features);
                    cmd.Parameters.AddWithValue("@Videofile_format", videofile_format);
                    cmd.Parameters.AddWithValue("@Video_ID", video_id);

                    adapter.UpdateCommand = cmd;
                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        MetroMessageBox.Show(this, "Запись успешно добавлена.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        videofileTableAdapter.Update(dataSet.Videofile);
                        videofileTableAdapter.Fill(dataSet.Videofile);
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
        //Добавление видеофайла и обработчик выгрузки в Excel
        /*    private void button1_Click(object sender, EventArgs e)
            {
                string Videofile_length, Videofile_resolution, Videofile_codec, Videofile_aspectratio, Videofile_features, Videofile_format ,Video_ID;
                int Videofile_size;
                Videofile_length = textBox1.Text;
                Videofile_size = int.Parse(textBox2.Text);
                Videofile_resolution = textBox3.Text;
                Videofile_codec = textBox4.Text;
                Videofile_aspectratio = textBox5.Text;
                Videofile_features = textBox6.Text;
                Videofile_format = textBox7.Text;
                Video_ID = textBox8.Text;

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
                        string query = "INSERT INTO [Videofile] (Videofile_length, Videofile_size, Videofile_resolution, Videofile_codec, Videofile_aspectratio, Videofile_features, Videofile_format, Video_ID) VALUES (@Videofile_length, @Videofile_size, @Videofile_resolution, @Videofile_codec, @Videofile_aspectratio, @Videofile_features, @Videofile_format, @Video_ID)";
                        SqlCommand cmd = new SqlCommand(query, connection);

                        cmd.CommandText = query;
                        cmd.Parameters.AddWithValue("@Videofile_length", Videofile_length);
                        cmd.Parameters.AddWithValue("@Videofile_size", Videofile_size);
                        cmd.Parameters.AddWithValue("@Videofile_resolution", Videofile_resolution);
                        cmd.Parameters.AddWithValue("@Videofile_codec", Videofile_codec);
                        cmd.Parameters.AddWithValue("@Videofile_aspectratio", Videofile_aspectratio);
                        cmd.Parameters.AddWithValue("@Videofile_features", Videofile_features);
                        cmd.Parameters.AddWithValue("@Videofile_format", Videofile_format);
                        cmd.Parameters.AddWithValue("@Video_ID", Video_ID);

                        adapter.UpdateCommand = cmd;
                        if (cmd.ExecuteNonQuery() == 1)
                        {
                            MetroMessageBox.Show(this, "Запись успешно добавлена.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            videofileTableAdapter.Update(dataSet.Videofile);
                            videofileTableAdapter.Fill(dataSet.Videofile);
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
