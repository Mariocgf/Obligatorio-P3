using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.Repositorio
{
    public class RepositorioUsuario : IRepositorioUsuario, IRepositorioFuncionario
    {
        private Context Context { get; set; }
        public RepositorioUsuario(Context context)
        {
            Context = context;
        }
        public void Add(Usuario entity)
        {
            if(entity == null)
                throw new ArgumentNullException("Datos vacios.");
            Usuario usuario = GetByEmail(entity.Email.Value);
            if (usuario != null)
                throw new ArgumentException("El usuario ya existe en la base de datos.");
            Context.Usuarios.Add(entity);
            Context.SaveChanges();
        }

        public void Delete(Usuario entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> GetAll()
        {
            return Context.Usuarios;
        }

        public Usuario? GetByEmail(string email)
        {
            return Context.Usuarios.FirstOrDefault(user => user.Email.Value == email);
        }

        public Usuario? GetById(int id)
        {
            return Context.Usuarios.FirstOrDefault(user => user.Id == id);
        }

        public void Update(Usuario entity)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Usuario> GetByFuncionario(int rolId)
        {
            return Context.Usuarios.Where(user => user.RolId == rolId);
        }
    }
}
