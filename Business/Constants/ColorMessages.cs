using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class ColorMessages
    {
        public static string ColorAdded = "Araç renk ekleme işlemi başarıyla gerçekleşti.";
        public static string ColorUpdated = "Araç renk güncelleme işlemi başarıyla gerçekleşti.";

        public static string ColorDeleted = "Araç renk silme işlemi başarıyla gerçekleşti.";
        public static string FailedColorDeleted = "Geçersiz Id girdiniz. Araç renk silme işlemi gerçekleştirilemedi.";

        public static string FailedColorListed = "Araç renkleri listelenirken beklenmeyen bir hata oluştu!";

        public static string FailedColorById = "Girdiğiniz Id'ye ait araç rengi bulunamadı!!";
    }
}
