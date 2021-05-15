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
    public partial class frmProjeler2 : Form
    {
        public frmProjeler2()
        {
            InitializeComponent();
            bunifuDropdown1.Items.Add("Bitirildi");
            bunifuDropdown1.Items.Add("Devam Ediyor");
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            ((frmProjeler)Application.OpenForms["frmProjeler"]).komut = new SqlCommand();
            ((frmProjeler)Application.OpenForms["frmProjeler"]).baglanti.Open();
            
            ((frmProjeler)Application.OpenForms["frmProjeler"]).komut.Connection = ((frmProjeler)Application.OpenForms["frmProjeler"]).baglanti;
            ((frmProjeler)Application.OpenForms["frmProjeler"]).komut.CommandText = "insert into projeler(İsim,Aciliyet,Başlangıç,Gelir,Durum)values('" + txtİsim.Text + "','" + txtAciliyet.Text + "','" + bunifuDatepicker1.Value.ToString("yyyy-MM-dd") + "','" + txtGelir.Text + "','" + bunifuDropdown1.selectedValue.ToString() + "')";
            ((frmProjeler)Application.OpenForms["frmProjeler"]).komut.ExecuteNonQuery();
            ((frmProjeler)Application.OpenForms["frmProjeler"]).baglanti.Close();
            ((frmProjeler)Application.OpenForms["frmProjeler"]).Getir();
        }

        private void frmProjeler2_Load(object sender, EventArgs e)
        {

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            ((frmProjeler)Application.OpenForms["frmProjeler"]).komut = new SqlCommand();
            ((frmProjeler)Application.OpenForms["frmProjeler"]).baglanti.Open();

            ((frmProjeler)Application.OpenForms["frmProjeler"]).komut.Connection = ((frmProjeler)Application.OpenForms["frmProjeler"]).baglanti;
            ((frmProjeler)Application.OpenForms["frmProjeler"]).komut.CommandText = "update projeler set İsim = '" + txtİsim.Text + "',Aciliyet = '" + txtAciliyet.Text + "',Başlangıç = '" + bunifuDatepicker1.Value.ToString("yyyy-MM-dd") + "',Gelir = '" + txtGelir.Text + "',Durum = '" + bunifuDropdown1.selectedValue.ToString() + "' where İsim = '" + ((frmProjeler)Application.OpenForms["frmProjeler"]).deger + "'";
            ((frmProjeler)Application.OpenForms["frmProjeler"]).komut.ExecuteNonQuery();
            ((frmProjeler)Application.OpenForms["frmProjeler"]).baglanti.Close();
            ((frmProjeler)Application.OpenForms["frmProjeler"]).Getir();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            ((frmProjeler)Application.OpenForms["frmProjeler"]).komut = new SqlCommand();
            ((frmProjeler)Application.OpenForms["frmProjeler"]).baglanti.Open();

            ((frmProjeler)Application.OpenForms["frmProjeler"]).komut.Connection = ((frmProjeler)Application.OpenForms["frmProjeler"]).baglanti;
            ((frmProjeler)Application.OpenForms["frmProjeler"]).komut.CommandText = "delete from projeler where İsim = '" + ((frmProjeler)Application.OpenForms["frmProjeler"]).deger + "' ";
            ((frmProjeler)Application.OpenForms["frmProjeler"]).komut.ExecuteNonQuery();
            ((frmProjeler)Application.OpenForms["frmProjeler"]).baglanti.Close();
            ((frmProjeler)Application.OpenForms["frmProjeler"]).Getir();
        }
    }
}
