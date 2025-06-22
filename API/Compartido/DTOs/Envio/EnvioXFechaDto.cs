
namespace Compartido.DTOs.Envio
{
    public class EnvioXFechaDto
    {
        public int IdUser { get; set; }
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }
        public int Estado { get; set; }
    }
}
