
namespace Compartido.DTOs.Envio
{
    public class EnvioDTO
    {
        public bool EsUrgente { get; set; }
        public int EmailCliente { get; set; }
        public int AgenciaId { get; set; }
        public string DireccionPostal { get; set; }
        public decimal Peso { get; set; }
    }
}
//El empleado ingresará:
//el tipo de envío
//el email del cliente
//la agencia de destino o la dirección postal,
//y el peso.
//El envío quedará guardado con los demás valores por defecto. 