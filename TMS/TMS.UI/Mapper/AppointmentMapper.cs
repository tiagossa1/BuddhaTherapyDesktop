using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Appointment.Service.Model;
using TMS.Client.Domain.Services;
using TMS.Clientes.Repository.Repository;
using TMS.UI.Mapper.Interfaces;
using TMS.UI.UIModels;

namespace TMS.UI.Mapper
{
    public class AppointmentMapper : IMapper<AppointmentDto, AppointmentUIModel>
    {
        public AppointmentUIModel ToUiModel(AppointmentDto dto)
        {
            var clientService = new ClientService(new ClientDomainService(new ClientRepository()));

            var selectedClient = clientService.Get(dto.ClientID);
            var clientName = $"{selectedClient.FirstName} {selectedClient.LastName}";

            return new AppointmentUIModel(clientName, dto.DateTime, dto.AppointmentTypeName, dto.AppointmentDescription);
        }

        public List<AppointmentUIModel> ToUiModelList(List<AppointmentDto> dtos)
        {
            return dtos.Select(ToUiModel).ToList();
        }
    }
}
