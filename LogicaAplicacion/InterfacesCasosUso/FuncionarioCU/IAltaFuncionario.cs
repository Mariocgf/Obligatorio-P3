using Compartido.DTOs.Funcionario;

namespace LogicaAplicacion.InterfacesCasosUso.FuncionarioCU
{
    public interface IAltaFuncionario
    {
        void Ejecutar(FuncionarioDTO funcionarioDTO, int idUsuario);
    }
}
