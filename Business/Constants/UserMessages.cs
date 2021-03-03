using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace Business.Contants
{
    public static class UserMessages
    {
        public static string UserAdded = "Kullanıcı ekleme işlemi başarıyla gerçekleşti.";
        public static string UserUpdated = "Kullanıcı güncelleme işlemi başarıyla gerçekleşti.";

        public static string UserDeleted = "Kullanıcı silme işlemi başarıyla gerçekleşti.";
        public static string FailedUserDeleted = "Geçersiz Id girdiniz. Kullanıcı silme işlemi gerçekleştirilemedi.";

        public static string FailedUserListed = "Kullanıcılar listelenirken beklenmeyen bir hata oluştu!";

        public static string FailedUserById = "Girdiğiniz Id'ye ait kullanıcı bulunamadı!!";

        public static string FailedOperationClaimListed = "Yetkilendirmeler listelenirken beklenmeyen bir hata oluştu!";

        public static string FailedEmail = "Girdiğiniz EMail adresine ait kullanıcı bulunamadı!!";

        public static string UserNotFound = "Kullanıcı bulunamadı!!";
        public static string PasswordError="Hatalı şifre!!";
        public static string SuccesfulLogin="Sisteme giriş başarılı.";
        public static string UserAlreadyExists="Bu kullanıcı sistemde mevcut!!";
        internal static string UserRegistered="Kullancı kayıt işlemi başarıyla gerçekleşti.";
        public static string AccessTokenCreated="Access Token başarıyla oluşturuldu.";
        public static string AuthorizationDenied="Bu işlemi yapmak için yetkiniz yok!!";
    }
}
