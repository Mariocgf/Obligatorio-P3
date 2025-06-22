
namespace Compartido.DTOs.Envio
{
    public class EnvioListadoDTO
    {
        public int Id { get; set; }
        public string NroTracking { get; set; }
        public string Empleado { get; set; }
        public string Cliente { get; set; }
        public decimal Peso { get; set; }
        public string Estado { get; set; }
        public string TipoEnvio { get; set; }
    }
}
