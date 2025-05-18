using Compartido.DTOs;
using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio.InterfacesRepositorio;
using LogicaNegocio.Entidades;
using LogicaNegocio.ExepcionesEntidades;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compartido.Mappers;

namespace LogicaAplicacion.CasosUso
{
    public class UsuarioLogin : IUsuarioLogin
    {
        private readonly IRepositorioUsuario _repoUsuario;
        private readonly IRepositorioRol _repoRol;
        public UsuarioLogin(IRepositorioUsuario repositorioUsuario, IRepositorioRol repositorioRol)
        {
            _repoUsuario = repositorioUsuario;
            _repoRol = repositorioRol;
        }
        public UsuarioLoggedDTO Login(string email, string password)
        {
            Usuario? usuario = _repoUsuario.GetByEmail(email);
            if(usuario == null && usuario.Password.Value != password)
                throw new UsuarioException("Credenciales invalidas");
            
            Rol rol = _repoRol.GetById(usuario.RolId) ?? throw new RolException("El rol no existe.");
            if (rol.Nombre == "Cliente")
                throw new UsuarioException("El cliente no tiene permisos para acceder a esta funcionalidad.");
            return UsuarioMapper.UsuarioTOUsurioLoggedDTO(usuario, rol);
        }
    }
}
