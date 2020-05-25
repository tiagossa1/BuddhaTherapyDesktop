using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Clientes.Service.Model;
using TMS.UI.Mapper.Interfaces;
using TMS.UI.UIModels;

namespace TMS.UI.Mapper
{
    public class ClientMapper : IMapper<ClientDto, ClientUIModel>
    {
        public ClientUIModel ToUiModel(ClientDto dto)
        {
            return new ClientUIModel(dto.FirstName, dto.LastName, dto.Address, dto.PhoneNumber, dto.Email, dto.NIF, dto.JobTitle);
        }

        public List<ClientUIModel> ToUiModelList(List<ClientDto> dtos)
        {
            return dtos.Select(ToUiModel).ToList();
        }
    }
}
