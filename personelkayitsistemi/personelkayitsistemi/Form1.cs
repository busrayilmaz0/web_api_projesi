using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace personelkayitsistemi
{
    public partial class Form1 : Form
    {
        string apiBaseUrl = "https://localhost:7202/api/Personel/";//veri tabanı bağlantısı için api adresi

        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            this.Load += Form1_Load;
        }

        //model sınıfları
        public class ApiSonuc
        {
            public string SonucKodu { get; set; }
            public string SonucMesaji { get; set; }
        }

        public class PersonelVerisi
        {
            public string TcKimlikNo { get; set; }
            public string Ad { get; set; }
            public string Soyad { get; set; }
            public string KullaniciAdi { get; set; }
            public string Parola { get; set; }
            public string Departman { get; set; }
            public string KayitKontrol { get; set; }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PanelOrtala();
            RegistryVerisiOku();
            listexe.Items.Clear();
            //parola karakteri gizleme için kullanılır

            textBox5.PasswordChar = '*'; // Kayıt ekranındaki parola
            textBox9.PasswordChar = '*'; // Giriş ekranındaki parola

            // Başlık kaydırma işlemi(sağ üstte başlık kendiliğinden kayar ve bu thread ile yapılır)
            Thread baslikThread = new Thread(BaslikKaydir);
            baslikThread.IsBackground = true;
            baslikThread.Start();
        }

        //başlık kaydırma metodu
        void BaslikKaydir()
        {
            string yazi = "   Personel Takip Sistemine Hoşgeldiniz :)  ";
            while (true)
            {
                try
                {
                    yazi = yazi.Substring(1) + yazi.Substring(0, 1);
                    this.Text = yazi;
                    Thread.Sleep(200);
                }
                catch { }
            }
        }
        //panel ortalama metodu(form açıldığında panel ortalanır)
        void PanelOrtala()
        {
            if (panelicerik != null && panelheader != null)
            {
                panelicerik.Left = (this.ClientSize.Width - panelicerik.Width) / 2;
                panelicerik.Top = panelheader.Bottom + 20;
            }
        }

        // Registry okuma ve yazma metotları
        void RegistryVerisiOku()
        {
            try
            {
                RegistryKey rKey = Registry.CurrentUser.OpenSubKey(@"Software\PersonelSistemi\Ayarlar");
                if (rKey != null)
                {
                    object gelenVeri = rKey.GetValue("SonKullaniciAdi");
                    if (gelenVeri != null) textBox10.Text = gelenVeri.ToString();
                    rKey.Close();
                }
            }
            catch { }
        }
        // Registry yazma metodu
        void RegistryyeYaz(string kadi)
        {
            try
            {
                RegistryKey rkey = Registry.CurrentUser.CreateSubKey(@"Software\PersonelSistemi\Ayarlar");
                rkey.SetValue("SonKullaniciAdi", kadi);
                rkey.Close();
            }
            catch { }
        }

        //kayıt butonu
        private async void btnkaydet_Click(object sender, EventArgs e)
        {
            {
                // Tc kimlik no kontrolü yapılır.tc kimlik no 11 haneli ve rakam olmalıdır.Girilmediği zaman hata mesajı verir.
                string girilenTc = textBox1.Text;
                long sayiSonucu;
                if (string.IsNullOrEmpty(girilenTc) || girilenTc.Length != 11 || !long.TryParse(girilenTc, out sayiSonucu))
                {
                    MessageBox.Show("Hata: TC Kimlik No 11 haneli ve rakam olmalıdır.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //  Ad kontrolü yapılır.Girilmediği zaman hata mesajı verir.
                if (string.IsNullOrEmpty(textBox2.Text))
                {
                    MessageBox.Show("Lütfen Personel Adını giriniz.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Soyad kontrolü yapılır.Girilmediği zaman hata mesajı verir.
                if (string.IsNullOrEmpty(textBox3.Text))
                {
                    MessageBox.Show("Lütfen Personel Soyadını giriniz.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kullanıcı Adı kontrolü yapılır.Girilmediği zaman hata mesajı verir.
                if (string.IsNullOrEmpty(textBox4.Text))
                {
                    MessageBox.Show("Lütfen Kullanıcı Adı belirleyiniz.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Parola kontrolü yapılır.Girilmediği zaman hata mesajı verir.
                if (string.IsNullOrEmpty(textBox5.Text))
                {
                    MessageBox.Show("Lütfen Parola giriniz.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Departman kontrolü yapılır.Girilmediği zaman hata mesajı verir.
                if (string.IsNullOrEmpty(comboBox1.Text))
                {
                    MessageBox.Show("Lütfen bir Departman seçiniz.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Tüm veriler doğruysa API'ye kayıt isteği gönderilir.
                try
                {
                    var yeniPersonel = new PersonelVerisi
                    {
                        TcKimlikNo = textBox1.Text,
                        Ad = textBox2.Text,
                        Soyad = textBox3.Text,
                        KullaniciAdi = textBox4.Text,
                        Parola = textBox5.Text,
                        Departman = comboBox1.Text,
                        KayitKontrol = "Kayitli"
                    };

                    using (HttpClient client = new HttpClient())
                    {
                        string json = JsonSerializer.Serialize(yeniPersonel);
                        var icerik = new StringContent(json, Encoding.UTF8, "application/json");

                        var cevap = await client.PostAsync(apiBaseUrl + "PersonelKaydet", icerik);
                        string gelenString = await cevap.Content.ReadAsStringAsync();

                        var secenekler = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                        var apiCevap = JsonSerializer.Deserialize<ApiSonuc>(gelenString, secenekler);

                        if (apiCevap != null && apiCevap.SonucKodu == "000")
                        {
                            MessageBox.Show(apiCevap.SonucMesaji);
                            Temizle();
                        }
                        else
                        {
                            MessageBox.Show(apiCevap != null ? apiCevap.SonucMesaji : "İşlem başarısız.");
                        }
                    }
                }
                catch (Exception hata)
                {
                    MessageBox.Show("Sunucu Bağlantı Hatası:\n" + hata.Message);
                }
            }
        }

        //Giriş butonu
        private async void btngiris_Click(object sender, EventArgs e)
        {
            // Kullanıcı adı kontrolü yapılır.Kullanıcı adı girilmediği zaman hata mesajı verir.
            if (string.IsNullOrEmpty(textBox10.Text))
            {
                MessageBox.Show("Lütfen Kullanıcı Adınızı giriniz.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Parola kontrolü yapılır.Parola girilmediği zaman hata mesajı verir.
            if (string.IsNullOrEmpty(textBox9.Text))
            {
                MessageBox.Show("Lütfen Parolanızı giriniz.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Departman kontrolü yapılır.Departman seçilmediği zaman hata mesajı verir.
            if (string.IsNullOrEmpty(comboBox2.Text))
            {
                MessageBox.Show("Lütfen Departmanınızı seçiniz.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                RegistryyeYaz(textBox10.Text);

                //API'ye giriş isteği gönderilir.
                var girisBilgisi = new PersonelVerisi
                {
                    KullaniciAdi = textBox10.Text,
                    Parola = textBox9.Text,
                    Departman = comboBox2.Text,

                    //Api tarafında kullanılmayan alanlar için varsayılan değerler atanır.

                    TcKimlikNo = "-",
                    Ad = "-",
                    Soyad = "-",
                    KayitKontrol = "-"
                };

                using (HttpClient client = new HttpClient())
                {
                    string json = JsonSerializer.Serialize(girisBilgisi);
                    var icerik = new StringContent(json, Encoding.UTF8, "application/json");

                    var cevap = await client.PostAsync(apiBaseUrl + "GirisYap", icerik);

                    // Cevap içeriğini okur
                    string gelenString = await cevap.Content.ReadAsStringAsync();

                    //Eğer sunucu hatası varsa kullanıcıya bildirir.Yani hata mesajı döndürür.

                    if (!cevap.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Sunucu Hatası: " + gelenString);
                        return;
                    }

                    var secenekler = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var apiCevap = JsonSerializer.Deserialize<ApiSonuc>(gelenString, secenekler);

                    if (apiCevap != null && apiCevap.SonucKodu == "120")
                    {
                        MessageBox.Show(apiCevap.SonucMesaji, "Giriş Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Eğer giriş başarılı ise exe listeleme metodu çağrılır.
                        ExeListele(comboBox2.Text);
                    }
                    else
                    {
                        // Mesajı daha açıklayıcı hale getirmek için kontrol eklenir.
                        string mesaj = (apiCevap != null && !string.IsNullOrEmpty(apiCevap.SonucMesaji))
                                        ? apiCevap.SonucMesaji
                                        : "Giriş başarısız. Bilgilerinizi kontrol ediniz.";

                        MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("Bağlantı hatası: " + hata.Message);
            }
        }
        // Yöneticinin departmanına göre exe listeleme metodu
        void ExeListele(string departman)
        {
            listexe.Items.Clear();

            if (departman == "Bilgisayar Mühendisi")
            {
                listexe.Items.Add("cmd.exe");
                listexe.Items.Add("powershell.exe");
            }
            else if (departman == "Yazılım Mühendisi")
            {
                listexe.Items.Add("calc.exe");
                listexe.Items.Add("excel.exe");
            }
            else
            {
                listexe.Items.Add("notepad.exe");
                listexe.Items.Add("mspaint.exe"); 
            }
        }

        // Seçilen exe dosyasını çalıştırma metodu
        private void btnExeAc_Click(object sender, EventArgs e)
        {
            if (listexe.SelectedItem != null)
            {
                try
                {
                    Process.Start(listexe.SelectedItem.ToString());
                }
                catch
                {
                    MessageBox.Show("Uygulama açılamadı.");
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir uygulama seçin.");
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        void Temizle()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            // Parola karakterini tekrar gizle
            textBox5.PasswordChar = '*';
            if (comboBox1.Items.Count > 0) comboBox1.SelectedIndex = -1;
        }

        private void btnGoz_Click(object sender, EventArgs e)
        {
            if (textBox5.PasswordChar == '*')
            {
                textBox5.PasswordChar = '\0'; // '\0' C#'ta "normal metin göster" demektir
                btnGoz.Text = "Gizle"; // Butonun yazısını değiştirelim (İsteğe bağlı)
            }
            else
            {
                textBox5.PasswordChar = '*'; // Tekrar gizle
                btnGoz.Text = "👁";
            }
        }
    }
}