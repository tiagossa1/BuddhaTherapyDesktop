using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using TherapyManagementSystem.Domain.Entities;
using TherapyManagementSystem.Domain.Interfaces;
using TherapyManagementSystem.Infrastructure.Data.Repository;

namespace TherapyManagementSystem.Service.Services
{
    public class BaseService<T> : IService<T> where T : BaseEntity
    {
        private readonly BaseRepository<T> repository = new BaseRepository<T>();
        public T Post<V>(T obj) where V : AbstractValidator<T>
        {
            Validate(obj, Activator.CreateInstance<V>());

            repository.Insert(obj);
            return obj;
        }

        public T Put<V>(T obj) where V : AbstractValidator<T>
        {
            Validate(obj, Activator.CreateInstance<V>());

            repository.Update(obj);
            return obj;
        }

        public void Delete(Guid id)
        {
            if(id == default || id == Guid.Empty)
                throw new ArgumentException("Invalid id.");

            repository.Remove(id);
        }

        public T Get(Guid id)
        {
            if (id == default || id == Guid.Empty)
                throw new ArgumentException("Invalid ID.");

            return repository.Select(id);
        }

        public IList<T> Get()
        {
            return repository.SelectAll();
        }

        private void Validate(T obj, AbstractValidator<T> validator)
        {
            if (obj == null)
                throw new ArgumentNullException("Records not found.");

            validator.ValidateAndThrow(obj);
        }
    }
}
