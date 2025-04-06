using Compartido.DTOs;
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
    public class ListarFuncionarios : IListarFuncionarios
    {
        private IRepositorioFuncionario _repoFuncionario { get; set; }
        private IRepositorioRol _repoRol { get; set; }
        public ListarFuncionarios(IRepositorioFuncionario repoFuncionario, IRepositorioRol repoRol)
        {
            _repoFuncionario = repoFuncionario;
            _repoRol = repoRol;
        }
        public List<FuncionarioListarDTO> Ejecutar()
        {
            Rol rol = _repoRol.GetByName("Funcionario");
            return _repoFuncionario.GetByFuncionario(rol.Id).Select(funcionario => new FuncionarioListarDTO
            {
                Id = funcionario.Id,
                Nombre = funcionario.Nombre,
                Apellido = funcionario.Apellido,
                CI = funcionario.CI,
                Email = funcionario.Email.Value,
            }).ToList();
        }
    }
}
