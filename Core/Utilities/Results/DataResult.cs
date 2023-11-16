using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        //data result ctor undan base'e (result'a) success ve message değişkenleri gönderilir
        //result içerisinde kodlar mevcut tekrar yazılması gereksiz(nested work)
        public DataResult(T data,bool success,string message): base(success,message)
        {
            //normalde tekrar etmememiz gerekir fakat base'e veri gönderdik this çalışmıyor 
            Data = data;
        }
        //mesaj göndermek istemezsek bu şekilde kullanılır
        //
        public DataResult(T data, bool success) : base(success)
        {
            Data=data;
        }
        public T Data { get; }
    }
}
