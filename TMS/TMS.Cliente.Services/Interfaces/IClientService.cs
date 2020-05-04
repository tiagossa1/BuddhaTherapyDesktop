using System;
using System.Collections.Generic;
using TMS.Clientes.Service.Model;

namespace TMS.Clientes.Services.Interfaces
{
    public interface IClientService
    {
        IList<string> Post(ClientDto obj);

        IList<string> Put(ClientDto obj);

        bool Delete(Guid id);

        ClientDto Get(Guid id);

        IList<ClientDto> GetAll();
    }
}
