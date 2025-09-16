//References 
using Microsoft.EntityFrameworkCore;
using ClinicaAPI.Models;

namespace ClinicaAPI.Config
{
    public class AppDbContext : DbContext
    {
        // Constructor for the DbContext
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        { }
        public DbSet<Patient> Patients { get; set; }

        // override onModel Creating for custom datatime in SQL
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Patient>()
                .Property(p => p.FechaRegistro)
                .HasDefaultValueSql("GETDATE()");
        }
    }
}