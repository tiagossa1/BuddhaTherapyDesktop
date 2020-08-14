using System.Collections.Generic;
using System.Linq;
using TMS.Client.Domain.Model;
using TMS.Clientes.Service.Model;

namespace TMS.Clientes.Service.Mapping
{
    public static class ClientAssembler
    {
        public static Client.Domain.Model.ClientModel DtoToEntity(ClientDto clientDto)
        {
            if (clientDto is null)
                return new Client.Domain.Model.ClientModel();
            return new Client.Domain.Model.ClientModel()
            {
                Address = clientDto.Address,
                Email = clientDto.Email,
                FirstName = clientDto.FirstName,
                Id = clientDto.Id,
                JobTitle = clientDto.JobTitle,
                LastName = clientDto.LastName,
                NIF = clientDto.NIF,
                PhoneNumber = clientDto.PhoneNumber
            };
        }

        public static ClientDto EntityToDto(Client.Domain.Model.ClientModel client)
        {
            if (client is null)
                return new ClientDto();

            return new ClientDto()
            {
                PhoneNumber = client.PhoneNumber,
                NIF = client.NIF,
                LastName = client.LastName,
                JobTitle = client.JobTitle,
                Id = client.Id,
                FirstName = client.FirstName,
                Email = client.Email,
                Address = client.Address
            };
        }

        public static List<Client.Domain.Model.ClientModel> DtosToEntities(List<ClientDto> cliente)
        {
            if (cliente is null)
                return new List<Client.Domain.Model.ClientModel>();

            return new List<ClientModel>(cliente.Select(DtoToEntity));
        }

        public static List<ClientDto> EntitiesToDto(List<Client.Domain.Model.ClientModel> cliente)
        {
            if (cliente is null)
                return new List<ClientDto>();

            return new List<ClientDto>(cliente.Select(EntityToDto));
        }
    }
}
