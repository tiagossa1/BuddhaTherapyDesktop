using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using TMS.Appointment.Domain.Interfaces;
using TMS.Appointment.Domain.Models;
using TMS.Appointment.Domain.Services;

namespace TMS.Appointment.Domain.Tests
{
    [TestClass]
    public class AppointmentDomainService_Tests
    {
        [TestMethod]
        public void Post_VaiFalharDevidoAErrosdeValidacaoDoDominio()
        {
            // Arrange
            var appointmentRepository = new Mock<IAppointmentRepository>();
            AppointmentDomainService appointmentDomainService = new AppointmentDomainService(appointmentRepository.Object);

            AppointmentModel appointmentOne = new AppointmentModel(Guid.NewGuid(), Guid.NewGuid(), default, 1, "XYZ", "XYZ");
            AppointmentModel appointmentTwo = new AppointmentModel(Guid.NewGuid(), Guid.NewGuid(), DateTime.Now, 0, "XYZ", "XYZ");

            // Act
            IList<string> resultOne = appointmentDomainService.Post(appointmentOne);
            IList<string> resultTwo = appointmentDomainService.Post(appointmentTwo);

            // Assert
            Assert.IsTrue(resultOne.Count > 0);
            Assert.IsTrue(resultTwo.Count > 0);
        }

        [TestMethod]
        public void Post_VaiFalharNoInsertNaDb()
        {
            // Arrange
            var appointmentRepository = new Mock<IAppointmentRepository>();
            appointmentRepository.Setup(x => x.Post(It.IsAny<AppointmentModel>())).Returns(false);
            AppointmentDomainService AppointmentDomainService = new AppointmentDomainService(appointmentRepository.Object);
            AppointmentModel appointment = new AppointmentModel(Guid.NewGuid(), Guid.NewGuid(), DateTime.Now, 1, "XYZ", "XYZ");

            // Act
            IList<string> result = AppointmentDomainService.Post(appointment);

            // Assert
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void Post_VaiDarSucesso()
        {
            // Arrange
            var appointmentRepository = new Mock<IAppointmentRepository>();
            appointmentRepository.Setup(x => x.Post(It.IsAny<AppointmentModel>())).Returns(true);
            var appointmentDomainService = new AppointmentDomainService(appointmentRepository.Object);
            AppointmentModel appointment = new AppointmentModel(Guid.NewGuid(), Guid.NewGuid(), DateTime.Now, 5, "XYZ", "XYZ");

            // Act
            IList<string> result = appointmentDomainService.Post(appointment);

            // Assert
            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void Put_VaiFalharDevidoAErrosDeValidacaoDoDominio()
        {
            // Arrange
            var appointmentRepository = new Mock<IAppointmentRepository>();
            AppointmentDomainService appointmentDomainService = new AppointmentDomainService(appointmentRepository.Object);
            AppointmentModel appointment = new AppointmentModel(Guid.NewGuid(), Guid.NewGuid(), DateTime.Now, 2, null, null);

            // Act
            IList<string> result = appointmentDomainService.Put(appointment);

            // Assert
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void Put_VaiFalharNoInsertNaDb()
        {
            // Arrange
            var appointmentRepository = new Mock<IAppointmentRepository>();
            appointmentRepository.Setup(x => x.Put(It.IsAny<AppointmentModel>())).Returns(false);
            AppointmentDomainService appointmentDomainService = new AppointmentDomainService(appointmentRepository.Object);
            AppointmentModel cliente = new AppointmentModel(Guid.NewGuid(), Guid.NewGuid(), DateTime.Now, 1, "xyz", "xyz");

            // Act
            IList<string> result = appointmentDomainService.Put(cliente);

            // Assert
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void Put_VaiDarSucesso()
        {
            // Arrange
            var appointmentRepository = new Mock<IAppointmentRepository>();
            appointmentRepository.Setup(x => x.Put(It.IsAny<AppointmentModel>())).Returns(true);

            var appointmentDomainService = new AppointmentDomainService(appointmentRepository.Object);
            AppointmentModel appointment = new AppointmentModel(Guid.NewGuid(), Guid.NewGuid(), DateTime.Now, 1, "xyz", "xyz");

            // Act
            IList<string> result = appointmentDomainService.Put(appointment);

            // Assert
            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void Delete_VaiDarSucessoEApagar()
        {
            // Arrange
            var appointmentRepository = new Mock<IAppointmentRepository>();
            appointmentRepository.Setup(x => x.Delete(It.IsAny<Guid>())).Returns(true);
            AppointmentDomainService AppointmentDomainService = new AppointmentDomainService(appointmentRepository.Object);

            // Act
            bool result = AppointmentDomainService.Delete(Guid.NewGuid());

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Get_VaiRetornarOCliente()
        {
            // Arrange
            Guid appointmentGuid = Guid.NewGuid();
            var appointmentRepository = new Mock<IAppointmentRepository>();
            appointmentRepository.Setup(x => x.Get(It.IsAny<Guid>())).Returns(new AppointmentModel(appointmentGuid, Guid.NewGuid(), DateTime.Now, 1, "xyz", "xyz"));
            AppointmentDomainService AppointmentDomainService = new AppointmentDomainService(appointmentRepository.Object);

            // Act
            AppointmentModel result = AppointmentDomainService.Get(Guid.NewGuid());

            // Assert
            Assert.AreEqual(result.GetType(), typeof(AppointmentModel));
        }

        [TestMethod]
        public void GetAll_VaiRetornarOsClientes()
        {
            // Arrange
            IList<AppointmentModel> appointments = new List<AppointmentModel>() { new AppointmentModel(Guid.NewGuid(), Guid.NewGuid(), DateTime.Now, 1, "xyz", "xyz") };
            var appointmentRepository = new Mock<IAppointmentRepository>();
            appointmentRepository.Setup(x => x.GetAll()).Returns(appointments);
            AppointmentDomainService appointmentDomainService = new AppointmentDomainService(appointmentRepository.Object);

            // Act
            IList<AppointmentModel> result = appointmentDomainService.GetAll();

            // Assert
            Assert.AreEqual(appointments, result);
        }
    }
}
