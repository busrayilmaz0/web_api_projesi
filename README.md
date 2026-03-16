# Departman Bazlı Uygulama Yönetim API'si 🏢⚙️

Bu proje, şirket çalışanlarının departmanlarına özel olarak yetkilendirildiği ve yalnızca kendi departmanlarına ait çalıştırılabilir dosyaları (.exe) listeleyebildiği özel bir Web API çözümüdür.

## 🚀 Projenin Amacı
Şirket içi bilgi işlem ve yetki kontrol süreçlerini otomatize etmek amacıyla geliştirilmiştir. Çalışanlar sisteme güvenli bir şekilde kaydolur ve giriş yaptıklarında karmaşadan uzak, yalnızca kendi rollerinin (departmanlarının) gerektirdiği uygulamalara erişim sağlarlar.

## ✨ Temel Özellikler
* **Güvenli Personel Kaydı:** Çalışanlar T.C. Kimlik Numarası, kullanıcı adı ve şifre gibi kritik bilgilerle veritabanına güvenli bir şekilde kaydedilir.
* **Departman Bazlı Yetkilendirme:** Sisteme kullanıcı adı, şifre ve departman bilgisiyle giriş (Login) yapılır.
* **Dinamik Uygulama Listeleme:** Başarılı giriş sonrasında, kullanıcının departmanına özel `.exe` dosyaları getirilir (Örn: *Bilgisayar Mühendisliği departmanı için `cmd.exe` listelenmesi*).
* **Yüksek Performans:** Arka planda **Thread** yapıları kullanılarak işlemlerin birbirini engellemeden, asenkron ve hızlı bir şekilde yürütülmesi sağlanmıştır.
* **Sistem Entegrasyonu:** İşletim sistemi seviyesindeki ayarlar, dosya yolları ve yapılandırmalar için **Regedit (Kayıt Defteri)** mimarisi kullanılmıştır.

## 🛠️ Kullanılan Teknolojiler
* **Geliştirme Ortamı/Dil:** [Örn: C#, .NET Core vb.]
* **Veritabanı:** [Örn: MS SQL Server, PostgreSQL, MySQL vb.]
* **Mimari & Yapılar:** Web API, Threading, Windows Registry (Regedit) İsteği

## ⚙️ Kurulum ve Çalıştırma
1. Bu depoyu bilgisayarınıza klonlayın.
2. `[Veritabanı bağlantı cümlenizi]` projenin ilgili ayar dosyasına (örn: `appsettings.json`) ekleyin.
3. Veritabanı tablolarını oluşturmak için gerekli scriptleri/migration komutlarını çalıştırın.
4. API projesini derleyip çalıştırarak endpoint'leri (kayıt, giriş, listeleme) test edebilirsiniz.
