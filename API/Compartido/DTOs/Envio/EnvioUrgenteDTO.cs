
namespace Compartido.DTOs.Envio
{
    public class EnvioUrgenteDTO
    {
        public bool EsUrgente { get; set; }
        public int ClienteId { get; set; }
        public string DireccionPostal { get; set; }
        public decimal Peso { get; set; }
    }
}
