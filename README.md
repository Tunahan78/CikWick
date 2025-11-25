🐣 CikWick: The Fast Food Frenzy




Uploading Ekran Kaydı 2025-11-25 201520.mp4…





CikWick, oyuncuların "Speedrun" (hız koşusu) mantığıyla en kısa sürede 5 ana hedefi (Yumurta) toplamaya çalıştığı, stratejik güçlendirmeler ve engeller içeren 3D bir platform oyunudur. Proje, temiz mimari prensipleri, modüler kod yapısı ve DOTween kütüphanesi kullanılarak geliştirilmiştir.

🎮 Oynanış Mekanikleri ve Özellikler
🏆 Ana Hedef: Speedrun Mücadelesi
Oyunun temel amacı, haritaya dağılmış 5 adet Yumurtayı (Egg) mümkün olan en kısa sürede toplamaktır.

İleri Sayan Zamanlayıcı: Klasik geri sayımın aksine, oyuncuları kendi rekorlarını kırmaya teşvik eden, ileriye doğru sayan bir kronometre sistemi bulunur.

⚡ Dinamik Etki Sistemi (Buffs & Debuffs)
Oyun alanındaki toplanabilir eşyalar (Wheat türevleri), oyuncunun fiziksel özelliklerini anlık olarak değiştirerek stratejik bir katman ekler:

🌾 Gold Wheat (Hızlandırıcı): Oyuncunun hareket hızını artırır (Speed Buff), hedeflere daha hızlı ulaşmayı sağlar.

🥀 Rotten Wheat (Yavaşlatıcı): Oyuncuyu zehirleyerek hareket hızını düşürür (Slow Debuff). Kaçınılması gereken bir engeldir.

✨ Holy Wheat (Zıplama Gücü): Oyuncunun zıplama kuvvetini artırır (Jump Buff), normalde ulaşılamayan yüksek platformlara erişim sağlar.

🛠️ Teknik Bilgiler ve Kullanılan Teknolojiler
Bu proje, Unity oyun motoru ve C# kullanılarak, genişletilebilir ve okunabilir bir kod tabanıyla geliştirilmiştir.

Kütüphaneler ve Araçlar
DOTween: UI geçişleri, toplanabilir eşya efektleri ve obje hareketlerindeki animasyonların pürüzsüzlüğü (smoothness) ve performansı için DOTween kullanılmıştır.

Proje Mimarisi
Proje, sorumlulukların ayrılığı (Separation of Concerns) ilkesine dayanır:

Scriptable Object / Inheritance: Collectibels klasöründeki buğday türleri (Gold, Rotten, Holy), ortak bir temel sınıftan türetilerek polimorfik bir yapı kurulmuştur. Bu sayede yeni etki türleri kolayca eklenebilir.

Managers (Yöneticiler):

GameManager: Oyunun kazanma koşulunu (5 Yumurta) ve oyun döngüsünü kontrol eder.

InputManager: Kullanıcı girdilerini tek bir noktadan yönetir.

UI Sistemi: Can, Süre ve Kazanma/Kaybetme ekranları modüler Popup scriptleri ile yönetilir.

📂 Dosya ve Script Yapısı
Projenin script klasör yapısı şu şekildedir:

_GameAssets/Scripts/Collectibels/: Eşya ve etkileşim mantıkları (GoldWheat.cs, RottenWheat.cs, Egg.cs).

_GameAssets/Scripts/Boosters/: Karakter yeteneklerini değiştiren güçlendirici mantıkları (SpatulaBooster.cs).

_GameAssets/Scripts/GamePlay/Player/: Karakter kontrolcüsü ve etkileşimleri (PlayerController.cs, PlayerInteractionController.cs).

_GameAssets/Scripts/UI/: Arayüz yönetimi (TimeUI.cs, WinLosePopupUI.cs).

📚 Eğitim Kaynağı
Bu proje, SkinnyDev (Hamza Kaan Çakmakçı) tarafından hazırlanan kapsamlı Unity kursu referans alınarak geliştirilmiş ve üzerine özgün mekanikler eklenmiştir.

Kaynak Video Bağlantısı : https://www.youtube.com/watch?v=KZ5V9xIwwcE&t=38500s
