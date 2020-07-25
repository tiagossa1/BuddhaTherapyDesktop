using System;
using System.Collections.Generic;
using System.Linq;
using TMS.Client.Domain.Interfaces;
using TMS.Client.Domain.Model;
using TMS.Clientes.Service.Mapping;
using TMS.Clientes.Service.Model;
using TMS.Clientes.Services.Interfaces;

namespace TMS.Client.Domain.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientDomainService _clientDomainService;
        public ClientService(IClientDomainService clientRepository)
        {
            _clientDomainService = clientRepository;
        }
        public bool Delete(Guid id)
        {
            return _clientDomainService.Delete(id);
        }

        public ClientDto Get(Guid id)
        {
            return ClientAssembler.EntityToDto(_clientDomainService.Get(id));
        }

        public List<ClientDto> GetAll()
        {
            return ClientAssembler.EntitiesToDto(_clientDomainService.GetAll().ToList());
        }

        public List<string> Post(ClientDto cliente)
        {
            return  _clientDomainService.Post(ClientAssembler.DtoToEntity(cliente));
        }

        public List<string> Put(ClientDto cliente)
        {
            return _clientDomainService.Put(ClientAssembler.DtoToEntity(cliente));
        }
    }
}