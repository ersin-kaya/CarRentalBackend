﻿using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using Core.Entities.DTOs;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, ReCapProjectContext>, IUserDal
    {
        public List<UserOperationClaimDetailDto> GetClaims(User user)
        {
            using (var context = new ReCapProjectContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                             on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new UserOperationClaimDetailDto { OperationClaimId = operationClaim.Id, OperationClaimName = operationClaim.Name };
                return result.ToList();
            }
        }
    }
}
