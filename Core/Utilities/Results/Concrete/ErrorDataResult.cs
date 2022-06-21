using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results.Concrete
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(T data, string message) : base(data, false, message)
        {

        }

        public ErrorDataResult(T data) : base(data, false)
        {

        }

        public ErrorDataResult(string message) : base(default, false, message) //sadece message geçilerek bu kullanım yapılmak istenebilir
        {
            //bu noktada base'e geçtiğimiz default -> çalıştığı, yani T'nin default'u. Örn. bu int'da olabilir, bir şey döndürmek istemiyorsundur, o yüzden int'ın default'unu geçsin diyebilirsin.
        }

        public ErrorDataResult() : base(default, false)    //hiçbir şey vermek istemiyorum, data -> default, message -> yok.
        {

        }
    }
}
