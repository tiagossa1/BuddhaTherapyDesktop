using System;
using System.Collections.Generic;
using TMS.Client.Domain.Model;

namespace TMS.Client.Domain.Interfaces
{
    public interface IClientDomainService
    {
        List<string> Create(ClientModel obj);

        List<string> Edit(ClientModel obj);

        bool Delete(Guid id);

        ClientModel Get(Guid id);

        List<ClientModel> GetAll();
        long Count();
    }
}
