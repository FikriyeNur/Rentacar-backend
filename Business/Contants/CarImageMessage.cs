using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Contants
{
    public static class CarImageMessage
    {
        public static string CarImageAdded="Araç resmi yükleme işlemi başarıyla gerçekleşti.";
        public static string CarImageUpdated = "Araç resmi güncelleme işlemi başarıyla gerçekleşti.";

        public static string CarImageDeleted = "Araç resmi silme işlemi başarıyla gerçekleşti.";
        public static string FailedCarImageDeleted = "Geçersiz Id girdiniz. Araç resmi silme işlemi gerçekleştirilemedi.";

        public static string FailedCarImageListed = "Araç resimleri listelenirken beklenmeyen bir hata oluştu!";
        public static string CarImageLimitExceded="Bir arabaya ait en fazla 5 resim ekleyebilirsiniz!!";
    }
}
