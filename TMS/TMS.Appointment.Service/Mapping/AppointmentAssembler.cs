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

            return new AppointmentModel(appointmentDto.Id, appointmentDto.ClientID,appointmentDto.DateTime,appointmentDto.AppointmentTypeID,appointmentDto.AppointmentTypeName,appointmentDto.AppointmentTypeDescription);
        }

        public static AppointmentDto EntityToDto(AppointmentModel appointment)
        {
            if (appointment is null)
                return new AppointmentDto();

            return new AppointmentDto(appointment.Id, appointment.ClientID, appointment.DateTime, appointment.AppointmentTypeID, appointment.AppointmentTypeName, appointment.AppointmentTypeDescription);
        }

        public static List<AppointmentModel> DtosToEntities(List<AppointmentDto> appointment)
        {
            if (appointment is null)
                return new List<AppointmentModel>();

            return new List<AppointmentModel>(appointment.Select(x => new AppointmentModel(x.Id, x.ClientID, x.DateTime, x.AppointmentTypeID, x.AppointmentTypeName, x.AppointmentTypeDescription)));
        }

        public static List<AppointmentDto> EntitiesToDto(List<AppointmentModel> appointment)
        {
            if (appointment is null)
                return new List<AppointmentDto>();

            return new List<AppointmentDto>(appointment.Select(x => new AppointmentDto(x.Id, x.ClientID, x.DateTime, x.AppointmentTypeID, x.AppointmentTypeName, x.AppointmentTypeDescription)));
        }
    }
}
