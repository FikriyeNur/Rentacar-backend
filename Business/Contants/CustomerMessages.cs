using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Contants
{
    public class CustomerMessages
    {
        public static string CustomerAdded = "Müşteri ekleme işlemi başarıyla gerçekleşti.";
        public static string CustomerUpdated = "Müşteri güncelleme işlemi başarıyla gerçekleşti.";
        public static string FailedCustomerInformation = "Bilgileri eksiksiz girdiğinizden emin olunuz!!";

        public static string CustomerDeleted = "Müşteri silme işlemi başarıyla gerçekleşti.";
        public static string FailedCustomerDeleted = "Geçersiz Id girdiniz. Müşter silme işlemi gerçekleştirilemedi.";

        public static string FailedCustomerListed = "Müşteriler listelenirken beklenmeyen bir hata oluştu!";

        public static string FailedCustomerById = "Girdiğiniz Id'ye ait müşteri bulunamadı!!";
    }
}
