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
