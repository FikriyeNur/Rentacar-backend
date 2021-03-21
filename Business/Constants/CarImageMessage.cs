using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class CarImageMessage
    {
        public static string CarImageAdded = "Araç resmi başarıyla eklendi.";

        public static string CarImageUpdated = "Araç resmi başarıyla güncellendi.";
        public static string FailedCarImageUpdated = "Araç resmi güncelleme işlemi gerçekleştirilemedi.";

        public static string CarImageDeleted = "Araç resmi silindi.";
        public static string FailedCarImageDeleted = "Geçersiz Id girdiniz. Araç resmi silme işlemi gerçekleştirilemedi.";

        public static string FailedCarImageListed = "Araç resimleri listelenirken beklenmeyen bir hata oluştu!";
        public static string CarImageLimitExceded = "Bir arabaya ait en fazla 5 resim ekleyebilirsiniz!!";

        public static string FailedCarImagesById = "Girdiğiniz Id'ye ait araç resmi bulunamadı!!";
    }
}
