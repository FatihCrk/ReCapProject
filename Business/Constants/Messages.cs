﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarListed = "Araba Listelendi";
        public static string CarsListed = "Araçlar Listelendi";
        public static string CarAdded = "Araç eklendi";
        public static string CarNameInvalid = "Araç adı uygun değil";
        public static string CarUpdated = "Araç güncellendi";
        public static string CarDeleted = "Araç silindi";
        public static string BrandsListed = "Markalar listelendi";
        public static string BrandAdded = "Marka eklendi";
        public static string BrandUpdated = "Marka güncellendi";
        public static string BrandDeleted = "Marka silindi";

        public static string ColorAdded = "Renk eklendi";
        public static string ColorDeleted = "Renk silindi";
        public static string ColorUpdated = "Renk güncellendi";
        public static string ColorsListed = "Renkler Listelendi.";

        public static string UsersNotAdded = "Kullanıcı eklenemedi";
        public static string UsersInformationNotNull = "Kullanıcı bilgileri boş olamaz";
        public static string UserAdded = "Kullanıcı eklendi";
        public static string UserDeleted = "Kullanıcı silindi";
        public static string UsersNotUpdated = "Kullanıcı güncellenemedi";
        public static string UserUpdated = "Kullanıcı güncellendi";
        public static string UsersListed = "Kullanıcılar listelendi";
        public static string UserListed = "Kullanıcı listelendi";
        public static string CustomerAdded = "Müşteri eklendi";
        public static string CustomerNameInvalid = "Müşteri adı uygun değil";
        public static string CustomerUpdated = "Müşteri güncellendi";
        public static string CustomerDeleted = "Müşteri silindi";
        public static string MaintenanceTime = "Sistem bakımda";
        public static string CustomersListed = "Müşteriler listelendi";
        public static string RentalSuccess = "Araç kiralandı";
        public static string RentalNotAdded = "Araç kiralanamadı";
        public static string RentalDeleted = "Araç kiralama işlemi iptal edildi";
        public static string RentDateUpdated = "Araç kiralama tarihi güncellendi";
        public static string RentalNotUpdated = "Araç kiralama işlemi güncellenemedi";
        public static string RentalListed = "Araç kiralama işlemleri listelendi";
        public static string CarImageAdded = "Araç fotoğrafı eklendi";
        public static string CarImageDeleted = "Araç fotoğrafı silindi";
        public static string CarImageUpdated = "Araç fotoğrafı güncellendi";
        public static string CarImageLimitExceeded = "Araç fotoğrafı limiti aşıldı. En fazla 5 resim ekleyebilirsiniz";
        public static string AuthorizationDenied = "Yetkiniz yok";
        public static string UserRegistered = "Kayıt oldu";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Parola hatası";
        public static string SuccessfulLogin = "Giriş başarılı";
        public static string UserAlreadyExists = "Kullanıcı mevcut";
        public static string AccessTokenCreated = "Token oluşturuldu";
        public static string PriceMustBeGreaterThan = "Araç Fiyatı 10'dan büyük olmalıdır.";

        public static string CarCountOfBrandError = "Marka Sayısı 10'u geçemez.";

        public static string ThereIsAVehicleWithSameName = "Aynı İsimde araç var";

        public static string BrandLimitExceeded = "Marka sınırı: 10'dan fazla olduğu için araç eklenemedi.";

        public static string CarsNotListed = "Arabalar Listelenemedi.";

        public static string UnsupoortedImageExtension = "Dosya türü desteklenmediği için eklenemedi.";

        public static string ListedSuccessful = "Listeleme Başarılı";

        public static string UpdateSuccessful = "Güncelleştirme başarılı";
    }
}
