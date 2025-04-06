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
        private IRepositorioUsuario RepositorioUsuario { get; set; }
        private IRepositorioRol _repositorioRol { get; set; }
        public UsuarioLogin(IRepositorioUsuario repositorioUsuario, IRepositorioRol repositorioRol)
        {
            RepositorioUsuario = repositorioUsuario;
            _repositorioRol = repositorioRol;
        }
        public UsuarioLoggedDTO Login(string email, string password)
        {
            Usuario? usuario = RepositorioUsuario.GetByEmail(email);
            if(usuario == null)
            {
                throw new UsuarioException("Usuario no registrado");
            }
            if (usuario.Password.Value != password)
            {
                throw new UsuarioException("Contraseña incorrecta");
            }
            Rol rol = _repositorioRol.GetById(usuario.RolId);
            if (rol.Nombre == "Cliente")
                throw new UsuarioException("El usuario no tiene permisos para acceder a esta funcionalidad");
            
            return UsuarioMapper.UsuarioTOUsurioLoggedDTO(usuario, rol);
        }
    }
}
