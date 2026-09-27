using Hospital.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Treatment> Treatments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Treatment>()
                .HasOne(t => t.Doctor)
                .WithMany(t => t.Treatments)
                .HasForeignKey(t => t.DoctorId);

            modelBuilder.Entity<Treatment>()
                .HasOne(t => t.Patient)
                .WithMany(t => t.Treatments)
                .HasForeignKey(t => t.PatientId);
        }
    }
}
