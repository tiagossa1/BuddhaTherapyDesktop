using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Appointment.Domain.Models;
using TMS.Appointment.Service.Model;

namespace TMS.Appointment.Service.Mapping
{
    public static class AppointmentAssembler
    {
        public static AppointmentModel DtoToEntity(AppointmentDto appointmentDto)
        {
            if (appointmentDto is null)
                return new AppointmentModel();

            return new AppointmentModel()
            {
                AppointmentDescription = appointmentDto.AppointmentDescription,
                Id = appointmentDto.Id,
                AppointmentTypeID = appointmentDto.AppointmentTypeID,
                AppointmentTypeName = appointmentDto.AppointmentTypeName,
                ClientID = appointmentDto.ClientID,
                DateTime = appointmentDto.DateTime
            };
        }

        public static AppointmentDto EntityToDto(AppointmentModel appointment)
        {
            if (appointment is null)
                return new AppointmentDto();

            return new AppointmentDto()
            {
                AppointmentDescription = appointment.AppointmentDescription,
                Id = appointment.Id,
                AppointmentTypeID = appointment.AppointmentTypeID,
                AppointmentTypeName = appointment.AppointmentTypeName,
                ClientID = appointment.ClientID,
                DateTime = appointment.DateTime
            };
        }

        public static List<AppointmentModel> DtosToEntities(List<AppointmentDto> appointment)
        {
            if (appointment is null)
                return new List<AppointmentModel>();

            return new List<AppointmentModel>(appointment.Select(DtoToEntity));
        }

        public static List<AppointmentDto> EntitiesToDto(List<AppointmentModel> appointment)
        {
            if (appointment is null)
                return new List<AppointmentDto>();

            return new List<AppointmentDto>(appointment.Select(EntityToDto));
        }
    }
}
