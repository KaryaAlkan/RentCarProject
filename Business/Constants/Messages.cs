using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public class Messages
    {
        public static string CarAdded = "Araba Eklendi.";
        public static string InvalidCar = "Gecersiz araba.";
        public static string MaintenanceTime = "Sistem bakimda.";
        public static string CarListed = "Arabalar listelendi.";

        public static string UserAdded = "Kullanici eklendi.";
        public static string RentalAdded = "Kiralanmak icin eklendi.";
        public static string BrandAdded = "Marka eklendi.";
        public static string ColorAdded = "Renk eklendi.";
        public static string CustomerAdded = "Musteri eklendi.";

        public static string CustomerDeleted = "Musteri silindi";
        public static string CarDeleted = "Araba silindi";
        public static string UserDeleted = "Kullanici silindi";
        public static string RentalDeleted = "Kiralama iptal edildi.";
        public static string ColorDeleted = "Renk silindi";
        public static string BrandDeleted = "Marka silindi.";

        public static string CustomerUpdated = "Müşteri güncellendi";
        public static string CarUpdated = "Araba güncellendi";
        public static string UserUpdated = "Kullanıcı güncellendi";
        public static string RentalUpdated = "Satış güncellendi";
        public static string ColorUpdated = "Renk güncellendi";
        public static string BrandUpdated = "Marka guncellendi.";

        public static string CarNameInvalid = "Araba ismi geçersiz";
        public static string UserNameInvalid = "Kullanıcı ismi geçersiz";
        public static string CustomerNameInvalid = "Müşteri ismi geçersiz";

        public static string UserListed = "Kullanıcılar listelendi";
        public static string CustomerListed = "Müşteriler listelendi";
        public static string RentalListed = "Satışlar listelendi";
        public static string CarImageLimitExceeded = "5 den fazla resim eklenemez.";
        public static string AuthorizationDenied = "Yetkiniz yok.";
        public static string UserRegistered = "Kullanici kayit edildi.";
        public static string UserNotFound = "Kullanici bulunamadi.";
        public static string PasswordError = "Hatali sifre";
        public static string SuccessfulLogin = "Giris basarili";
        public static string UserAlreadyExists = "Kullanici mevcut";
        public static string AccessTokenCreated = "Token olusturuldu";
        internal static string BrandLimitExceded = "Marka limiti asildi.";
    }
}
