﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        //System
        public static string MaintenanceTime = "Sistem bakımda";

        //Brand
        public static string BrandAdded = "Marka eklendi";
        public static string BrandDeleted = "Marka silindi";
        public static string BrandUpdated = "Marka güncellendi";
        public static string BrandsListed = "Markalar listelendi";

        //Car
        public static string CarValueInvalid = "Araç açıklaması en az 2 karakter ve günlük ücret 0'dan büyük olmalıdır";
        public static string CarAdded = "Araç eklendi";
        public static string CarDeleted = "Araç silindi";
        public static string CarUpdated = "Araç güncellendi";
        public static string CarsListed = "Araçlar listelendi";


        //Color
        public static string ColorAdded = "Renk eklendi";
        public static string ColorDeleted = "Renk silindi";
        public static string ColorUpdated = "Renk güncellendi";
        public static string ColorsListed = "Renkler listelendi";

        //User
        public static string UserAdded = "Kullanıcı eklendi";
        public static string UserDeleted = "Kullanıcı silindi";
        public static string UserUpdated = "Kullanıcı güncellendi";
        public static string UsersListed = "Kullanıcılar listelendi";

        //Customer
        public static string CustomerAdded = "Müşteri eklendi";
        public static string CustomerDeleted = "Müşteri silindi";
        public static string CustomerUpdated = "Müşteri güncellendi";
        public static string CustomersListed = "Müşteriler listelendi";

        //Rental
        public static string RentalAdded = "Kiralama gerçekleştirildi";
        public static string RentalDeleted = "Kiralama silindi";
        public static string RentalUpdated = "Kiralama güncellendi";
        public static string RentalsListed = "Kiralamalar listelendi";
        public static string TheCarIsAlreadyRented = "Araba henüz teslim edilmediği için yeni bir kiralama işlemi yapılamaz";

        //CarImage
        public static string CarImageAdded = "Araç fotoğrafı eklendi";
        //public static string CarImagesAdded = "Araç fotoğrafları eklendi";

        public static string CarImageDeleted = "Araç fotoğrafı silindi";
        //public static string CarImagesDeleted = "Araç fotoğrafları silindi";

        public static string CarImageUpdated = "Araç fotoğrafı güncellendi";
        //public static string CarImagesUpdated = "Araç fotoğrafları güncellendi";

        public static string CarImagesListed = "Araç fotoğrafları listelendi";

        public static string CountOfCarImagesError = "Bir araç için en fazla 5 adet fotoğraf yükleyebilirsiniz";

        public static string AuthorizationDenied = "Yetkiniz yok";

        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Sisteme giriş başarılı";
        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
        public static string AccessTokenCreated = "Access token başarıyla oluşturuldu";
        public static string CarNotFound = "Araç bulunamadı";
    }
}
