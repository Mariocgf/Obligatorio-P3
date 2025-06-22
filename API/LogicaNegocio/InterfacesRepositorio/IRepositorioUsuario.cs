using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio.Entidades;
namespace LogicaNegocio.InterfacesRepositorio
{
    public interface IRepositorioUsuario : IRepositorio<Usuario>
    {
        Usuario? GetByEmail(string email);
        IEnumerable<Usuario> GetByRol(int rolId);

        Usuario? Login(string email, string password);
    }
}
