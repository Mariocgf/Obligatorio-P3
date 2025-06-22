using Compartido.DTOs.Envio;

namespace LogicaAplicacion.InterfacesCasosUso.EnvioCU
{
    public interface IDetalleEnvio
    {
        EnvioDetalleDto Ejecutar(int id);
    }
}
