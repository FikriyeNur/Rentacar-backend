using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
