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
    public partial class Form_main : MetroFramework.Forms.MetroForm
    {
        public Form_main()
        {
            InitializeComponent();
        }

        public Form_main(bool isAdmin)
        {
            InitializeComponent();
            if (!isAdmin) {
                metroTabControl1.TabPages.Remove(tp_user);
                metroTabControl1.TabPages.Remove(tp_stata);
            }
        }

        private void Form_main_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "videoportal1DataSet.Stata". При необходимости она может быть перемещена или удалена.
            this.stataTableAdapter.Fill(this.videoportal1DataSet.Stata);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "videoportal1DataSet.User". При необходимости она может быть перемещена или удалена.
            this.userTableAdapter.Fill(this.videoportal1DataSet.User);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "videoportal1DataSet.Privacy". При необходимости она может быть перемещена или удалена.
            this.privacyTableAdapter.Fill(this.videoportal1DataSet.Privacy);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "videoportal1DataSet.Playlist". При необходимости она может быть перемещена или удалена.
            this.playlistTableAdapter.Fill(this.videoportal1DataSet.Playlist);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "videoportal1DataSet.Videofile". При необходимости она может быть перемещена или удалена.
            this.videofileTableAdapter.Fill(this.videoportal1DataSet.Videofile);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "videoportal1DataSet.Video". При необходимости она может быть перемещена или удалена.
            this.videoTableAdapter.Fill(this.videoportal1DataSet.Video);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "videoportal1DataSet.Category". При необходимости она может быть перемещена или удалена.
            this.categoryTableAdapter.Fill(this.videoportal1DataSet.Category);

        }
      
        private void ExportToXlsFile(DataGridView dgv)
        {
            Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
            ExcelApp.Application.Workbooks.Add(Type.Missing);
            ExcelApp.Columns.ColumnWidth = 15;
            for (int i = 0; i < dgv.ColumnCount; i++)
            {
                ExcelApp.Cells[1, i + 1] = dgv.Columns[i].HeaderCell.Value;
            }

            for (int i = 0; i < dgv.ColumnCount; i++)
            {
                for (int j = 0; j < dgv.RowCount; j++)
                {
                    ExcelApp.Cells[j + 2, i + 1] = (dgv[i, j].Value).ToString();
                }
            }
            ExcelApp.Visible = true;
        }

        private void categoryAddItem_Click(object sender, EventArgs e)
        {
            new Form_Add_Category(categoryTableAdapter, videoportal1DataSet).ShowDialog();
        }

        private void categorySaveItem_Click(object sender, EventArgs e)
        {
            this.categoryTableAdapter.Update(this.videoportal1DataSet.Category);
        }

        private void videoAddItem_Click(object sender, EventArgs e)
        {
            new Form_Add_Video(videoTableAdapter, videoportal1DataSet).ShowDialog();
        }

        private void videoSaveItem_Click(object sender, EventArgs e)
        {
            this.videoTableAdapter.Update(this.videoportal1DataSet.Video);
        }

        private void videofileAddItem_Click(object sender, EventArgs e)
        {
            new Form_Add_Videofile(videofileTableAdapter, videoportal1DataSet).ShowDialog();
        }

        private void videofileSaveItem_Click(object sender, EventArgs e)
        {
            this.videofileTableAdapter.Update(this.videoportal1DataSet.Videofile);
        }

        private void playlistAddItem_Click(object sender, EventArgs e)
        {
            new Form_Add_Playlist(playlistTableAdapter, videoportal1DataSet).ShowDialog();
        }

        private void playlistSaveItem_Click(object sender, EventArgs e)
        {
            this.playlistTableAdapter.Update(this.videoportal1DataSet.Playlist);
        }

        private void privacyAddItem_Click(object sender, EventArgs e)
        {
            new Form_Add_Privacy(privacyTableAdapter, videoportal1DataSet).ShowDialog();
        }

        private void privacySaveItem_Click(object sender, EventArgs e)
        {
            this.privacyTableAdapter.Update(this.videoportal1DataSet.Privacy);
        }

        private void userAddItem_Click(object sender, EventArgs e)
        {
            new Form_Add_User(userTableAdapter, videoportal1DataSet).ShowDialog();
        }

        private void userSaveItem_Click(object sender, EventArgs e)
        {
            this.userTableAdapter.Update(this.videoportal1DataSet.User);
        }

        private void stataAddItem_Click(object sender, EventArgs e)
        {
            new Form_Add_Stata(stataTableAdapter, videoportal1DataSet).ShowDialog();
        }

        private void stataSaveItem_Click(object sender, EventArgs e)
        {
            this.stataTableAdapter.Update(this.videoportal1DataSet.Stata);
        }
        //-------------------------------------------------------------------------------------------
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ExportToXlsFile(categoryMetroGrid);
        }

        private void videoExcel_Click(object sender, EventArgs e)
        {
            ExportToXlsFile(videoMetroGrid);
        }

        private void videofileExcel_Click(object sender, EventArgs e)
        {
            ExportToXlsFile(videofileMetroGrid);
        }

        private void playlistExcel_Click(object sender, EventArgs e)
        {
            ExportToXlsFile(playlistMetroGrid);
        }

        private void privacyExcel_Click(object sender, EventArgs e)
        {
            ExportToXlsFile(privacyMetroGrid);
        }

        private void userExcel_Click(object sender, EventArgs e)
        {
            ExportToXlsFile(userMetroGrid);
        }

        private void stataExcel_Click(object sender, EventArgs e)
        {
            ExportToXlsFile(stataMetroGrid);
        }
    } 
}
