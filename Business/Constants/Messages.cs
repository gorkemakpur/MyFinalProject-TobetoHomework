using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    //sürekli newlememek için sabit olduğu için statik yapıyoruz
    public static class Messages
    {
        //public değişkenler pascal case ile yazılır
        public static string ProductAdded = "Ürün Eklendi";
        public static string ProductUpdated = "Ürün Güncellendi";
        public static string ProductDeleted = "Ürün Silindi";
        public static string ProductListed = "Ürünler Listelendi";
        public static string MaintenanceTime = "Sistem Bakımda";
        public static string ProductNameInvalid = "Ürün Adı Geçersiz";
        public static string ProductCountOfCategoryError = "Bir kategoride en fazla 10 ürün olabilir";
        public static string ProductNameAlreadyExists = "Böyle bir ürün var";
    }
}
