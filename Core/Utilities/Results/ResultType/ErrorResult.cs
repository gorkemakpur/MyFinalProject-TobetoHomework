using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results.ResultType
{
    public class ErrorResult : Result
    {
        //inherit ettiğimiz classa (base class) alınan bu değerleri gönder
        //success işlemi başarılı olduğu için true değeri sabit olarak aldık ve mesajla birlikte base e gönderdik
        public ErrorResult(string message) : base(false, message)
        {

        }
        //mesaj vermek istemezsekde bu şekilde kullanabiliriz
        public ErrorResult() : base(false)
        {

        }
    }
}
