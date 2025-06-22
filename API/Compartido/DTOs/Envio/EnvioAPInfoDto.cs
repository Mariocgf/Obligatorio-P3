namespace Compartido.DTOs.Envio
{
    public class EnvioAPInfoDto
    {
        public string NroTracking { get; set; }
        public string Estado { get; set; }
        public decimal Peso { get; set; }
        public string TipoEnvio { get; set; }
        public string InfoAdicional { get; set; }
        public List<SeguimientoEnvioDto> Comentarios { get; set; }
}
}
