using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public class PaymentMessages
    {
        public static string CardAdded = "Kart ekleme işlemi başarıyla gerçekleşti.";
        public static string CardUpdated = "Kart bilgileri başarıyla güncellendi.";

        public static string CardDeleted = "Kart silme işlemi başarıyla gerçekleşti.";
        internal static string FailedCardDeleted = "Geçersiz Id girdiniz. Kart silme işlemi gerçekleştirilemedi.";

        public static string FailedCardListed = "Kart bilgileri listelenirken beklenmeyen bir hata oluştu!";

        public static string FailedCardById = "Girdiğiniz Id'ye ait kart bilgisi bulunamadı!!";
    }
}
