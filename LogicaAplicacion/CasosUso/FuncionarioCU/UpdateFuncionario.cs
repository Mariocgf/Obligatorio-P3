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
    public class UpdateFuncionario : IUpdateFuncionario
    {
        private readonly IRepositorioUsuario _repoUsuario;
        private readonly IRepositorioRol _repoRol;
        private readonly IRepositorioAuditoria _repoAuditoria;
        public UpdateFuncionario(IRepositorioUsuario repoUsuario, IRepositorioRol repoRol, IRepositorioAuditoria repoAuditoria)
        {
            _repoUsuario = repoUsuario;
            _repoRol = repoRol;
            _repoAuditoria = repoAuditoria;
        }
        public void Ejecutar(FuncionarioUpdateDTO funcionarioDTO, int idAdmin)
        {
            if (funcionarioDTO == null)
                throw new ArgumentNullException("Datos vacios, no se puede actualizar los cambios.");
            Rol? rol = _repoRol.GetById(funcionarioDTO.RolId) ?? throw new RolException("El rol no existe.");
            Usuario usuario = FuncionarioMapper.FuncionarioFromFuncionarioUpdateDTO(funcionarioDTO, rol);
            Usuario administrador = _repoUsuario.GetById(idAdmin) ?? throw new UsuarioException("Administrador no encontrado.");
            usuario.Id = funcionarioDTO.Id;
            _repoUsuario.Update(usuario);
            _repoAuditoria.Add(new Auditoria($"Actualizacion de funcionario {usuario.Id}", administrador));
        }
    }
}
