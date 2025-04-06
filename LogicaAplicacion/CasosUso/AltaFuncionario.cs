using Compartido.DTOs;
using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorio;
using Compartido.Mappers;

namespace LogicaAplicacion.CasosUso
{
    public class AltaFuncionario : IAltaFuncionario
    {
        private IRepositorioUsuario _repoUsuario { get; set; }
        private IRepositorioRol _repoRol { get; set; }
        public AltaFuncionario(IRepositorioUsuario repoUsuario, IRepositorioRol repoRol)
        {
            _repoUsuario = repoUsuario;
            _repoRol = repoRol;
        }
        public void Ejecutar(FuncionarioDTO funcionarioDTO)
        {
            if (funcionarioDTO == null)
                throw new ArgumentNullException("Datos invalidos.");
            Rol rolFuncionario = _repoRol.GetByName("Funcionario");
            funcionarioDTO.RolId = rolFuncionario.Id;
            Usuario funcionario = FuncionarioMapper.FuncionarioFromFuncionarioDTO(funcionarioDTO);
            _repoUsuario.Add(funcionario);
        }
    }
}

