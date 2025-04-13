using Compartido.DTOs.Funcionario;

namespace LogicaAplicacion.InterfacesCasosUso.FuncionarioCU
{
    public interface IListarFuncionarios
    {
        List<FuncionarioListarDTO> Ejecutar();
    }
}
