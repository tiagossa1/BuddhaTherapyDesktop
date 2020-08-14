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
            AppointmentDto appointment = new AppointmentDto()
            {
                AppointmentDescription = "xyz",
                ClientID = Guid.NewGuid(),
                AppointmentTypeID = 0,
                AppointmentTypeName = "xyz",
                DateTime = default,
                Id = Guid.NewGuid()
            };

            // Act
            List<string> result = appointmentService.Create(appointment);

            // Assert
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void VaiAdicionarComSucesso()
        {
            // Arrange
            var container = BootStrapDI.Bootstrap();
            AppointmentService AppointmentService = new AppointmentService(container.GetInstance<AppointmentDomainService>());
            AppointmentDto appointment = new AppointmentDto()
            {
                AppointmentDescription = "xyz",
                ClientID = Guid.NewGuid(),
                AppointmentTypeID = 2,
                AppointmentTypeName = "xyz",
                DateTime = DateTime.Now,
                Id = Guid.NewGuid()
            };

            // Act
            List<string> result = AppointmentService.Create(appointment);

            // Assert
            Assert.IsTrue(result.Count == 0);
        }
    }
}
