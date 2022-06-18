using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IEntityRepository<T> where T:class,IEntity,new()   //T: class->referans tip olmalı, IEntity->IEntity olabilir veya onu implemente eden bir class olabilir, new()->new'lenebilir olmalı yani artık doğrudan IEntity veya onu implemente eden bir "abstract class" olamaz.
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        List<T> GetAll(Expression<Func<T, bool>> filter=null);
        T Get(Expression<Func<T, bool>> filter);
    }
}
