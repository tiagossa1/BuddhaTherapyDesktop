using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TherapyManagementSystem.Domain.Entities;
using TherapyManagementSystem.Infrastructure.Data.Mapping;

namespace TherapyManagementSystem.Infrastructure.Data.Context
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Therapist> Therapists { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Directory.CreateDirectory("C:/TMS");

            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlite("Data Source=C:/TMS/tms.db");
            //base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Appointment>(new AppointmentMap().Configure);
            modelBuilder.Entity<Client>(new ClientMap().Configure);
            modelBuilder.Entity<Invoice>(new InvoiceMap().Configure);
            modelBuilder.Entity<Therapist>(new TherapistMap().Configure);
        }
    }
}
