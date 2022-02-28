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
    public partial class Form_Add_Playlist : MetroFramework.Forms.MetroForm
    {
        private string connectionString = WindowsFormsApplication1.Properties.Settings.Default.Videoportal1ConnectionString;
        Videoportal1DataSetTableAdapters.PlaylistTableAdapter playlistTableAdapter;
        Videoportal1DataSet dataSet;
        public Form_Add_Playlist()
        {
            InitializeComponent();
        }
        public Form_Add_Playlist(Videoportal1DataSetTableAdapters.PlaylistTableAdapter playlistTableAdapter, Videoportal1DataSet dataSet)
        {
            InitializeComponent();
            this.playlistTableAdapter = playlistTableAdapter;
            this.dataSet = dataSet;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string playlist_title;
            int privacy_id, number_of_videos;
            playlist_title = textBox1.Text;
            privacy_id = int.Parse(textBox2.Text);
            number_of_videos = int.Parse(textBox3.Text);


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
                    string query = "INSERT INTO Playlist (Playlist_ID, Playlist_title, Privacy_ID, Number_of_videos) VALUES ((SELECT ISNULL (MAX(Playlist.Playlist_ID)+1,1) FROM [Playlist]), @Playlist_title, @Privacy_ID, @Number_of_videos)";
                    SqlCommand cmd = new SqlCommand(query, connection);

                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@Playlist_title", playlist_title);
                    cmd.Parameters.AddWithValue("@Privacy_ID", privacy_id);
                    cmd.Parameters.AddWithValue("@Number_of_videos", number_of_videos);

                    adapter.UpdateCommand = cmd;
                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        MetroMessageBox.Show(this, "Запись успешно добавлена.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        playlistTableAdapter.Update(dataSet.Playlist);
                        playlistTableAdapter.Fill(dataSet.Playlist);
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

        /*  private void button1_Click(object sender, EventArgs e)
          {

              string Playlist_title;
              int Privacy_ID, Number_of_videos;
              Playlist_title = textBox1.Text;
              Privacy_ID = int.Parse(textBox2.Text);
              Number_of_videos = int.Parse(textBox3.Text);


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
                      string query = "INSERT INTO [Playlist] (Playlist_ID, Playlist_title, Privacy_ID, Number_of_videos) VALUES ((SELECT ISNULL (MAX([Playlist].[Playlist_ID])+1,1) FROM [Playlist]), @Playlist_title, @Privacy_ID, @Number_of_videos)";
                      SqlCommand cmd = new SqlCommand(query, connection);

                      cmd.CommandText = query;
                      cmd.Parameters.AddWithValue("@Playlist_title", Playlist_title);
                      cmd.Parameters.AddWithValue("@Privacy_ID", Privacy_ID);
                      cmd.Parameters.AddWithValue("@Number_of_videos", Number_of_videos);

                      adapter.UpdateCommand = cmd;
                      if (cmd.ExecuteNonQuery() == 1)
                      {
                          MetroMessageBox.Show(this, "Запись успешно добавлена.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                          playlistTableAdapter.Update(dataSet.Playlist);
                          playlistTableAdapter.Fill(dataSet.Playlist);
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
