using System;
using System.Collections.Generic;
using System.Linq;
using TMS.Client.Domain.Interfaces;
using TMS.Client.Domain.Model;

namespace TMS.Client.Domain.Services
{
    public class ClientDomainService : IClientDomainService
    {
        private readonly IClientRepository clientRepository;
        public ClientDomainService(IClientRepository clientRepository)
        {
            this.clientRepository = clientRepository;
        }
        public bool Delete(Guid id)
        {
            return clientRepository.Delete(id);
        }

        public ClientModel Get(Guid id)
        {
            return clientRepository.Get(id);
        }

        public List<ClientModel> GetAll()
        {
            return clientRepository.GetAll();
        }

        public List<string> Create(ClientModel cliente)
        {
            if (!cliente.IsValid())
                return NotifyValidationErrors(cliente);

            bool result = clientRepository.Create(cliente);

            return result ? new List<string>() : new List<string>() { "Error inserting on the database" };
        }

        public List<string> Edit(ClientModel cliente)
        {
            if (!cliente.IsValid())
                return NotifyValidationErrors(cliente);

            bool result = clientRepository.Edit(cliente);

            return result ? new List<string>() : new List<string>() { "Error updating on the database" };
        }
        private List<string> NotifyValidationErrors(ClientModel cliente)
        {
            return cliente.ValidationResult.Errors.Select(x => x.ErrorMessage).ToList();
        }

        public long Count()
        {
            return clientRepository.Count();
        }
    }
}