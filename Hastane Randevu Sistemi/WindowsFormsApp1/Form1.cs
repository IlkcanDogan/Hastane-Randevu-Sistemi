using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            #region
            cbBobrek.Enabled = false;
            cbDiyabet.Enabled = false;
            cbIshal.Enabled = false;
            cbKanser.Enabled = false;

            txtKayitOnay.Enabled = false;
            #endregion

            int i = 0;
            for (int yil = 1800; yil < 2021; yil++)
            {
                i++;
                if (i <= 31)
                    cmbGun.Items.Add(i);

                if (i <= 12)
                    cmbAy.Items.Add(i);

            
                cmbYil.Items.Add(yil);
               
            }
            

        }

        private void rbEvet_CheckedChanged(object sender, EventArgs e)
        {
            if(rbEvet.Checked == true)
            {
                cbBobrek.Enabled = true;
                cbDiyabet.Enabled = true;
                cbIshal.Enabled = true;
                cbKanser.Enabled = true;
            }

        }

        private void rbHayir_CheckedChanged(object sender, EventArgs e)
        {
            if(rbHayir.Checked == true) {
                cbBobrek.Enabled = false;
                cbDiyabet.Enabled = false;
                cbIshal.Enabled = false;
                cbKanser.Enabled = false;
            }
        }

        private void cmbGun_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbSifreGoster_CheckedChanged(object sender, EventArgs e)
        {
            if(cbSifreGoster.Checked == true)
            {
                txtKayitSifre.UseSystemPasswordChar = false;
                txtKayitOnay.UseSystemPasswordChar = false;
            }
            else
            {
                txtKayitSifre.UseSystemPasswordChar = true;
                txtKayitOnay.UseSystemPasswordChar = true;
            }
        }

        private void txtKayitSifre_TextChanged(object sender, EventArgs e)
        {
            if(txtKayitSifre.Text == string.Empty)
            {
                txtKayitOnay.Enabled = false;
            }
            else
            {
                txtKayitOnay.Enabled = true;
                txtKayitOnay.Clear();
            }
        }

        int randomSifre;
        Random randomSifreUret = new Random();
        private void btnSifreUret_Click(object sender, EventArgs e)
        {

            randomSifre = randomSifreUret.Next(0,10000001);

            txtKayitSifre.Text = Convert.ToString(randomSifre);

            txtKayitOnay.Text = randomSifre.ToString();
        }

        
        string ad, soyad, kullaniciAdi, sifre;

        private void txtKullaniciAdi_TextChanged(object sender, EventArgs e)
        {
            timer1.Start();
        }
        int sayac = 60;

        private void timer1_Tick(object sender, EventArgs e)
        {
            sayac--;
            lblSayac.Text = Convert.ToString(sayac);

            if (sayac == 0)
            {
                txtKullaniciAdi.Enabled = false;
                txtSifre.Enabled = false;

                txtKullaniciAdi.Clear();
                txtSifre.Clear();

                btnGirisYap.Enabled = false;
                btnGirisYap.BackColor = Color.Red;

                timer1.Stop();

            }
                

        }

        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            if (kullaniciAdi == txtKayitKullaniciAdi.Text && sifre == txtSifre.Text)
                MessageBox.Show("Doğru Giriş Yaptınız");
            else
                MessageBox.Show("Yanlış kullanıcı adı veya şifre");
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        string sehir;

       

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (txtKayitSifre.Text != txtKayitOnay.Text)
                MessageBox.Show("Şifreniz Uyuşmuyor. Düzeltin");
            else
            {
              
                try
                {
                    listBox1.Items.Clear();

                    ad = txtAd.Text;
                    soyad = txtSoyad.Text;
                    sifre = txtKayitSifre.Text;
                    kullaniciAdi = txtKayitKullaniciAdi.Text;

                    sehir = cmbSehir.SelectedItem.ToString();

                    
                    //blok
                    if(rbErkek.Checked == true)
                        listBox1.Items.Add("Cinsiyet: Erkek");
                    else if(rbErkek.Checked == false && rbKadin.Checked == false)
                        listBox1.Items.Add("Cinsiyet: Seçilmedi");
                    else
                        listBox1.Items.Add("Cinsiyet: Bayan");
                    //blok

                    if (rbEvli.Checked == true)
                        listBox1.Items.Add("Medeni Durum: Evli");
                    else if(rbEvli.Checked == false && rbBekar.Checked == false)
                        listBox1.Items.Add("Medeni Durum: Seçilmedi");
                    else
                        listBox1.Items.Add("Medeni Durum: Bekar");
                    //blok
                    
                    if(cmbSehir.SelectedIndex == 0)
                        listBox1.Items.Add("ŞEHİR: İzmir");
                    else if(cmbSehir.SelectedIndex == 1)
                        listBox1.Items.Add("ŞEHİR: Ankara");
                    else if(cmbSehir.SelectedIndex == 2)
                        listBox1.Items.Add("ŞEHİR: İstanbul");
                    else if(cmbSehir.SelectedIndex == 3)
                        listBox1.Items.Add("ŞEHİR: Muğla");
                    else
                        listBox1.Items.Add("ŞEHİR: Edirne");
                    //blok


                    if (rbEvet.Checked == true)
                    {
                        if(cbBobrek.Checked ==true)
                            listBox1.Items.Add("HASTALIK: Böbrek Yetmezliği");

                        if(cbDiyabet.Checked == true)
                            listBox1.Items.Add("HASTALIK: Diyabet");

                        if(cbIshal.Checked == true)
                            listBox1.Items.Add("HASTALIK: Karın Ağrısı");


                        if(cbKanser.Checked == true)
                            listBox1.Items.Add("HASTALIK: Kanser");
                    }
                    else if(rbEvet.Checked == false && rbHayir.Checked == false)
                        listBox1.Items.Add("HASTALIK: SEÇİLMEDİ");
                    else
                        listBox1.Items.Add("HASTALIK: YOK");
                    //blok

                    
                    
                   
                    listBox1.Items.Add("TARİH: " + cmbGun.SelectedItem.ToString() + "/" + cmbAy.SelectedItem.ToString() + "/" + cmbYil.SelectedItem.ToString());

                    listBox1.Items.Add("AD: " + ad);
                    listBox1.Items.Add("SOYAD: " + soyad);
                    listBox1.Items.Add("ŞİFRE: " + sifre);
                    listBox1.Items.Add("KULLANICI ADI: " + kullaniciAdi);

                   

                }
                catch (Exception)
                {

                   MessageBox.Show("Şehir Seç" );
                }

            }
        }
    }
}
