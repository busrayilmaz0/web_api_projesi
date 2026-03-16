using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using static webAPI.Model.PersonelModel;

namespace webAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonelController : ControllerBase
    {
        public class Sonuc
        {
            public string SonucKodu { get; set; }
            public string SonucMesaji { get; set; }
        }
        public class ListeSonuc : Sonuc
        {
            public List<Personel> Liste { get; set; }
        }
        string adres = @"Data Source=(local);Initial Catalog=PersonelKayitDatabase;Integrated Security=True;TrustServerCertificate=True";

        //Yazılım şirketinde çalışan personellerin tc kimlik numarası,ad,soyad,kullanıcı adı,parola,departman bilgilerini tutan bir personel kayıt sistemi metodu.
        [HttpPost("PersonelKaydet")]
        
        public IActionResult PersonelKaydet([FromBody] Personel p)
        {
            Sonuc sonuc = new Sonuc();
            SqlConnection con = new SqlConnection(adres);


            if (string.IsNullOrEmpty(p.TcKimlikNo) || p.TcKimlikNo.Length !=11)
            {
                sonuc.SonucKodu = "100";
                sonuc.SonucMesaji = "Tc kimlik no giriniz.";
                return new JsonResult(sonuc);
            }
            if (string.IsNullOrEmpty(p.Ad))
            {
                sonuc.SonucKodu = "101";
                sonuc.SonucMesaji = "Adınızı giriniz.";
                return new JsonResult(sonuc);
            }
            if (string.IsNullOrEmpty(p.Soyad))
            {
                sonuc.SonucKodu = "102";
                sonuc.SonucMesaji = "Soyadınızı giriniz.";
                return new JsonResult(sonuc);
            }
            if (string.IsNullOrEmpty(p.KullaniciAdi))
            {
                sonuc.SonucKodu = "103";
                sonuc.SonucMesaji = "Kullanıcı adını giriniz.";
                return new JsonResult(sonuc);
            }
            if (string.IsNullOrEmpty(p.Departman))
            {
                sonuc.SonucKodu = "104";
                sonuc.SonucMesaji = "Departman bilgisini giriniz.";
                return new JsonResult(sonuc);
            }


            try
            {
                con.Open();
                SqlCommand cmdd = new SqlCommand(@"SELECT COUNT(*) 
              FROM Personel 
              WHERE 
                (TcKimlikNo = @TcKimlikNo OR KullaniciAdi = @KullaniciAdi)
                AND KayitKontrol = 'Kayitli'", con);
                cmdd.Parameters.AddWithValue("@TcKimlikNo", p.TcKimlikNo);
                cmdd.Parameters.AddWithValue("@KullaniciAdi", p.KullaniciAdi);
                int sayi = (int)cmdd.ExecuteScalar();

                if (sayi > 0)
                {
                    sonuc.SonucKodu = "105";
                    sonuc.SonucMesaji = "Tc Kimlik No veya Kullanıcı Adı daha önce alınmış";
                    return new JsonResult(sonuc);
                }

              
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText =
                @"INSERT INTO Personel
                (TcKimlikNo, Ad, Soyad, KullaniciAdi, Parola, Departman, KayitKontrol)
                VALUES
                (@TcKimlikNo, @Ad, @Soyad, @KullaniciAdi, @Parola, @Departman, @KayitKontrol)";

                cmd.Parameters.AddWithValue("@TcKimlikNo", p.TcKimlikNo);
                cmd.Parameters.AddWithValue("@Ad", p.Ad);
                cmd.Parameters.AddWithValue("@Soyad", p.Soyad);
                cmd.Parameters.AddWithValue("@KullaniciAdi", p.KullaniciAdi);
                cmd.Parameters.AddWithValue("@Parola", p.Parola);
                cmd.Parameters.AddWithValue("@Departman", p.Departman);
                cmd.Parameters.AddWithValue("@KayitKontrol", "Kayitli");
                cmd.ExecuteNonQuery();
                sonuc.SonucKodu = "000";
                sonuc.SonucMesaji = "Kayıt başarıyla oluşturuldu.";
            }
            catch (Exception ex)
            {
                sonuc.SonucKodu = "201";
                sonuc.SonucMesaji = "Hata mesajı: " + ex.Message;

            }
            finally
            {
                if(con.State == ConnectionState.Open)
                    con.Close();    
            }

            return new JsonResult(sonuc);
        }
        
        // Yazılım şirketine daha önceden yapılan kayıtları silmek için kullanılan metod.
        [HttpDelete("PersonelSil")]
        public IActionResult PersonelSil([FromBody] string TcKimlikNo)
        {
            Sonuc sonuc = new Sonuc();
            SqlConnection con = new SqlConnection(adres);

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Personel WHERE TcKimlikNo = @TcKimlikNo",
            con);
                cmd.Parameters.AddWithValue("@TcKimlikNo", TcKimlikNo);
                int KayitliPersonel = cmd.ExecuteNonQuery();
                if (KayitliPersonel> 0)
                {
                    sonuc.SonucKodu = "003";
                    sonuc.SonucMesaji = "Kayıt başarı ile silindi.";
                }
                else
                {
                    sonuc.SonucKodu = "203";
                    sonuc.SonucMesaji = " Girilen tc kimlik numarası hatalı.";
                }
            }
            catch (Exception ex)
            {
                sonuc.SonucKodu = "201";
                sonuc.SonucMesaji = "Hata: " + ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            return new JsonResult(sonuc);
        }
        //Giriş yapan personelin kullanıcı adı,parola ve departman bilgilerini kontrol eden metod.
        [HttpPost("GirisYap")]
        public IActionResult GirisYap([FromBody] Personel p)
        {
            Sonuc sonuc = new Sonuc();
            SqlConnection con = new SqlConnection(adres);

            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                // Departman bilgisi de kontrol ediliyor.
                cmd.CommandText = "SELECT COUNT(*) FROM Personel WHERE KullaniciAdi=@KullaniciAdi AND Parola=@Parola AND Departman=@Departman";

                cmd.Parameters.AddWithValue("@KullaniciAdi", p.KullaniciAdi);
                cmd.Parameters.AddWithValue("@Parola", p.Parola);
                cmd.Parameters.AddWithValue("@Departman", p.Departman); 

                int kayitSayisi = Convert.ToInt32(cmd.ExecuteScalar());

                if (kayitSayisi > 0)
                {
                    sonuc.SonucKodu = "120";
                    sonuc.SonucMesaji = "Giriş başarılı.";
                }
                else
                {
                    sonuc.SonucKodu = "121";
                    sonuc.SonucMesaji = "Kullanıcı adı, parola veya departman hatalı.";
                }
            }
            catch (Exception ex)
            {
                sonuc.SonucKodu = "500";
                sonuc.SonucMesaji = "Hata: " + ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }

            return new JsonResult(sonuc);
        }
    }
}
