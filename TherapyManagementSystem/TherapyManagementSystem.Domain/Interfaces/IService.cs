using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using TherapyManagementSystem.Domain.Entities;

namespace TherapyManagementSystem.Domain.Interfaces
{
    public interface IService<T> where T : BaseEntity
    {
        T Post<V>(T obj) where V : AbstractValidator<T>;

        T Put<V>(T obj) where V : AbstractValidator<T>;

        void Delete(Guid id);

        T Get(Guid id);

        IList<T> Get();
    }
}
