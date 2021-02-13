using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Contants
{
    public class RentalMessages
    {
        public static string RentalAdded = "Araç kiralama işlemi başarıyla gerçekleşti.";
        public static string RentalUpdated = "Araç kiralama bilgileri başarıyla güncellendi.";
        public static string FailedRentalInformation = "Bilgileri eksiksiz girdiğinizden emin olunuz!!";

        public static string RentalDeleted = "Araç kiralama kayıt silme işlemi başarıyla gerçekleşti.";
        public static string FailedRentalDeleted = "Geçersiz Id girdiniz. Araç kiralama kayıt silme işlemi gerçekleştirilemedi.";

        public static string FailedRentalListed = "Araç kiralama listesinde beklenmeyen bir hata oluştu!";

        public static string FailedRentalById = "Girdiğiniz Id'ye ait araç kiralama kaydı bulunamadı!!";
    }
}
