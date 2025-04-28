using Compartido.DTOs;
using LogicaNegocio.Entidades;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.Mappers
{
    public class UsuarioMapper
    {
        public static UsuarioLoggedDTO UsuarioTOUsurioLoggedDTO(Usuario usuario, Rol rol)
        {
            return new UsuarioLoggedDTO()
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                Email = usuario.Email.Value,
                Rol = rol.Nombre
            };
        }
        public static List<InfoSelectDTO> UsuarioToInfoSelectDto(List<Usuario> usuarios)
        {
            return [..usuarios.Select(u => new InfoSelectDTO()
            {
                Id = u.Id,
                Nombre = u.Email.Value
            })];
        }
    }
}
