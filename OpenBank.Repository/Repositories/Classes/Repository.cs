using Microsoft.EntityFrameworkCore;
using OpenBank.Repository.Context;
using OpenBank.Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace OpenBank.Repository.Repositories.Classes
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        private OpenBankContext _db { get; set; }

        public Repository(OpenBankContext db)
        {
            _db = db;
        }

        public void Add(T t)
        {
            _db.Set<T>().Add(t);
            _db.SaveChanges();
        }

        public void Remove(T t)
        {
            _db.Set<T>().Remove(t);
            _db.SaveChanges();
        }

        public void Update(T t)
        {
            _db.Set<T>().Update(t);
            _db.SaveChanges();
        }

        public IQueryable<T> GetAll()
        {
            return _db.Set<T>();
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return _db.Set<T>().AsNoTracking().Where(predicate);
        }
    }
}
