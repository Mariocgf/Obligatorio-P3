using Compartido.DTOs.Envio;

namespace LogicaAplicacion.InterfacesCasosUso.EnvioCU
{
    public interface IListarEnvios
    {
        List<EnvioListadoDTO> Ejecutar();
    }
}
