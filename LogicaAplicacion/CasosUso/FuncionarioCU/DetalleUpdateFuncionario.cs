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
    public class DetalleUpdateFuncionario : IDetalleUpdateFuncionario
    {
        private readonly IRepositorioUsuario _repoUsuario;
        public DetalleUpdateFuncionario(IRepositorioUsuario repoUsuario)
        {
            _repoUsuario = repoUsuario;
        }
        public FuncionarioUpdateDTO Ejecutar(int id)
        {
            Usuario usuario = _repoUsuario.GetById(id) ?? throw new UsuarioException("Funcionario no encontrado.");
            return FuncionarioMapper.FuncionarioToFuncionarioUpdateDTO(usuario);
        }
    }
}
