using System;
using System.Collections.Generic;
using TMS.Clientes.Service.Model;

namespace TMS.Clientes.Services.Interfaces
{
    public interface IClientService
    {
        List<string> Create(ClientDto obj);

        List<string> Edit(ClientDto obj);

        bool Delete(Guid id);

        ClientDto Get(Guid id);

        List<ClientDto> GetAll();
    }
}
