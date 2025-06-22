using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorio;
using Compartido.Mappers;
using LogicaAplicacion.InterfacesCasosUso.FuncionarioCU;
using LogicaNegocio.ExepcionesEntidades;
using Compartido.DTOs.Funcionario;

namespace LogicaAplicacion.CasosUso.FuncionarioCU
{
    public class AltaFuncionario : IAltaFuncionario
    {
        private readonly IRepositorioUsuario _repoUsuario;
        private readonly IRepositorioRol _repoRol;
        private readonly IRepositorioAuditoria _repoAuditoria;
        public AltaFuncionario(IRepositorioUsuario repoUsuario, IRepositorioRol repoRol, IRepositorioAuditoria repoAuditoria)
        {
            _repoUsuario = repoUsuario;
            _repoRol = repoRol;
            _repoAuditoria = repoAuditoria;
        }
        public void Ejecutar(FuncionarioDTO funcionarioDTO, int idUsuario)
        {
            if (funcionarioDTO == null)
                throw new ArgumentNullException("Datos invalidos.");
            Rol? rol = _repoRol.GetById(funcionarioDTO.RolId) ?? throw new RolException("Rol no encontrado.");
            Usuario funcionario = FuncionarioMapper.FuncionarioFromFuncionarioDTO(funcionarioDTO, rol);
            Usuario administrador = _repoUsuario.GetById(idUsuario) ?? throw new UsuarioException("Usuario no encontrado.");
            _repoUsuario.Add(funcionario);
            _repoAuditoria.Add(new Auditoria($"Alta de funcionario {funcionario.Id}", administrador));
        }
    }
}

