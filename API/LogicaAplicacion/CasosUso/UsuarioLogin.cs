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
        public UsuarioLoggedDTO Login(LoginDTO loginDto)
        {
            Usuario? usuario = _repoUsuario.GetByEmail(loginDto.email) ?? throw new UsuarioException("Credenciales invalidas");
            Rol rol = _repoRol.GetById(usuario.RolId) ?? throw new RolException("El rol no existe.");
            return UsuarioMapper.UsuarioTOUsurioLoggedDTO(usuario, rol);
        }
    }
}
