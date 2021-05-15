using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Müşteri_Takip
{
    public partial class frmMusteri : Form
    {
        public frmMusteri()
        {
            InitializeComponent();
            ulas = frmMusteri2.ulas;
        }

        frmMusteri2 ulas = null;


        private void frmData_Load(object sender, EventArgs e)
        {
            Getir();
            bunifuCustomDataGrid1.Columns[0].Width = 170;
            bunifuCustomDataGrid1.Columns[1].Width = 170;
            bunifuCustomDataGrid1.Columns[2].Width = 175;
            bunifuCustomDataGrid1.Columns[3].Width = 170;
            bunifuCustomDataGrid1.Columns[4].Width = 165;
        }


        public SqlConnection baglanti;
        public SqlCommand komut;
        public SqlDataAdapter da;
        public SqlDataReader read;
        public async void Getir()
        {
            baglanti = new SqlConnection("Data Source=LAPTOP-6P9UE1OV\\SQLEXPRESS;Initial Catalog=musteriTakip;Integrated Security=True;");
            baglanti.Open();
            
            da = new SqlDataAdapter("Select *From bilgiler", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            bunifuCustomDataGrid1.DataSource = tablo;
            baglanti.Close();
        }

        private void bunifuCustomDataGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        frmMusteri2 musteri2 = new frmMusteri2();
        private void bunifuCustomDataGrid1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
        }


        public string  deger = "";
        public string telefonNoo = "";

        private async void bunifuCustomDataGrid1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
             
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = bunifuCustomDataGrid1.Rows[e.RowIndex];
                ((frmMusteri2)Application.OpenForms["frmMusteri2"]).txtİsim.Text = row.Cells[0].Value.ToString();
                deger = row.Cells[0].Value.ToString();
                ((frmMusteri2)Application.OpenForms["frmMusteri2"]).txtTelefon.Text = row.Cells[1].Value.ToString();
                telefonNoo = row.Cells[1].Value.ToString();
                ((frmMusteri2)Application.OpenForms["frmMusteri2"]).txtWhatsApp.Text = row.Cells[2].Value.ToString();
                ((frmMusteri2)Application.OpenForms["frmMusteri2"]).txtSite.Text = row.Cells[3].Value.ToString();
                ((frmMusteri2)Application.OpenForms["frmMusteri2"]).txtİş.Text = row.Cells[4].Value.ToString();
            }
          //  deger = bunifuCustomDataGrid1.SelectedCells[0].RowIndex;
            

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
