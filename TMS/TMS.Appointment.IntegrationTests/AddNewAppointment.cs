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
    public class AddNewAppointment
    {
        [TestMethod]
        public void VaiFalharDevidoAErrosdeValidacaoDeDominio()
        {
            // Arrange
            var container = BootStrapDI.Bootstrap();
            AppointmentService appointmentService = new AppointmentService(container.GetInstance<AppointmentDomainService>());
            AppointmentDto appointment = new AppointmentDto(Guid.NewGuid(), Guid.NewGuid(), default, 1, "xyz");

            // Act
            IList<string> result = appointmentService.Post(appointment);

            // Assert
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void VaiAdicionarComSucesso()
        {
            // Arrange
            var container = BootStrapDI.Bootstrap();
            AppointmentService AppointmentService = new AppointmentService(container.GetInstance<AppointmentDomainService>());
            AppointmentDto appointment = new AppointmentDto(Guid.NewGuid(), Guid.NewGuid(), DateTime.Now, 1, "xyz");

            // Act
            IList<string> result = AppointmentService.Post(appointment);

            // Assert
            Assert.IsTrue(result.Count == 0);
        }
    }
}
