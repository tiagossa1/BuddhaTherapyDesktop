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
    public class DeleteAppointment
    {
        [TestMethod]
        public void VaiApagarUmRegistoQueNaoExiste()
        {
            // Arrange
            var container = BootStrapDI.Bootstrap();
            AppointmentService appointmentService = new AppointmentService(container.GetInstance<AppointmentDomainService>());
            // Act
            bool appointmenteResult = appointmentService.Delete(Guid.NewGuid());

            // Assert
            Assert.IsFalse(appointmenteResult);
        }

        [TestMethod]
        public void VaiApagar()
        {
            // Arrange
            var container = BootStrapDI.Bootstrap();

            AppointmentService appointmentService = new AppointmentService(container.GetInstance<AppointmentDomainService>());

            Guid appointmentId = Guid.NewGuid();
            AppointmentDto appointment = new AppointmentDto(appointmentId, Guid.NewGuid(), DateTime.Now, 1, "xyz", "xyz");

            // Act
            IList<string> result = appointmentService.Post(appointment);
            bool appointmentResult = appointmentService.Delete(appointmentId);

            // Assert
            Assert.IsTrue(result.Count == 0);
            Assert.IsTrue(appointmentResult);
        }
    }
}
