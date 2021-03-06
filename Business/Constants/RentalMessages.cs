using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
   public class RentalMessages
    {
        public static string RentalAdded = "Araç kiralama işlemi başarıyla gerçekleşti.";
        public static string RentalUpdated = "Araç kiralama işlemi güncellendi.";
        public static string FailedRentalInformation = "Kiralamak istediğiniz araç henüz teslim edilmediği için kiralama işlemi yapılamamaktadır!";

        public static string RentalDeleted = "Araç kiralama işlemi iptal edildi.";
        public static string FailedRentalDeleted = "Araç kiralama işlemi iptalinde hata meydana geldi!!";

        public static string FailedRentalListed = "Araç kiralama bilgileri listelenirken beklenmeyen bir hata oluştu!";

        public static string RentalAvaible = "Kiralamak istediğiniz araç müsait.";
    }
}
