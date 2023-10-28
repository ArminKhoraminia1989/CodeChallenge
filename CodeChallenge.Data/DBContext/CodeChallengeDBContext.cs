using Microsoft.EntityFrameworkCore;
using CodeChallenge.Core.Entities;
using CodeChallenge.Core.FluentConfiges;
using CodeChallenge.Core.FluentConfiges.BasicInfo;
using CodeChallenge.Core.Entities.BasicInfo;

namespace CodeChallenge.Data.DBContext
{
    public class CodeChallengeDBContext : DbContext
    {
        public CodeChallengeDBContext(DbContextOptions<CodeChallengeDBContext> option) : base(option)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CodeChallengeDBContext).Assembly);

            modelBuilder.ApplyConfiguration(new FluentDoctorConfig());
            modelBuilder.ApplyConfiguration(new FluentDrugConfig());
            modelBuilder.ApplyConfiguration(new FluentDoctorTypeConfig());
            modelBuilder.ApplyConfiguration(new FluentDoctorSchedulerConfig());
            modelBuilder.ApplyConfiguration(new FluentPatientConfig());
            modelBuilder.ApplyConfiguration(new FluentAppointmentConfig());
            modelBuilder.ApplyConfiguration(new FluentAppointmentDrugConfig());
        }

        #region DB Sets

        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<Drug> Drug { get; set; }
        public DbSet<DoctorType> DoctorType { get; set; }
        public DbSet<DoctorScheduler> DoctorScheduler { get; set; }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<Appointment> Appointment { get; set; }
        public DbSet<AppointmentDrug> AppointmentDrug { get; set; }

        #endregion



    }
}
