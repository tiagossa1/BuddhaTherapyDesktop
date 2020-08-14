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

            AppointmentModel appointmentOne = new AppointmentModel()
            {
                AppointmentDescription = "xyz",
                Id = Guid.NewGuid(),
                AppointmentTypeID = 1,
                AppointmentTypeName = "xyz",
                ClientID = Guid.NewGuid(),
                DateTime = default
            };

            AppointmentModel appointmentTwo = new AppointmentModel()
            {
                AppointmentDescription = "xyz",
                Id = Guid.NewGuid(),
                AppointmentTypeID = 0,
                AppointmentTypeName = "xyz",
                ClientID = Guid.NewGuid(),
                DateTime = DateTime.Now
            };

            // Act
            IList<string> resultOne = appointmentDomainService.Create(appointmentOne);
            IList<string> resultTwo = appointmentDomainService.Create(appointmentTwo);

            // Assert
            Assert.IsTrue(resultOne.Count > 0);
            Assert.IsTrue(resultTwo.Count > 0);
        }

        [TestMethod]
        public void Post_VaiFalharNoInsertNaDb()
        {
            // Arrange
            var appointmentRepository = new Mock<IAppointmentRepository>();
            appointmentRepository.Setup(x => x.Create(It.IsAny<AppointmentModel>())).Returns(false);
            AppointmentDomainService AppointmentDomainService = new AppointmentDomainService(appointmentRepository.Object);

            AppointmentModel appointment = new AppointmentModel()
            {
                AppointmentDescription = "xyz",
                Id = Guid.NewGuid(),
                AppointmentTypeID = 1,
                AppointmentTypeName = "xyz",
                ClientID = Guid.NewGuid(),
                DateTime = default
            };

            // Act
            IList<string> result = AppointmentDomainService.Create(appointment);

            // Assert
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void Post_VaiDarSucesso()
        {
            // Arrange
            var appointmentRepository = new Mock<IAppointmentRepository>();
            appointmentRepository.Setup(x => x.Create(It.IsAny<AppointmentModel>())).Returns(true);
            var appointmentDomainService = new AppointmentDomainService(appointmentRepository.Object);

            AppointmentModel appointment = new AppointmentModel()
            {
                AppointmentDescription = "xyz",
                Id = Guid.NewGuid(),
                AppointmentTypeID = 1,
                AppointmentTypeName = "xyz",
                ClientID = Guid.NewGuid(),
                DateTime = DateTime.Now
            };

            // Act
            IList<string> result = appointmentDomainService.Create(appointment);

            // Assert
            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void Put_VaiFalharDevidoAErrosDeValidacaoDoDominio()
        {
            // Arrange
            var appointmentRepository = new Mock<IAppointmentRepository>();
            AppointmentDomainService appointmentDomainService = new AppointmentDomainService(appointmentRepository.Object);
            AppointmentModel appointment = new AppointmentModel()
            {
                AppointmentDescription = null,
                Id = Guid.NewGuid(),
                AppointmentTypeID = 1,
                AppointmentTypeName = null,
                ClientID = Guid.NewGuid(),
                DateTime = DateTime.Now
            };

            // Act
            IList<string> result = appointmentDomainService.Update(appointment);

            // Assert
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void Put_VaiFalharNoInsertNaDb()
        {
            // Arrange
            var appointmentRepository = new Mock<IAppointmentRepository>();
            appointmentRepository.Setup(x => x.Update(It.IsAny<AppointmentModel>())).Returns(false);
            AppointmentDomainService appointmentDomainService = new AppointmentDomainService(appointmentRepository.Object);

            AppointmentModel appointment = new AppointmentModel()
            {
                AppointmentDescription = "xyz",
                Id = Guid.NewGuid(),
                AppointmentTypeID = 1,
                AppointmentTypeName = "xyz",
                ClientID = Guid.NewGuid(),
                DateTime = DateTime.Now
            };

            // Act
            IList<string> result = appointmentDomainService.Update(appointment);

            // Assert
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void Put_VaiDarSucesso()
        {
            // Arrange
            var appointmentRepository = new Mock<IAppointmentRepository>();
            appointmentRepository.Setup(x => x.Update(It.IsAny<AppointmentModel>())).Returns(true);

            var appointmentDomainService = new AppointmentDomainService(appointmentRepository.Object);
            AppointmentModel appointment = new AppointmentModel()
            {
                AppointmentDescription = "xyz",
                Id = Guid.NewGuid(),
                AppointmentTypeID = 1,
                AppointmentTypeName = "xyz",
                ClientID = Guid.NewGuid(),
                DateTime = DateTime.Now
            };

            // Act
            IList<string> result = appointmentDomainService.Update(appointment);

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
            appointmentRepository.Setup(x => x.Get(It.IsAny<Guid>())).Returns(new AppointmentModel()
            {
                DateTime = DateTime.Now,
                ClientID = Guid.NewGuid(),
                AppointmentDescription = "xyz",
                AppointmentTypeName = "xyz",
                AppointmentTypeID = 1,
                Id = appointmentGuid
            });

            AppointmentDomainService appointmentDomainService = new AppointmentDomainService(appointmentRepository.Object);

            // Act
            AppointmentModel result = appointmentDomainService.Get(Guid.NewGuid());

            // Assert
            Assert.AreEqual(result.GetType(), typeof(AppointmentModel));
        }

        [TestMethod]
        public void GetAll_VaiRetornarOsClientes()
        {
            // Arrange
            var appointments = new List<AppointmentModel>() { new AppointmentModel() {
                Id = Guid.NewGuid(),
                AppointmentDescription = "xyz",
                AppointmentTypeID = 1,
                AppointmentTypeName = "xyz",
                ClientID = Guid.NewGuid(),
                DateTime = DateTime.Now
            } };

            var appointmentRepository = new Mock<IAppointmentRepository>();
            appointmentRepository.Setup(x => x.GetAll()).Returns(appointments);
            AppointmentDomainService appointmentDomainService = new AppointmentDomainService(appointmentRepository.Object);

            // Act
            var result = appointmentDomainService.GetAll();

            // Assert
            Assert.AreEqual(appointments, result);
        }
    }
}
