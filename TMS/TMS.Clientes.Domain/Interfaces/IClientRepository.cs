using System;
using System.Collections.Generic;
using TMS.Client.Domain.Model;

namespace TMS.Client.Domain.Interfaces
{
    public interface IClientRepository
    {
        bool Post(Model.ClientModel obj);

        bool Put(Model.ClientModel obj);

        bool Delete(Guid id);

        Model.ClientModel Get(Guid id);

        IList<Model.ClientModel> GetAll();
    }
}