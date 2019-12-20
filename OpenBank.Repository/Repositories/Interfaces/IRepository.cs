using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace OpenBank.Repository.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void Add(T t);
        void Update(T t);       
        void Remove(T t);
        IQueryable<T> GetAll();
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
    }
}
