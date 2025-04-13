using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorio;
using LogicaNegocio.ExepcionesEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaAplicacion.InterfacesCasosUso.FuncionarioCU;
using Compartido.Mappers;
using Compartido.DTOs.Funcionario;

namespace LogicaAplicacion.CasosUso.FuncionarioCU
{
    public class ListarFuncionarios : IListarFuncionarios
    {
        private readonly IRepositorioUsuario _repoUsuario;
        private readonly IRepositorioRol _repoRol;
        public ListarFuncionarios(IRepositorioUsuario repoFuncionario, IRepositorioRol repoRol)
        {
            _repoUsuario = repoFuncionario;
            _repoRol = repoRol;
        }
        public List<FuncionarioListarDTO> Ejecutar()
        {
            Rol? rol = _repoRol.GetByName("Cliente");
            List<Rol> rolList = _repoRol.GetAll().Where(r => r.Nombre != "Cliente").ToList();
            List<Usuario> funcionarios = _repoUsuario.GetAll().Where(u => u.RolId != rol.Id).ToList();
            return
                rol == null
                ?
                throw new RolException("El rol no fue encontrado.")
                :
                FuncionarioMapper.FuncionarioToFuncionarioListarDTO(funcionarios, rolList);
        }
    }
}
