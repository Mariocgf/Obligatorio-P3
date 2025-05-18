using LogicaNegocio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace LogicaAccesoDatos
{
    public class Context : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Urgente> EnvioUrgente { get; set; }
        public DbSet<Comun> EnvioComun { get; set; }
        public DbSet<Agencia> Agencias { get; set; }
        public DbSet<Auditoria> Auditorias { get; set; }
        public DbSet<Envio> Envios { get; set; }
        public Context(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().HasOne(u => u.Rol).WithMany().OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Envio>().HasOne(e => e.Cliente).WithMany().OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Envio>().HasOne(e => e.Empleado).WithMany().OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Envio>().UseTptMappingStrategy();
            modelBuilder.Entity<Envio>().Property(e => e.Peso).HasPrecision(5, 2);
            modelBuilder.Entity<Auditoria>().HasOne(a => a.Empleado).WithMany().OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Seguimiento>().HasOne(s => s.Empleado).WithMany().OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);
        }
    }
}
