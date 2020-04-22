using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TherapyManagementSystem.Domain.Entities;

namespace TherapyManagementSystem.Infrastructure.Data.Mapping
{
    public class TherapistMap : IEntityTypeConfiguration<Therapist>
    {
        public void Configure(EntityTypeBuilder<Therapist> builder)
        {
            builder.ToTable("Therapist");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.FirstName)
                .IsRequired()
                .HasColumnName("FirstName");

            builder.Property(c => c.LastName)
                .IsRequired()
                .HasColumnName("LastName");

            builder.Property(c => c.Email)
                .IsRequired()
                .HasColumnName("Email");

            builder.Property(c => c.Username)
                .IsRequired()
                .HasColumnName("Username");

            builder.Property(c => c.Password)
                .IsRequired()
                .HasColumnName("Password");
        }
    }
}
