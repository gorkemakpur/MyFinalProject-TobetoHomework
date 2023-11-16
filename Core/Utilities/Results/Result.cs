using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        // ikinci ctorun çalışması için :this ile bu sınıfın ctoruna (success) ile de tek parametreli ctoruna success yollanır
        public Result(bool success, string message) : this(success)
        {
            //get readonly dir ctor içinde set edilebilir dışında edilemez
            Message = message;
        }

        //tek parametre girilirse bu kısım tek çalıştırılır
        public Result(bool success)
        {
            //mesaj olmadan sadece girilen değer başarılı ya da başarısız şeklinde değer döndürmek için kullanılır
            Success = success;
        }

        public bool Success { get; }
        public string Message { get; }
    }
}
