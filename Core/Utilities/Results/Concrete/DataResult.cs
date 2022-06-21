using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results.Concrete
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        public DataResult(T data, bool success, string message) : base(success, message)
        {
            // : base(success, message) --> şu yapıyı çalıştırdığımız zaman biz -aşağıdaki contructor içerisinde bulunan- Data'yı set etme işlemini gerçekleştiremiyoruz, o yüzden burada ekstradan bir de Data'yı set ediyoruz -aşağıda da yapıyor olmamıza rağmen-.
            Data = data;
        }

        public DataResult(T data, bool success) : base(success) //message göndermek istemiyorsa
        {
            Data = data;
        }

        public T Data { get; }
    }
}
