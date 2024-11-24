using Microsoft.EntityFrameworkCore;

namespace ProyectoFinal.Models
{
    public class AgendaDBContext : DbContext
    {
        public AgendaDBContext(DbContextOptions<AgendaDBContext> options) : base(options)
        {

        }
        public DbSet<Doctor> Doctores { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Cita> Citas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relación entre Doctor y Cita
            modelBuilder.Entity<Cita>()
                .HasOne(c => c.Doctor)
                .WithMany(d => d.Citas)
                .HasForeignKey(c => c.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación entre Paciente y Cita
            modelBuilder.Entity<Cita>()
                .HasOne(c => c.Paciente)
                .WithMany(p => p.Citas)
                .HasForeignKey(c => c.PacienteId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}
