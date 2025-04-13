using Compartido.DTOs.Agencia;

namespace LogicaAplicacion.InterfacesCasosUso.AgenciaCU
{
    public interface IListarSAgencia
    {
        List<AgenciaSelectDTO> Ejecutar();
    }
}
