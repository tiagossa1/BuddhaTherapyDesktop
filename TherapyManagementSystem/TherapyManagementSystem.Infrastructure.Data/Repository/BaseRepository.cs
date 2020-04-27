using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using TherapyManagementSystem.Domain.Entities;
using TherapyManagementSystem.Domain.Interfaces;
using TherapyManagementSystem.Infrastructure.Data.Context;

namespace TherapyManagementSystem.Infrastructure.Data.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly DatabaseContext context;

        public BaseRepository()
        {
            context = new DatabaseContext();
        }

        public bool CheckIfExists(Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>().Any(predicate);
        }

        public void Insert(T obj)
        {
            context.Set<T>().Add(obj);
            context.SaveChanges();
        }

        public void Remove(Guid id)
        {
            context.Set<T>().Remove(Select(id));
            context.SaveChanges();
        }

        public T Select(Guid id)
        {
            return context.Set<T>().Find(id);
        }

        public IList<T> SelectAll()
        {
            return context.Set<T>().ToList();
        }

        public void Update(T obj)
        {
            context.Entry(obj).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
