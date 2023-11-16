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
        public static string ProductNameInvalid = "Ürün Adı Geçersiz";
    }
}
