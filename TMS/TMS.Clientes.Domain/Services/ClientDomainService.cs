using System;
using System.Collections.Generic;
using System.Linq;
using TMS.Client.Domain.Interfaces;

namespace TMS.Client.Domain.Services
{
    public class ClientDomainService : IClientDomainService
    {
        private readonly IClientRepository _clienteRepository;
        public ClientDomainService(IClientRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }
        public bool Delete(Guid id)
        {
            return _clienteRepository.Delete(id);
        }

        public Model.ClientModel Get(Guid id)
        {
            return _clienteRepository.Get(id);
        }

        public IList<Model.ClientModel> GetAll()
        {
            return _clienteRepository.GetAll();
        }

        public IList<string> Post(Model.ClientModel cliente)
        {
            if (!cliente.IsValid())
                return NotifyValidationErrors(cliente);

            bool result = _clienteRepository.Post(cliente);

            return result ? new List<string>() : new List<string>() { "Error inserting on the database" };
        }

        public IList<string> Put(Model.ClientModel cliente)
        {
            if (!cliente.IsValid())
                return NotifyValidationErrors(cliente);

            bool result = _clienteRepository.Put(cliente);

            return result ? new List<string>() : new List<string>() { "Error updating on the database" };
        }
        private IList<string> NotifyValidationErrors(Model.ClientModel cliente)
        {
            return cliente.ValidationResult.Errors.Select(x => x.ErrorMessage).ToList();
        }
    }
}