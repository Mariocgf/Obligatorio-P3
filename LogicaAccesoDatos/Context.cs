using LogicaNegocio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace LogicaAccesoDatos
{
    public class Context : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }
        //public DbSet<Envio> Envios { get; set; }
        //public DbSet<Agencia> Agencias { get; set; }
        public Context(DbContextOptions options) : base(options)
        {
        }
    }
}
