using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Appointment.Domain.Services;
using TMS.Appointment.Repository;
using TMS.Appointment.Service.Service;
using TMS.Client.Domain.Services;
using TMS.Client.Repository.Repository;
using TMS.Invoice.Service.Model;
using TMS.UI.Mapper.Interfaces;
using TMS.UI.UIModels;

namespace TMS.UI.Mapper
{
    public class InvoiceMapper : IMapper<InvoiceDto, InvoiceUIModel>
    {
        private readonly ClientService clientService;
        private readonly AppointmentService appointmentService;
        public InvoiceMapper()
        {
            clientService = new ClientService(new ClientDomainService(new ClientRepository()));
            appointmentService = new AppointmentService(new AppointmentDomainService(new AppointmentRepository()));
        }
        public InvoiceUIModel ToUiModel(InvoiceDto dto)
        {
            var client = clientService.Get(dto.ClientID);
            var appointment = appointmentService.Get(dto.AppointmentID);

            return new InvoiceUIModel($"{client.FirstName} {client.LastName} | {appointment.DateTime}", dto.Price, dto.InvoiceDate);
        }

        public List<InvoiceUIModel> ToUiModelList(List<InvoiceDto> dtos)
        {
            return dtos.Select(ToUiModel).ToList();
        }
    }
}
