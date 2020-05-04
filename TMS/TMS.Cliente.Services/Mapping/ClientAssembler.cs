using System.Collections.Generic;
using System.Linq;
using TMS.Client.Domain.Model;
using TMS.Clientes.Service.Model;

namespace TMS.Clientes.Service.Mapping
{
    public static class ClientAssembler
    {
        public static Client.Domain.Model.ClientModel DtoToEntity(ClientDto ClientDto)
        {
            if (ClientDto is null)
                return new Client.Domain.Model.ClientModel();
            return new Client.Domain.Model.ClientModel(ClientDto.Id,
                ClientDto.FirstName,
                ClientDto.LastName,
                ClientDto.Address,
                ClientDto.PhoneNumber,
                ClientDto.Email,
                ClientDto.NIF,
                ClientDto.JobTitle);
        }

        public static ClientDto EntityToDto(Client.Domain.Model.ClientModel cliente)
        {
            if (cliente is null)
                return new ClientDto();
            return new ClientDto(cliente.Id,
                cliente.FirstName,
                cliente.LastName,
                cliente.Address,
                cliente.PhoneNumber,
                cliente.Email,
                cliente.NIF,
                cliente.JobTitle);
        }

        public static List<Client.Domain.Model.ClientModel> DtosToEntities(List<ClientDto> cliente)
        {
            if (cliente is null)
                return new List<Client.Domain.Model.ClientModel>();
            return new List<ClientModel>(cliente.Select(x=> new ClientModel(x.Id,
                x.FirstName,
                x.LastName,
                x.Address,
                x.PhoneNumber,
                x.Email,
                x.NIF,
                x.JobTitle)));
        }

        public static List<ClientDto> EntitiesToDto(List<Client.Domain.Model.ClientModel> cliente)
        {
            if (cliente is null)
                return new List<ClientDto>();

            return new List<ClientDto>(cliente.Select(x => new ClientDto(x.Id,
                  x.FirstName,
                  x.LastName,
                  x.Address,
                  x.PhoneNumber,
                  x.Email,
                  x.NIF,
                  x.JobTitle)));
        }
    }
}
