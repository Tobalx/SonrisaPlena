using ClinicaDental.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClinicaDental.Models.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Odontologo> Odontologos { get; set; }
        public DbSet<Administrador> Administradores { get; set; }
        public DbSet<Recepcionista> Recepcionistas { get; set; }
        public DbSet<Turno> Turnos { get; set; }
        public DbSet<Tratamiento> Tratamientos { get; set; }
        public DbSet<EjecucionTratamiento> EjecucionesTratamiento { get; set; }
        public DbSet<TratamientoPorTurno> TratamientosPorTurno { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Paciente
            modelBuilder.Entity<Paciente>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Nombre).IsRequired().HasMaxLength(100);
                entity.Property(p => p.RUT).HasMaxLength(20);
                entity.Property(p => p.Telefono).HasMaxLength(20);
                entity.Property(p => p.Email).HasMaxLength(100);
                entity.Property(p => p.Direccion).HasMaxLength(200);

                entity.HasMany(p => p.Turnos)
                      .WithOne(t => t.Paciente)
                      .HasForeignKey(t => t.PacienteId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(p => p.EjecucionesTratamiento)
                      .WithOne(e => e.Paciente)
                      .HasForeignKey(e => e.PacienteId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(p => p.Usuario)
                      .WithOne(u => u.Paciente)
                      .HasForeignKey<Usuario>(u => u.PacienteId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // Odontologo
            modelBuilder.Entity<Odontologo>(entity =>
            {
                entity.HasKey(o => o.Id);
                entity.Property(o => o.Nombre).IsRequired().HasMaxLength(100);
                entity.Property(o => o.Matricula).HasMaxLength(50);
                entity.Property(o => o.Especialidad).HasMaxLength(100);
                entity.Property(o => o.Email).HasMaxLength(100);

                entity.HasOne<Administrador>(o => o.CreadoPorAdministrador)
                      .WithMany(a => a.Odontologos)
                      .HasForeignKey(o => o.CreadoPorAdministradorId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(o => o.Turnos)
                      .WithOne(t => t.Odontologo)
                      .HasForeignKey(t => t.OdontologoId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(o => o.EjecucionesTratamiento)
                      .WithOne(e => e.Odontologo)
                      .HasForeignKey(e => e.OdontologoId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(o => o.Usuario)
                      .WithOne(u => u.Odontologo)
                      .HasForeignKey<Usuario>(u => u.OdontologoId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // Administrador
            modelBuilder.Entity<Administrador>(entity =>
            {
                entity.HasKey(a => a.Id);
                entity.Property(a => a.Nombre).IsRequired().HasMaxLength(100);
                entity.Property(a => a.Email).HasMaxLength(100);

                entity.HasMany(a => a.Odontologos)
                      .WithOne(o => o.CreadoPorAdministrador)
                      .HasForeignKey(o => o.CreadoPorAdministradorId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(a => a.Tratamientos)
                      .WithOne(t => t.CreadoPorAdministrador)
                      .HasForeignKey(t => t.CreadoPorAdministradorId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(a => a.Usuario)
                      .WithOne(u => u.Administrador)
                      .HasForeignKey<Usuario>(u => u.AdministradorId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // Recepcionista
            modelBuilder.Entity<Recepcionista>(entity =>
            {
                entity.HasKey(r => r.Id);
                entity.Property(r => r.Nombre).IsRequired().HasMaxLength(100);
                entity.Property(r => r.Email).HasMaxLength(100);

                entity.HasMany(r => r.Turnos)
                      .WithOne(t => t.Recepcionista)
                      .HasForeignKey(t => t.RecepcionistaId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(r => r.Usuario)
                      .WithOne(u => u.Recepcionista)
                      .HasForeignKey<Usuario>(u => u.RecepcionistaId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // Turno
            modelBuilder.Entity<Turno>(entity =>
            {
                entity.HasKey(t => t.Id);
                entity.Property(t => t.Estado).HasMaxLength(20);
                entity.Property(t => t.Hora).IsRequired();
                entity.Property(t => t.DuracionMinutos).IsRequired();

                entity.HasMany(t => t.TratamientosPorTurno)
                      .WithOne(tp => tp.Turno)
                      .HasForeignKey(tp => tp.TurnoId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // Tratamiento
            modelBuilder.Entity<Tratamiento>(entity =>
            {
                entity.HasKey(t => t.Id);
                entity.Property(t => t.Nombre).IsRequired().HasMaxLength(100);
                entity.Property(t => t.Descripcion).HasMaxLength(500);

                entity.HasOne(t => t.CreadoPorAdministrador)
                      .WithMany(a => a.Tratamientos)
                      .HasForeignKey(t => t.CreadoPorAdministradorId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<EjecucionTratamiento>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Estado).HasMaxLength(20);
                entity.Property(e => e.Observaciones).HasMaxLength(1000);
                entity.Property(e => e.ObservacionesGenerales).HasMaxLength(1000);

                entity.HasOne(e => e.Paciente)
                      .WithMany(p => p.EjecucionesTratamiento)
                      .HasForeignKey(e => e.PacienteId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Odontologo)
                      .WithMany(o => o.EjecucionesTratamiento)
                      .HasForeignKey(e => e.OdontologoId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(e => e.TratamientosPorTurno)
                      .WithOne(tp => tp.EjecucionTratamiento)
                      .HasForeignKey(tp => tp.EjecucionTratamientoId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(e => e.EjecucionTratamientoDetalles)
                      .WithOne(d => d.EjecucionTratamiento)
                      .HasForeignKey(d => d.EjecucionTratamientoId)
                      .OnDelete(DeleteBehavior.Restrict);
            });
            // EjecucionTratamientoDetalle
            modelBuilder.Entity<EjecucionTratamientoDetalle>(entity =>
                {
                    entity.HasKey(d => d.Id);

                    entity.HasOne(d => d.EjecucionTratamiento)
                          .WithMany(e => e.EjecucionTratamientoDetalles)
                          .HasForeignKey(d => d.EjecucionTratamientoId)
                          .OnDelete(DeleteBehavior.Restrict);

                    entity.HasOne(d => d.Tratamiento)
                          .WithMany()
                          .HasForeignKey(d => d.TratamientoId)
                          .OnDelete(DeleteBehavior.Restrict);
                });

            // TratamientoPorTurno
            modelBuilder.Entity<TratamientoPorTurno>(entity =>
            {
                entity.HasKey(tp => tp.Id);
                entity.Property(tp => tp.EstadoPaso).HasMaxLength(20);
                entity.Property(tp => tp.ObservacionesTurno).HasMaxLength(1000);
            });

            // Usuario
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(u => u.Id);
                entity.Property(u => u.NombreUsuario).IsRequired().HasMaxLength(50);
                entity.Property(u => u.Contrasena).IsRequired().HasMaxLength(100);

                entity.HasOne(u => u.Rol)
                      .WithMany(r => r.Usuarios)
                      .HasForeignKey(u => u.RolId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(u => u.Paciente)
                      .WithOne(p => p.Usuario)
                      .HasForeignKey<Usuario>(u => u.PacienteId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(u => u.Odontologo)
                      .WithOne(o => o.Usuario)
                      .HasForeignKey<Usuario>(u => u.OdontologoId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(u => u.Administrador)
                      .WithOne(a => a.Usuario)
                      .HasForeignKey<Usuario>(u => u.AdministradorId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(u => u.Recepcionista)
                      .WithOne(r => r.Usuario)
                      .HasForeignKey<Usuario>(u => u.RecepcionistaId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // Rol
            modelBuilder.Entity<Rol>(entity =>
            {
                entity.HasKey(r => r.Id);
                entity.Property(r => r.Nombre).IsRequired().HasMaxLength(50);
            });


        }
        public DbSet<ClinicaDental.Models.Entities.EjecucionTratamientoDetalle> EjecucionTratamientoDetalle { get; set; } = default!;
    }
}

     


