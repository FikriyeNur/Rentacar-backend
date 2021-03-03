using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public class CarMessages
    {
        public static string CarAdded = "Araç ekleme işlemi başarıyla gerçekleşti.";
        public static string CarUpdated = "Araç güncelleme işlemi başarıyla gerçekleşti.";

        public static string CarDeleted = "Araç silme işlemi başarıyla gerçekleşti.";
        public static string FailedCarDeleted = "Geçersiz Id girdiniz. Araç silme işlemi gerçekleştirilemedi.";

        public static string FailedCarListed = "Araçlar listelenirken beklenmeyen bir hata oluştu!";

        public static string FailedCarById = "Girdiğiniz Id'ye ait araç bulunamadı!!";

    }
}
