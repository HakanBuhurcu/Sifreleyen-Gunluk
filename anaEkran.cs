using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using System.Data.OleDb;
using System.Collections;


namespace Dijital_Günlük
{
    public partial class anaEkran : Form
    {
        //--------------------DEĞİŞKEN ALANI----------------------
        string sifreliMetin = ""; string ametin = ""; string gun = ""; string ay = ""; string tarih = "";
        static string isim1 = ""; static int id1 = 0;
        string karakter = ""; string sifre = "";
        int sayacCoz = 1; int kontroldeger = 0;
        int sayfagecis = 0;
        ArrayList Yillar = new ArrayList();

        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=gunlukVeritabani.mdb");
        public anaEkran()
        {
            InitializeComponent();

            id1 = Form1.id;
            isim1 = Form1.isim;

            label3.Text = isim1;
            label10.Text = DateTime.Now.Date.ToLongDateString();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (comboBox1.SelectedItem == null || comboBox2.SelectedItem == null || comboBox3.SelectedItem == null)
                MessageBox.Show("Lütfen tarih bilgilerini eksiksiz girin!");
            else
            {
                
                OleDbCommand metinkomut = new OleDbCommand("select Metin from Gunlukler where K_ID = @pkid and Yil=@yil and Ay = @ay and Gun=@gun", baglanti);
                metinkomut.Parameters.AddWithValue("@pkid", id1);
                metinkomut.Parameters.AddWithValue("@yil", comboBox1.SelectedItem);
                metinkomut.Parameters.AddWithValue("@ay", comboBox2.SelectedItem);
                metinkomut.Parameters.AddWithValue("@gun", comboBox3.SelectedItem);
                baglanti.Open();
                string icerik = (string)metinkomut.ExecuteScalar();

                for (int i = 1; i < 87; i++)
                {
                    OleDbCommand komut = new OleDbCommand("SELECT SIFRE_METNI FROM sifrelemeTablosu WHERE Id = " + i + "", baglanti);
                    OleDbCommand komut2 = new OleDbCommand("SELECT karakterler FROM isaretciler WHERE Kimlik = " + i + "", baglanti);
                    OleDbDataReader dr = komut.ExecuteReader();
                    if (dr.HasRows == true)
                    {
                        while (dr.Read())
                        {
                            sifreliMetin = dr.GetString(0);
                        }
                    }
                    dr = komut2.ExecuteReader();
                    if (dr.HasRows == true)
                    {
                        while (dr.Read())
                        {
                            karakter = dr.GetString(0);
                        }
                    }
                    if (i == 86)
                    {
                        dr.Close();
                    }
                    for (int j = 0; j < 4; j++)
                    {
                        sifre = sifreliMetin.Substring(sayacCoz, 4);
                        sayacCoz = sayacCoz + 6;
                        icerik = icerik.Replace(sifre, karakter);
                    }
                    sayacCoz = 1;
                }
                int deneme = 1;
                while (deneme < icerik.Length)
                {
                    ametin += icerik.Substring(deneme, 1);
                    deneme = deneme + 3;
                }
                textBox1.Text = ametin;

                if (ametin.Length < 510)
                    btnsayfa1.Text = ametin;
                else if (ametin.Length > 510 && ametin.Length < 1020)
                {
                    btnsayfa1.Text = ametin.Substring(0, 510);
                    btnsayfa2.Text = ametin.Substring(510, ametin.Length - 510);
                }
                else if (ametin.Length > 1020 && ametin.Length < 1530)
                {
                    btnsayfa1.Text = ametin.Substring(1019, ametin.Length - 1019);
                    btnGeri.Visible = true;
                    sayfagecis = 1;

                }
                else if (ametin.Length > 1530 && ametin.Length < 2040)
                {
                    btnsayfa1.Text = ametin.Substring(1019, 510);
                    btnsayfa2.Text = ametin.Substring(1529, ametin.Length - 1529);
                    btnGeri.Visible = true;
                    sayfagecis = 1;
                }
                else if (ametin.Length > 2040 && ametin.Length < 2550)
                {
                    btnsayfa1.Text = ametin.Substring(2039, ametin.Length - 2039);
                    btnGeri.Visible = true;
                    sayfagecis = 2;
                }
                else if (ametin.Length > 2550)
                {
                    btnsayfa1.Text = ametin.Substring(2039, 510);
                    btnsayfa2.Text = ametin.Substring(2549, ametin.Length - 2549);
                    btnGeri.Visible = true;
                    sayfagecis = 2;
                }
            

                ametin = "";
                baglanti.Close();
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            //--------------------DEĞİŞKEN ALANI----------------------------
           
           // label5.Visible = true;

            

            if (kontroldeger == 1)
            {

                int sayac2 = 1; int baglantisayaci = 0; int asci = 0; int sayac = 0;
                string pr_sql = ""; string sonuc = "";
                string sifrelenentext = ""; string[] sifreDizi = new string[4];
                Random rastgele = new Random();

                baglanti.Open();

                while (sayac < textBox1.TextLength)
                {
                    
                    asci = Convert.ToInt32(Convert.ToChar(textBox1.Text.Substring(sayac, 1)));
                    pr_sql = "SELECT SIFRE_METNI FROM sifrelemeTablosu WHERE ASCI = " + asci;
                    
                    OleDbCommand komut = new OleDbCommand(pr_sql, baglanti);
                    OleDbDataReader dr = komut.ExecuteReader();
                    if (dr.HasRows == true)
                    {
                        while (dr.Read())
                        {
                            sifreliMetin = dr.GetString(0);
                        }
                    }
                    
                    for (int i = 0; i < 4; i++)
                    {
                        sifreDizi[i] = sifreliMetin.Substring(sayac2, 4);
                        sayac2 = sayac2 + 6;
                    }
                    sayac2 = 1;
                    sonuc = Convert.ToChar(rastgele.Next(33, 127)) + sifreDizi[rastgele.Next(4)] + Convert.ToChar(rastgele.Next(33, 127));
                    sifrelenentext += sonuc;
                    if (baglantisayaci > 500)
                    {
                        dr.Close();
                    }
                    baglantisayaci++;
                    sayac++;
                }





                //string gun = tarih.Substring(15, tarih.Length - 15);
                // string ay = tarih.Substring(
                OleDbCommand eklemekomut = new OleDbCommand("insert into Gunlukler (K_ID,Metin,Gun,Yil,Ay) values (@kid,@metin,@gun,@yil,@ay)", baglanti);
                eklemekomut.Parameters.AddWithValue("@kid", id1);
                eklemekomut.Parameters.AddWithValue("@metin", sifrelenentext);
                eklemekomut.Parameters.AddWithValue("@gun", gun);
                eklemekomut.Parameters.AddWithValue("@yil", DateTime.Now.Year);
                eklemekomut.Parameters.AddWithValue("@ay", ay);

                eklemekomut.ExecuteNonQuery();

                baglanti.Close();

                textBox2.Text = sifrelenentext;


                
                MessageBox.Show("Günlük Kayıt İşlemi Başarılı");
            }
           

            label5.Visible = false;

        }

        private void button5_Click(object sender, EventArgs e)
        {
           


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


            ArrayList Aylar = new ArrayList();
            OleDbCommand komutay = new OleDbCommand("select Ay from Gunlukler where K_ID = @pkid and Yil = @pyil", baglanti);
            komutay.Parameters.AddWithValue("@pkid", id1);
            komutay.Parameters.AddWithValue("æpyil", comboBox1.SelectedItem);
            baglanti.Open();
            OleDbDataReader dr = komutay.ExecuteReader();
            if (dr.HasRows == true)
            {
                while (dr.Read())
                {
                    string ay = dr.GetString(0);
                    if (!Aylar.Contains(ay))
                        Aylar.Add(ay);
                }


            }

            comboBox2.Items.Clear();
            comboBox2.Text = "Ay Seçin";
            comboBox3.Items.Clear();
            comboBox3.Text = "Gün Seçin";

            foreach (string line in Aylar)
            {
                comboBox2.Items.Add(line);
            }

            baglanti.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            comboBox1.Text = "Yil seçin";
            textBox1.Text = "";
            textBox2.Text = "";
            OleDbCommand komutyil = new OleDbCommand("select Yil from Gunlukler where K_ID = @pkid", baglanti);
            komutyil.Parameters.AddWithValue("@pkid", id1);
            baglanti.Open();
            OleDbDataReader dr = komutyil.ExecuteReader();
            if (dr.HasRows == true)
            {
                while (dr.Read())
                {
                    int yil = dr.GetInt32(0);
                    if (!Yillar.Contains(yil))
                        Yillar.Add(yil);
                }


            }

            foreach (int line in Yillar)
            {
                comboBox1.Items.Add(line);
            }

            baglanti.Close();

            label1.Visible = false;
            textBox2.Visible = false;
            btnsayfa1.Text = "";
            btnsayfa2.Text = "";

            label7.Visible = true;
            label8.Visible = true;
            label9.Visible = true;
            comboBox1.Visible = true;
            comboBox2.Visible = true;
            comboBox3.Visible = true;
            button1.Visible = true;
            label4.Visible = false;
            textBox1.Visible = false;
            button3.Visible = false;
            btnOku.Visible = false;
            checkBox1.Visible = false;
            checkBox1.Checked = false;


        }





        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            ArrayList Gunler = new ArrayList();
            OleDbCommand komutgun = new OleDbCommand("select Gun from Gunlukler where K_ID = @pkid and Yil = @pyil and  Ay=@ay", baglanti);
            komutgun.Parameters.AddWithValue("@pkid", id1);
            komutgun.Parameters.AddWithValue("@pyil", comboBox1.SelectedItem);
            komutgun.Parameters.AddWithValue("@ay", comboBox2.SelectedItem);

            baglanti.Open();
            OleDbDataReader dr = komutgun.ExecuteReader();
            if (dr.HasRows == true)
            {
                while (dr.Read())
                {
                    Gunler.Add(dr.GetString(0));
                }


            }

            comboBox3.Items.Clear();
            comboBox3.Text = "Gün Seçin";

            foreach (string line in Gunler)
            {
                comboBox3.Items.Add(line);
            }

            baglanti.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            btnsayfa1.Text = "";
            btnsayfa2.Text = "";
            btnileri.Visible = false;
            btnGeri.Visible = false;
            string metin = textBox1.Text;
            if (metin.Length < 510)
                btnsayfa1.Text = textBox1.Text;
            else if (metin.Length > 510 && metin.Length < 1020)
            {
                btnsayfa1.Text = textBox1.Text.Substring(0, 510);
                btnsayfa2.Text = textBox1.Text.Substring(510,textBox1.TextLength - 510 );
            }
            else if (metin.Length > 1020 && metin.Length < 1530)
            {
                btnsayfa1.Text = textBox1.Text.Substring(1019, textBox1.TextLength - 1019);
                btnGeri.Visible = true;
                sayfagecis = 1;

            }
            else if (metin.Length > 1530 && metin.Length < 2040)
            {
                btnsayfa1.Text = textBox1.Text.Substring(1019, 510);
                btnsayfa2.Text = textBox1.Text.Substring(1529, textBox1.TextLength - 1529);
                btnGeri.Visible = true;
                sayfagecis = 1;
            }
            else if (metin.Length > 2040 && metin.Length < 2550)
            {
                btnsayfa1.Text = textBox1.Text.Substring(2039, textBox1.TextLength - 2039);
                btnGeri.Visible = true;
                sayfagecis = 2;
            }
            else if (metin.Length > 2550)
            {
                btnsayfa1.Text = textBox1.Text.Substring(2039, 510);
                btnsayfa2.Text = textBox1.Text.Substring(2549, textBox1.TextLength - 2549);
                btnGeri.Visible = true;
                sayfagecis = 2;
            }
            

        }

        private void btnileri_Click(object sender, EventArgs e)
        {
            string metin = textBox1.Text;
            if (sayfagecis == 0)
            {

                 if (metin.Length > 1020 && metin.Length < 1530)
               {
                btnsayfa1.Text = textBox1.Text.Substring(1019, textBox1.TextLength - 1019);
                btnsayfa2.Text = "";
                btnGeri.Visible = true;
                btnileri.Visible = false;
                sayfagecis = 1;

               }
            else if (metin.Length > 1530)
              {
                btnsayfa1.Text = textBox1.Text.Substring(1019, 510);
                btnsayfa2.Text = textBox1.Text.Substring(1529, textBox1.TextLength - 1529);
                btnGeri.Visible = true;
                btnileri.Visible = false;
                sayfagecis = 1;
               }

            }

            else if (sayfagecis == 1)
            {

             
             if (metin.Length > 2040 && metin.Length < 2550)
               {
                btnsayfa1.Text = textBox1.Text.Substring(2039, textBox1.TextLength - 2039);
                btnsayfa2.Text = "";
                btnGeri.Visible = true;
              //  btnileri.Visible = false;
                sayfagecis = 2;
               }

                 else if (metin.Length > 2550)
                {
                btnsayfa1.Text = textBox1.Text.Substring(2039, 510);
                btnsayfa2.Text = textBox1.Text.Substring(2549, textBox1.TextLength - 2549);
                btnGeri.Visible = true;
            //    btnileri.Visible = false;
                sayfagecis = 2;
                }

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            comboBox1.Visible = false;
            comboBox2.Visible = false;
            comboBox3.Visible = false;
            button1.Visible = false;
            label4.Visible = true;
            textBox1.Visible = true;
            button3.Visible = true;
            checkBox1.Visible = true;
            btnOku.Visible = true;
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            textBox1.Text = "";
            btnsayfa2.Text = "";
            btnsayfa1.Text = "";
            btnileri.Visible = false;
            btnGeri.Visible = false;

            

            


        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                label1.Visible = true;
                textBox2.Visible = true;
            }
            else
            {
                label1.Visible = false;
                textBox2.Visible = false;
            }  

        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            if (sayfagecis == 1)
            {
                btnsayfa1.Text = textBox1.Text.Substring(0, 510);
                btnsayfa2.Text = textBox1.Text.Substring(510, 510);
                btnGeri.Visible = false;
                btnileri.Visible = true;
                sayfagecis = 0;
            }
            else if (sayfagecis == 2)
            {
                btnsayfa1.Text = textBox1.Text.Substring(1019, 510);
                btnsayfa2.Text = textBox1.Text.Substring(1530,510);
                btnileri.Visible = true;
                sayfagecis = 1;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button3_MouseDown(object sender, MouseEventArgs e)
        {
            btnOku.Enabled = true;
            
            btnileri.Visible = false;
            btnGeri.Visible = false;

            gun = DateTime.Now.Date.DayOfWeek.ToString();

            if (gun == "Monday")
                gun = "Pazartesi";
            else if (gun == "Tuesday")
                gun = "Salı";
            else if (gun == "Wednesday")
                gun = "Carsamba";
            else if (gun == "Thursday")
                gun = "Persembe";
            else if (gun == "Friday")
                gun = "Cuma";
            else if (gun == "Saturday")
                gun = "Cumartesi";
            else if (gun == "Sunday")
                gun = "Pazar";

            tarih = DateTime.Now.Date.ToLongDateString();
            gun = DateTime.Now.Day.ToString() + "-" + gun;
            ay = tarih.Substring(3, (tarih.Length - gun.Length - 6));


            //--------------------------------------------------------------- 

            OleDbCommand kontrolkomut = new OleDbCommand("select K_ID from Gunlukler where K_ID=@kid and Yil=@yil and Ay=@ay and Gun=@gun", baglanti);
            kontrolkomut.Parameters.AddWithValue("@kid", id1);
            kontrolkomut.Parameters.AddWithValue("@yil", DateTime.Now.Year);
            kontrolkomut.Parameters.AddWithValue("@ay", ay);
            kontrolkomut.Parameters.AddWithValue("@gun", gun);
            baglanti.Open();
            OleDbDataReader drdonen = kontrolkomut.ExecuteReader();
            if (drdonen.HasRows == true)
            {
                MessageBox.Show("Zaten bugün günlük yazdınız!");

            }
            else
            {
                kontroldeger = 1; label5.Visible = true;
            }
            baglanti.Close();
            
        }

    }
}


