using Compartido.DTOs;
using Compartido.Mappers;
using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso
{
    public class ListarRoles : IListarRoles
    {
        private IRepositorioRol _repoRol { get; set; }
        public ListarRoles(IRepositorioRol repoRol)
        {
            _repoRol = repoRol;
        }
        public List<InfoSelectDTO> Ejecutar()
        {
            List<Rol> roles = _repoRol.GetAll().ToList();
            return RolMapper.RolToRolDetallesDTO(roles);
        }
    }
}
