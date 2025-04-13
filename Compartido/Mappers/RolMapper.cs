using Compartido.DTOs;
using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.Mappers
{
    public class RolMapper
    {
        public static List<RolDetallesDTO> RolToRolDetallesDTO(List<Rol> roles)
        {
            return roles.Select(rol => new RolDetallesDTO()
            {
                Id = rol.Id,
                Nombre = rol.Nombre
            }).ToList();
        }
    }
}
