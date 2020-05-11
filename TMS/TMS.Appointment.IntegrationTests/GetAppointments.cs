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
    public class GetAppointments
    {
        [TestMethod]
        public void VaiRetornarUmAppointmenteVazio()
        {
            // Arrange
            var container = BootStrapDI.Bootstrap();
            AppointmentService appointmentService = new AppointmentService(container.GetInstance<AppointmentDomainService>());

            // Act
            AppointmentDto appointment = appointmentService.Get(Guid.NewGuid());

            // Assert
            Assert.IsTrue(appointment.Equals(new AppointmentDto()));
        }

        [TestMethod]
        public void VaiRetornarUmAppointment()
        {
            // Arrange
            var container = BootStrapDI.Bootstrap();
            AppointmentService AppointmentService = new AppointmentService(container.GetInstance<AppointmentDomainService>());
            Guid appointmentId = Guid.NewGuid();
            // Act
            AppointmentDto appointment = new AppointmentDto(appointmentId, Guid.NewGuid(), DateTime.Now, 1, "xyz", "xyz");

            IList<string> postResult = AppointmentService.Post(appointment);
            AppointmentDto appointmentResult = AppointmentService.Get(appointmentId);

            // Assert
            Assert.IsTrue(postResult.Count == 0);
            Assert.IsTrue(appointmentResult.Equals(appointment));
        }

        [TestMethod]
        public void VaiRetornarTodosOsAppointments()
        {
            // Arrange
            var container = BootStrapDI.Bootstrap();
            AppointmentService appointmentService = new AppointmentService(container.GetInstance<AppointmentDomainService>());
            Guid appointmentId = Guid.NewGuid();

            // Act
            AppointmentDto appointment = new AppointmentDto(appointmentId, Guid.NewGuid(), DateTime.Now, 1, "xyz", "xyz");
            IList<string> postResult = appointmentService.Post(appointment);
            List<AppointmentDto> appointmentResult = appointmentService.GetAll().ToList();

            // Assert
            Assert.IsTrue(postResult.Count == 0);
            Assert.IsTrue(appointmentResult.Contains(appointment));
        }
    }
}
