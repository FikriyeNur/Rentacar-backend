using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public class PaymentMessages
    {
        public static string PaymentAdded = "Ödeme işlemi başarıyla gerçekleşti.";
        public static string PaymentUpdated = "Kart bilgileri başarıyla güncellendi.";

        public static string PaymentDeleted = "Kart silme işlemi başarıyla gerçekleşti.";
        internal static string FailedPaymentDeleted = "Geçersiz Id girdiniz. Kart silme işlemi gerçekleştirilemedi.";

        public static string FailedPaymentListed = "Ödeme bilgileri listelenirken beklenmeyen bir hata oluştu!";

        public static string FailedPaymentById = "Girdiğiniz Id'ye ait ödeme bilgisi bulunamadı!!";

        public static string VerifiedCard = "Kart bilgileri doğrulama işlemi başarıyla gerçekleşti.";
        public static string FailedVerifiedCard = "Kart bilgileri doğrula işlemi gerçekleştirilemedi. Lütfen bilgilerinizi kontrol ediniz!";

    }
}
