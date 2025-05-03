namespace MVC.Models.Envio
{
    public class EnvioDetalleViewModel
    {
        public int Id { get; set; }
        public string NroTracking { get; set; }
        public string Empleado { get; set; }
        public string Cliente { get; set; }
        public decimal Peso { get; set; }
        public string Estado { get; set; }
        public string TipoEnvio { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaEntrega { get; set; }
        public List<string> Estados  = new List<string>();
    }
}
