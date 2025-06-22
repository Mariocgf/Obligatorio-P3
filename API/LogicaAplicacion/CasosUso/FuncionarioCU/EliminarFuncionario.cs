using LogicaAplicacion.InterfacesCasosUso.FuncionarioCU;
using LogicaNegocio.Entidades;
using LogicaNegocio.ExepcionesEntidades;
using LogicaNegocio.InterfacesRepositorio;

namespace LogicaAplicacion.CasosUso.FuncionarioCU
{
    public class EliminarFuncionario : IEliminarFuncionario
    {
        private readonly IRepositorioUsuario _repoUsuario;
        private readonly IRepositorioAuditoria _repoAuditoria;
        public EliminarFuncionario(IRepositorioUsuario repoUsuario, IRepositorioAuditoria repoAuditoria)
        {
            _repoUsuario = repoUsuario;
            _repoAuditoria = repoAuditoria;
        }
        public void Ejecutar(int id, int idAdmin)
        {
            Usuario usuario = _repoUsuario.GetById(id) ?? throw new UsuarioException("El funcionario a eliminar no existe.");
            Usuario administrador = _repoUsuario.GetById(idAdmin) ?? throw new UsuarioException("Administrador no encontrado.");
            _repoUsuario.Delete(usuario);
            _repoAuditoria.Add(new Auditoria($"Eliminacion de funcionario {usuario.Id}", administrador));
        }
    }
}
