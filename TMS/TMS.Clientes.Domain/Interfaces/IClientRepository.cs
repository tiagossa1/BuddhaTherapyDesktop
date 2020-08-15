using System;
using System.Collections.Generic;
using TMS.Client.Domain.Model;

namespace TMS.Client.Domain.Interfaces
{
    public interface IClientRepository
    {
        bool Create(Model.ClientModel obj);

        bool Edit(Model.ClientModel obj);

        bool Delete(Guid id);

        ClientModel Get(Guid id);

        List<ClientModel> GetAll();
        long Count();
    }
}