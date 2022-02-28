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
    public partial class Form_Add_Category : MetroFramework.Forms.MetroForm
    {

        private string connectionString = WindowsFormsApplication1.Properties.Settings.Default.Videoportal1ConnectionString;
        Videoportal1DataSetTableAdapters.CategoryTableAdapter categoryTableAdapter;
        Videoportal1DataSet dataSet;
        public Form_Add_Category()
        {
            InitializeComponent();
        }

        public Form_Add_Category(Videoportal1DataSetTableAdapters.CategoryTableAdapter categoryTableAdapter, Videoportal1DataSet dataSet)
        {
            InitializeComponent();
            this.categoryTableAdapter = categoryTableAdapter;
            this.dataSet = dataSet;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string category_title;
            category_title = textBox2.Text;


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
                    string query = "INSERT INTO [Category] (Category_ID,Category_title) VALUES ((SELECT ISNULL (MAX(Category.Category_ID)+1,1) FROM Category), @Category_title)";
                    SqlCommand cmd = new SqlCommand(query, connection);

                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@Category_title", category_title);

                    adapter.UpdateCommand = cmd;
                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        MetroMessageBox.Show(this, "Запись успешно добавлена.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        categoryTableAdapter.Update(dataSet.Category);
                        categoryTableAdapter.Fill(dataSet.Category);
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
