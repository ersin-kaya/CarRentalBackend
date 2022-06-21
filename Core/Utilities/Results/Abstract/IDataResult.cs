using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results.Abstract
{
    public interface IDataResult<T> : IResult   // Success ve Message, IResult içerisinde zaten var!
    {
        T Data { get; }
    }
}
