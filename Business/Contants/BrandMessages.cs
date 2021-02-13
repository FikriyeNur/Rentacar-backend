using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Contants
{
    public class BrandMessages
    {
        public static string BrandAdded = "Marka ekleme işlemi başarıyla gerçekleşti.";
        public static string BrandUpdated = "Marka güncelleme işlemi başarıyla gerçekleşti.";
        public static string FailedBrandInformation = "Marka ismi 2 karakterden fazla olmalıdır!! Lütfen geçerli marka giriniz.";

        public static string BrandDeleted = "Marka silme işlemi başarıyla gerçekleşti.";
        public static string FailedBrandDeleted = "Geçersiz Id girdiniz. Marka silme işlemi gerçekleştirilemedi.";

        public static string FailedBrandListed = "Markalar listelenirken beklenmeyen bir hata oluştu!";

        public static string FailedBrandById = "Girdiğiniz Id'ye ait marka bulunamadı!!";
    }
}
