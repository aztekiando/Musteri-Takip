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
    public partial class frmMusteri2 : Form
    {
        public frmMusteri2()
        {
            InitializeComponent();
            ulas = this;
        }

        public static frmMusteri2 ulas = null;
        
        
        private void frmMusteri2_Load(object sender, EventArgs e)
        {
            //frmMusteri frm = new frmMusteri();
            //frm.bunifuCustomDataGrid1.

            
        }


        private void txtİsim_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
           // string veri = "insert into musteriTakip(İsim,Telefon,WhatsApp,Site,İs)values('" + txtİsim.Text + "','" + txtTelefon.Text + "','" + txtWhatsApp.Text + "','" + txtSite.Text + "','" + txtİş.Text + "')";

            ((frmMusteri)Application.OpenForms["frmMusteri"]).komut = new SqlCommand();
            ((frmMusteri)Application.OpenForms["frmMusteri"]).baglanti.Open();

            ((frmMusteri)Application.OpenForms["frmMusteri"]).komut.Connection = ((frmMusteri)Application.OpenForms["frmMusteri"]).baglanti;
            ((frmMusteri)Application.OpenForms["frmMusteri"]).komut.CommandText = "insert into bilgiler(İsim,Telefon,WhatsApp,Site,İs)values('" + txtİsim.Text + "','" + txtTelefon.Text + "','" + txtWhatsApp.Text + "','" + txtSite.Text + "','" + txtİş.Text + "')";
            ((frmMusteri)Application.OpenForms["frmMusteri"]).komut.ExecuteNonQuery();
            ((frmMusteri)Application.OpenForms["frmMusteri"]).baglanti.Close();
            ((frmMusteri)Application.OpenForms["frmMusteri"]).Getir();


        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            ((frmMusteri)Application.OpenForms["frmMusteri"]).komut = new SqlCommand();
            ((frmMusteri)Application.OpenForms["frmMusteri"]).baglanti.Open();

            ((frmMusteri)Application.OpenForms["frmMusteri"]).komut.Connection = ((frmMusteri)Application.OpenForms["frmMusteri"]).baglanti;
            ((frmMusteri)Application.OpenForms["frmMusteri"]).komut.CommandText = "delete from bilgiler where Telefon = '" + ((frmMusteri)Application.OpenForms["frmMusteri"]).telefonNoo + "' ";
            ((frmMusteri)Application.OpenForms["frmMusteri"]).komut.ExecuteNonQuery();
            ((frmMusteri)Application.OpenForms["frmMusteri"]).baglanti.Close();
            ((frmMusteri)Application.OpenForms["frmMusteri"]).Getir();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            ((frmMusteri)Application.OpenForms["frmMusteri"]).komut = new SqlCommand();
            ((frmMusteri)Application.OpenForms["frmMusteri"]).baglanti.Open();

            ((frmMusteri)Application.OpenForms["frmMusteri"]).komut.Connection = ((frmMusteri)Application.OpenForms["frmMusteri"]).baglanti;
            ((frmMusteri)Application.OpenForms["frmMusteri"]).komut.CommandText = "update bilgiler set İsim = '" + txtİsim.Text + "',Telefon = '" + txtTelefon.Text + "',WhatsApp = '" + txtWhatsApp.Text + "',Site = '" + txtSite.Text + "',İs = '" + txtİş.Text + "' where Telefon = '" + ((frmMusteri)Application.OpenForms["frmMusteri"]).telefonNoo + "'";
            ((frmMusteri)Application.OpenForms["frmMusteri"]).komut.ExecuteNonQuery();
            ((frmMusteri)Application.OpenForms["frmMusteri"]).baglanti.Close();
            ((frmMusteri)Application.OpenForms["frmMusteri"]).Getir();
        }
    }
}
