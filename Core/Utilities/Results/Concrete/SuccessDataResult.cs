using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results.Concrete
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        public SuccessDataResult(T data, string message) : base(data, true, message)
        {

        }

        public SuccessDataResult(T data) : base(data, true)
        {

        }

        public SuccessDataResult(string message) : base(default, true, message) //sadece message geçilerek bu kullanım yapılmak istenebilir
        {
            //bu noktada base'e geçtiğimiz default -> çalıştığı, yani T'nin default'u. Örn. bu int'da olabilir, bir şey döndürmek istemiyorsundur, o yüzden int'ın default'unu geçsin diyebilirsin.
        }

        public SuccessDataResult() : base(default, true)    //hiçbir şey vermek istemiyorum, data -> default, message -> yok.
        {
            
        }
    }
}
