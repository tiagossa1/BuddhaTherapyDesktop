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
            AppointmentDto appointmentDto = new AppointmentDto(newGuid, Guid.NewGuid(), DateTime.Now, 1, "xyz", "xyz");

            AppointmentModel appointment = new AppointmentModel(newGuid, Guid.NewGuid(), DateTime.Now, 1, "xyz", "xyz");

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
            AppointmentDto AppointmentDto = new AppointmentDto(newGuid, Guid.NewGuid(), DateTime.Now, 1, "xyz", "xyz");

            AppointmentModel cliente = new AppointmentModel(newGuid, Guid.NewGuid(), DateTime.Now, 1, "xyz", "xyz");

            // Act
            AppointmentDto result = AppointmentAssembler.EntityToDto(cliente);

            // Assert
            Assert.IsTrue(result.Equals(AppointmentDto));
        }

        [TestMethod]
        public void AppointmentAssembler_ConverterDeEntitiesParaDtos()
        {
            // Arrange
            Guid newGuid = Guid.NewGuid();

            List<AppointmentDto> appointmentDtos = new List<AppointmentDto>() { new AppointmentDto(newGuid, Guid.NewGuid(), DateTime.Now, 1, "xyz", "xyz") };

            List<AppointmentModel> appointment = new List<AppointmentModel>() { new AppointmentModel(newGuid, Guid.NewGuid(), DateTime.Now, 1, "xyz", "xyz") };

            // Act
            List<AppointmentDto> result = AppointmentAssembler.EntitiesToDto(appointment);

            // Assert
            Assert.IsTrue(result.SequenceEqual(appointmentDtos));
        }

        [TestMethod]
        public void ConverterDeDtosParaEntities()
        {
            // Arrange
            Guid newGuid = Guid.NewGuid();
            List<AppointmentDto> appointmentDtos = new List<AppointmentDto>() { new AppointmentDto(newGuid, Guid.NewGuid(), DateTime.Now, 1, "xyz", "xyz") };

            List<AppointmentModel> cliente = new List<AppointmentModel>() { new AppointmentModel(newGuid, Guid.NewGuid(), DateTime.Now, 1, "xyz", "xyz") };

            // Act
            List<AppointmentModel> result = AppointmentAssembler.DtosToEntities(appointmentDtos);

            // Assert
            Assert.IsTrue(result.SequenceEqual(cliente));
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
