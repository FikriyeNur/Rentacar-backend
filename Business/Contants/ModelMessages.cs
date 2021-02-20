using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Contants
{
    public class ModelMessages
    {
        public static string ModelAdded = "Model ekleme işlemi başarıyla gerçekleşti.";
        public static string ModelUpdated = "Model güncelleme işlemi başarıyla gerçekleşti.";

        public static string ModelDeleted = "Model silme işlemi başarıyla gerçekleşti.";
        public static string FailedModelDeleted = "Geçersiz Id girdiniz. Model silme işlemi gerçekleştirilemedi.";

        public static string FailedModelListed = "Modeller listelenirken beklenmeyen bir hata oluştu!";

        public static string FailedModelById = "Girdiğiniz Id'ye ait model bulunamadı!!";
    }
}
