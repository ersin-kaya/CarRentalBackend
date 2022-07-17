using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        IResult Add(User user);
        IDataResult<User> GetByMail(string email);
        IDataResult<List<UserOperationClaimDetailDto>> GetClaims(User user);
    }
}
