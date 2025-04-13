using Compartido.DTOs.Funcionario;
using Compartido.Mappers;
using LogicaAplicacion.InterfacesCasosUso.FuncionarioCU;
using LogicaNegocio.Entidades;
using LogicaNegocio.ExepcionesEntidades;
using LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.FuncionarioCU
{
    public class DetalleFuncionario : IDetalleFuncionario
    {
        private readonly IRepositorioUsuario _repoUsuario;
        private readonly IRepositorioRol _repoRol;
        public DetalleFuncionario(IRepositorioUsuario repoUsuario, IRepositorioRol repoRol)
        {
            _repoUsuario = repoUsuario;
            _repoRol = repoRol;
        }

        public FuncionarioDetailDTO Ejecutar(int id)
        {
            Usuario? funcionario = _repoUsuario.GetById(id) ?? throw new UsuarioException("Funcionario no encontrado.");
            return FuncionarioMapper.FuncionarioToFuncionarioDetailDTO(funcionario);
        }
    }
}
