using DomainModel.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class FysioDBContext : DbContext
    {
        public DbSet<PersonModel> Person { get; set; }
        public DbSet<PatientModel> Patient { get; set; }
        public DbSet<StudentModel> Student { get; set; }
        public DbSet<TeacherModel> Teacher { get; set; }
        public DbSet<TherapistModel> Therapists { get; set; }
        public FysioDBContext (DbContextOptions<FysioDBContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TherapistModel>().ToTable("Therapist");
            modelBuilder.Entity<PatientModel>().ToTable("Patient");
            modelBuilder.Entity<StudentModel>().ToTable("Student");
            modelBuilder.Entity<TeacherModel>().ToTable("Teacher");

        }
    }
}

