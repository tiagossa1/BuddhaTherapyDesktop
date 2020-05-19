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

            AppointmentDto appointment = new AppointmentDto(appointmentId, clientId, DateTime.Now, 1, "xyz");
            AppointmentDto appointmentNew = new AppointmentDto(appointmentId, clientId, DateTime.Now, 2, "xyz");

            // Act
            IList<string> insertResult = appointmentService.Post(appointment);

            appointment.AppointmentTypeID = 2;

            IList<string> updateResult = appointmentService.Put(appointment);
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

            IList<string> updateResult = appointmentService.Put(null);
            // Assert
            Assert.IsTrue(updateResult.Count > 0);
        }
    }
}
