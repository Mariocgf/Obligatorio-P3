using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.Repositorio
{
    public class RepositorioRol : IRepositorioRol
    {
        private Context _context { get; set; }
        public RepositorioRol(Context context)
        {
            _context = context;
        }
        public void Add(Rol entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Rol entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Rol> GetAll()
        {
            return _context.Roles;
        }

        public Rol? GetById(int id)
        {
            return _context.Roles.Find(id);
        }
        public Rol? GetByName(string name)
        {
            return _context.Roles.FirstOrDefault(rol => rol.Nombre == name);
        }

        public void Update(Rol entity)
        {
            throw new NotImplementedException();
        }
    }
}
