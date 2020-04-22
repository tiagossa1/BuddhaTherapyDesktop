using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TherapyManagementSystem.Domain.Entities;

namespace TherapyManagementSystem.Infrastructure.Data.Mapping
{
    public class AppointmentMap : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.ToTable("Appointment");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.AppointmentDate)
                .IsRequired()
                .HasColumnName("AppointmentDate");

            builder.Property(c => c.AppointmentTypeId)
                .IsRequired()
                .HasColumnName("AppointmentTypeId");

            builder.Property(c => c.AppointmentTypeDescription)
                .IsRequired()
                .HasColumnName("AppointmentTypeDescription");
        }
    }
}
