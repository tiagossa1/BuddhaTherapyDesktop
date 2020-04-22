using System;
using System.Collections.Generic;
using System.Text;
using TherapyManagementSystem.Domain.Entities;

namespace TherapyManagementSystem.Domain.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        void Insert(T obj);

        void Update(T obj);

        void Remove(Guid id);

        T Select(Guid id);

        IList<T> SelectAll();
    }
}
