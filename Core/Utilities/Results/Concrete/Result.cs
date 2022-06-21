using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results.Concrete
{
    public class Result : IResult
    {
        public Result(bool success, string message) : this(success)
        {
            Message = message;  //UNUTMA! Message sadece getter'dı hani set edilemezdi? : getter readonly'dir, readonly'ler constructor içerisinde set edilebilirler... Constructor dışında zaten set etmeyeceğimizden setter koymadık çünkü adam tamamen constructor yapısıyla kullansın.
        }

        public Result(bool success)
        {
            Success = success;  //tek satır kod deme! Kendini tekrar etme!
        }

        public bool Success { get; }

        public string Message { get; }
    }
}
