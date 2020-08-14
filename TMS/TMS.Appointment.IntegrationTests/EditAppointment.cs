using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Appointment.DI;
using TMS.Appointment.Domain.Services;
using TMS.Appointment.Service.Model;
using TMS.Appointment.Service.Service;

namespace TMS.Appointment.IntegrationTests
{
    [TestClass]
    public class EditAppointment
    {
        [TestMethod]
        public void VaiAtualizarComSucesso()
        {
            // Arrange
            var container = BootStrapDI.Bootstrap();

            AppointmentService appointmentService = new AppointmentService(container.GetInstance<AppointmentDomainService>());

            Guid appointmentId = Guid.NewGuid();
            Guid clientId = Guid.NewGuid();

            AppointmentDto appointment = new AppointmentDto()
            {
                AppointmentDescription = "xyz",
                ClientID = clientId,
                AppointmentTypeID = 2,
                AppointmentTypeName = "xyz",
                DateTime = DateTime.Now,
                Id = appointmentId
            };

            AppointmentDto appointmentNew = new AppointmentDto()
            {
                AppointmentDescription = "xyz",
                ClientID = clientId,
                AppointmentTypeID = 3,
                AppointmentTypeName = "xyz",
                DateTime = DateTime.Now,
                Id = appointmentId
            };

            // Act
            List<string> insertResult = appointmentService.Create(appointment);

            appointment.AppointmentTypeID = 3;

            List<string> updateResult = appointmentService.Edit(appointment);
            AppointmentDto appointmentResult = appointmentService.Get(appointmentId);

            // Assert
            Assert.IsTrue(insertResult.Count == 0);
            Assert.IsTrue(updateResult.Count == 0);
            Assert.IsTrue(appointmentResult.Equals(appointmentNew));
        }

        [TestMethod]
        public void NãoAtualizaComValorNull()
        {
            // Arrange
            var container = BootStrapDI.Bootstrap();
            AppointmentService appointmentService = new AppointmentService(container.GetInstance<AppointmentDomainService>());

            List<string> updateResult = appointmentService.Edit(null);
            // Assert
            Assert.IsTrue(updateResult.Count > 0);
        }
    }
}
