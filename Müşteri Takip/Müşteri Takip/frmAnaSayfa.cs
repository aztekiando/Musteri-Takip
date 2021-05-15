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
    public partial class frmAnaSayfa : Form
    {
        public frmAnaSayfa()
        {
            InitializeComponent();
        }

        public SqlConnection baglanti;
        public SqlCommand komut;

        private void frmAnaSayfa_Load(object sender, EventArgs e)
        {

            


            MusteriGetir();
            bunifuCustomLabel5.Text = sayi.ToString();

            ProjeGetir();
            bunifuCustomLabel6.Text = bitirilenler.ToString();
            bunifuCustomLabel4.Text = bitmeyenler.ToString();


            GelirGetir();
            bunifuCustomLabel7.Text = gelirler.ToString();

        }
        Int32 sayi;
        Int32 bitirilenler = 0;
        Int32 bitmeyenler = 0;
        Int32 gelirler = 0;

        async void MusteriGetir()
        {
            baglanti = new SqlConnection("Data Source=LAPTOP-6P9UE1OV\\SQLEXPRESS;Initial Catalog=musteriTakip;Integrated Security=True;");
            komut = new SqlCommand();
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "SELECT COUNT(*) FROM bilgiler";
            sayi = (Int32)komut.ExecuteScalar();
            baglanti.Close();
        }

        async void ProjeGetir()
        {
            baglanti = new SqlConnection("Data Source=LAPTOP-6P9UE1OV\\SQLEXPRESS;Initial Catalog=musteriTakip;Integrated Security=True;");
            komut = new SqlCommand();
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "SELECT * FROM projeler";
            SqlDataReader reader = komut.ExecuteReader();

            while (reader.Read())
            {
                if ((reader["Durum"]).ToString() == "Bitirildi")
                {
                    bitirilenler++;
                }
                else if (reader["Durum"].ToString() == "Devam Ediyor")
                {
                    bitmeyenler++;
                }
            }
           
            reader.Close();
            baglanti.Close();
        }

        async void GelirGetir()
        {
            baglanti = new SqlConnection("Data Source=LAPTOP-6P9UE1OV\\SQLEXPRESS;Initial Catalog=musteriTakip;Integrated Security=True;");
            komut = new SqlCommand();
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "SELECT * FROM projeler";
            SqlDataReader reader = komut.ExecuteReader();

            while (reader.Read())
            {
                gelirler += Convert.ToInt32(reader["Gelir"]);
            }
            reader.Close();
            baglanti.Close();
        }


    }
}
