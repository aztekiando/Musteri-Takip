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
using System.Drawing.Drawing2D;

namespace Müşteri_Takip
{
    public partial class Form1 : Form
    {

        int Move;
        int Mouse_X;
        int Mouse_Y;


        public Form1()
        {
            InitializeComponent();
            ulasForm = this;
        }

        public static Form1 ulasForm = null;

        
        
        
        async void asn(Form form, Bunifu.Framework.UI.BunifuCards cards)
        {
            cards.Controls.Clear();
            form.Dock = DockStyle.Fill;
            form.TopLevel = false;
            cards.Controls.Add(form);
            form.Show();

        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            frmAnaSayfa ana = new frmAnaSayfa();

            asn(ana, bunifuCards1);
            bunifuCards2.Controls.Clear();
        }



        private void bunifuCustomLabel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            Move = 0;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Move = 1;
            Mouse_X = e.X;
            Mouse_Y = e.Y;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (Move == 1)
            {
                this.SetDesktopLocation(MousePosition.X - Mouse_X, MousePosition.Y - Mouse_Y);
            }
        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            frmAnaSayfa ana = new frmAnaSayfa();
            asn(ana, bunifuCards1);
            bunifuCards2.Controls.Clear();
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            frmProjeler proje = new frmProjeler();
            frmProjeler2 proje2 = new frmProjeler2();
            asn(proje, bunifuCards1);
            asn(proje2, bunifuCards2);
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            frmMusteri dataF = new frmMusteri();
            frmMusteri2 dataF2 = new frmMusteri2();
            asn(dataF, bunifuCards1);
            asn(dataF2, bunifuCards2);
        }
    }
}
