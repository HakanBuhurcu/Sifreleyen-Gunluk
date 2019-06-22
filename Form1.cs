using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Dijital_Günlük
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=gunlukVeritabani.mdb");
        public static string isim = "";
        public static int id = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
             

        private void label3_Click(object sender, EventArgs e)
        {
            btnGiris.Visible = false;
            btnKaydol.Visible = true;
        }

      

        private void button2_MouseMove(object sender, MouseEventArgs e)
        {  btnGiris.Text = "[ Giriş Yap ]"; }

        private void button2_MouseLeave(object sender, EventArgs e)
        {  btnGiris.Text = " Giriş Yap ";   }

        private void btnKaydol_MouseLeave(object sender, EventArgs e)
        {  btnKaydol.Text = "Kaydol";       }

        private void btnKaydol_MouseMove(object sender, MouseEventArgs e)
        {  btnKaydol.Text = " [ Kaydol ]";  }

        private void btnKaydol_MouseDown(object sender, MouseEventArgs e)
        {  btnKaydol.Text = " [Kaydol]";    }

        private void button2_MouseDown(object sender, MouseEventArgs e)
        {  btnGiris.Text = "[Giris Yap]";   }

       

        private void btnGiris_Click(object sender, EventArgs e)
        {
            int sifre = Convert.ToInt32(textBox2.Text) + 987451;
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("SELECT K_ID,K_adi FROM Kullanicilar WHERE K_adi=@pkadi and Sifre=@psifre ", baglanti);
            komut.Parameters.AddWithValue("@kullaniciadi", textBox1.Text);
            komut.Parameters.AddWithValue("@sifre", sifre);
            OleDbDataReader dr = komut.ExecuteReader();
            if (dr.HasRows == true)
            {
                while (dr.Read())
                {
                    id = dr.GetInt32(0);
                    isim = dr.GetString(1);
                }

                anaEkran anaekran1 = new anaEkran();
                this.Hide();
                anaekran1.Show();
            }
            else
                MessageBox.Show("Kullanıcı adı ve/veya şifre yanlış");
            baglanti.Close();
            
        }

        private void btnKaydol_Click(object sender, EventArgs e)
        {
           
            baglanti.Open();

            OleDbCommand komut2 = new OleDbCommand("SELECT K_ID FROM Kullanicilar WHERE K_adi=@pkadi", baglanti);
            komut2.Parameters.AddWithValue("@kullaniciadi", textBox1.Text);
            OleDbDataReader dr = komut2.ExecuteReader();
            if (dr.HasRows == true)
            {
                MessageBox.Show("Bu kullanıcı adına sahip zaten bir kullanıcı var lütfen farklı bir kullanıcı adı giriniz");

            }
            else
            {
                int sifre = Convert.ToInt32(textBox2.Text);
                sifre = sifre + 987451;

                OleDbCommand komut = new OleDbCommand("INSERT INTO Kullanicilar(K_adi,Sifre) VALUES (@kullaniciadi,@sifre)", baglanti);
                komut.Parameters.AddWithValue("@kullaniciadi", textBox1.Text);
                komut.Parameters.AddWithValue("@sifre", sifre);
                komut.ExecuteNonQuery();
                

                MessageBox.Show("EKLENDİ");
                btnKaydol.Visible = false;
                btnGiris.Visible = true;
            }
            baglanti.Close();
        }
           
    }

 }

    


    
