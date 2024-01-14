using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webhelp.PruebaTecnica.Infrastructure.Entities;

namespace Webhelp.PruebaTecnica.Infrastructure
{
    public class MedicalCenterDBContext : DbContext
    {
        public MedicalCenterDBContext(DbContextOptions options) : base(options) { }

        internal DbSet<AppointmentStateEntity> AppointmentStateEntity { get; set; }
        internal DbSet<DocumentTypeEntity> DocumentTypeEntity { get; set; }
        internal DbSet<AppointmentEntity> AppointmentEntity { get; set; }
        internal DbSet<PatientEntity> PatientEntity { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<PatientEntity>()
                .HasIndex(u => u.Document)
                .IsUnique();
        }
    }
}
