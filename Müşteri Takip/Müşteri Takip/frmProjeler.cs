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

namespace Müşteri_Takip
{
    public partial class frmProjeler : Form
    {
        public frmProjeler()
        {
            InitializeComponent();
        }

        public SqlConnection baglanti;
        public SqlCommand komut;
        public SqlDataAdapter da;
        public SqlDataReader read;

        public void Getir()
        {
            baglanti = new SqlConnection("Data Source=LAPTOP-6P9UE1OV\\SQLEXPRESS;Initial Catalog=musteriTakip;Integrated Security=True;");
            baglanti.Open();

            da = new SqlDataAdapter("Select *From projeler", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            bunifuCustomDataGrid1.DataSource = tablo;
            baglanti.Close();

        }

        private void frmProjeler_Load(object sender, EventArgs e)
        {
            Getir();
            bunifuCustomDataGrid1.Columns[0].Width = 170;
            bunifuCustomDataGrid1.Columns[1].Width = 170;
            bunifuCustomDataGrid1.Columns[2].Width = 175;
            bunifuCustomDataGrid1.Columns[3].Width = 170;
            bunifuCustomDataGrid1.Columns[4].Width = 165;
        }

        private void bunifuCustomDataGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        public string deger = "";
        public int val = 0;
        private void bunifuCustomDataGrid1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = bunifuCustomDataGrid1.Rows[e.RowIndex];
                ((frmProjeler2)Application.OpenForms["frmProjeler2"]).txtİsim.Text = row.Cells[0].Value.ToString();
                deger = row.Cells[0].Value.ToString();
                ((frmProjeler2)Application.OpenForms["frmProjeler2"]).txtAciliyet.Text = row.Cells[1].Value.ToString();

                ((frmProjeler2)Application.OpenForms["frmProjeler2"]).bunifuDatepicker1.Value = Convert.ToDateTime(row.Cells[2].Value.ToString());


                ((frmProjeler2)Application.OpenForms["frmProjeler2"]).txtGelir.Text = row.Cells[3].Value.ToString();
                if (row.Cells[4].Value.ToString() == "Bitirildi")
                {
                    val = 0;
                }
                else
                {
                    val = 1;
                }
                ((frmProjeler2)Application.OpenForms["frmProjeler2"]).bunifuDropdown1.selectedIndex = val;
            }
        }
    }
}
