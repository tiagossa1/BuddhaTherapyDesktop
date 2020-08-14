using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TMS.Appointment.Domain.Models;
using TMS.Appointment.Service.Mapping;
using TMS.Appointment.Service.Model;

namespace TMS.Appointment.Service.Tests
{
    [TestClass]
    public class AppointmentAssemblerTests
    {
        [TestMethod]
        public void ConverterDeDtoToEntity()
        {
            // Arrange
            Guid newGuid = Guid.NewGuid();

            AppointmentDto appointmentDto = new AppointmentDto()
            {
                AppointmentDescription = "xyz",
                ClientID = Guid.NewGuid(),
                AppointmentTypeID = 2,
                AppointmentTypeName = "xyz",
                DateTime = DateTime.Now,
                Id = newGuid
            };

            AppointmentModel appointment = new AppointmentModel()
            {
                AppointmentDescription = "xyz",
                ClientID = Guid.NewGuid(),
                AppointmentTypeID = 2,
                AppointmentTypeName = "xyz",
                DateTime = DateTime.Now,
                Id = newGuid
            };

            // Act
            AppointmentModel result = AppointmentAssembler.DtoToEntity(appointmentDto);

            // Assert
            Assert.IsTrue(result.Equals(appointment));
        }

        [TestMethod]
        public void ConverterDeEntityParaDto_DeveRetornarUmObjetoVazioDevidoAoValorNull()
        {
            // Arrange, Act 
            AppointmentDto result = AppointmentAssembler.EntityToDto(null);
            // Assert
            Assert.IsTrue(result.Equals(new AppointmentDto()));
        }

        [TestMethod]
        public void ConverterDeEntityParaDto()
        {
            // Arrange
            Guid newGuid = Guid.NewGuid();
            AppointmentDto appointmentDto = new AppointmentDto()
            {
                AppointmentDescription = "xyz",
                ClientID = Guid.NewGuid(),
                AppointmentTypeID = 2,
                AppointmentTypeName = "xyz",
                DateTime = DateTime.Now,
                Id = newGuid
            };

            AppointmentModel appointment = new AppointmentModel()
            {
                AppointmentDescription = "xyz",
                ClientID = Guid.NewGuid(),
                AppointmentTypeID = 2,
                AppointmentTypeName = "xyz",
                DateTime = DateTime.Now,
                Id = newGuid
            };

            // Act
            AppointmentDto result = AppointmentAssembler.EntityToDto(appointment);

            // Assert
            Assert.IsTrue(result.Equals(appointmentDto));
        }

        [TestMethod]
        public void AppointmentAssembler_ConverterDeEntitiesParaDtos()
        {
            // Arrange
            Guid newGuid = Guid.NewGuid();

            List<AppointmentDto> appointmentDtos = new List<AppointmentDto>() { new AppointmentDto()
            {
                AppointmentDescription = "xyz",
                ClientID = Guid.NewGuid(),
                AppointmentTypeID = 2,
                AppointmentTypeName = "xyz",
                DateTime = DateTime.Now,
                Id = newGuid
            } };

            List<AppointmentModel> appointments = new List<AppointmentModel>() { new AppointmentModel()
            {
                AppointmentDescription = "xyz",
                ClientID = Guid.NewGuid(),
                AppointmentTypeID = 2,
                AppointmentTypeName = "xyz",
                DateTime = DateTime.Now,
                Id = newGuid
            } };

            // Act
            List<AppointmentDto> result = AppointmentAssembler.EntitiesToDto(appointments);

            // Assert
            Assert.IsTrue(result.SequenceEqual(appointmentDtos));
        }

        [TestMethod]
        public void ConverterDeDtosParaEntities()
        {
            // Arrange
            Guid newGuid = Guid.NewGuid();
            List<AppointmentDto> appointmentDtos = new List<AppointmentDto>() { new AppointmentDto()
            {
                AppointmentDescription = "xyz",
                ClientID = Guid.NewGuid(),
                AppointmentTypeID = 2,
                AppointmentTypeName = "xyz",
                DateTime = DateTime.Now,
                Id = newGuid
            } };

            List<AppointmentModel> appointments = new List<AppointmentModel>() { new AppointmentModel()
            {
                AppointmentDescription = "xyz",
                ClientID = Guid.NewGuid(),
                AppointmentTypeID = 2,
                AppointmentTypeName = "xyz",
                DateTime = DateTime.Now,
                Id = newGuid
            } };

            // Act
            List<AppointmentModel> result = AppointmentAssembler.DtosToEntities(appointmentDtos);

            // Assert
            Assert.IsTrue(result.SequenceEqual(appointments));
        }

        [TestMethod]
        public void ConverterDeEntitiesParaDtos_MasAsEntitiesSaoNull()
        {
            // Arrange, Act 
            List<AppointmentDto> result = AppointmentAssembler.EntitiesToDto(null);
            // Assert
            Assert.IsTrue(result.SequenceEqual(new List<AppointmentDto>()));
        }

        [TestMethod]
        public void ConverterDeDtosParaEntities_MasODtoEstaVazio()
        {
            // Arrange, Act 
            AppointmentModel result = AppointmentAssembler.DtoToEntity(null);
            // Assert
            Assert.IsTrue(result.Equals(new AppointmentModel()));
        }
    }
}
