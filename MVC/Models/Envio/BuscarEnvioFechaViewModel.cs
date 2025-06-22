namespace MVC.Models.Envio
{
    public class BuscarEnvioFechaViewModel
    {
        public int IdUser { get; set; }
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }
        public int Estado { get; set; }
    }
}
