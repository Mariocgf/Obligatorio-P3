using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public enum Estados
    {
        EN_PROCESO,
        FINALIZADO
    }
    [Table("Envio")]
    public abstract class Envio
    {
        public int Id { get; set; }
        public string NroTracking { get; set; }
        public Usuario Empleado { get; set; }
        public Usuario Cliente { get; set; }
        public decimal Peso { get; set; }
        public Estados Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaEntrega { get; set; }
        public Envio(Usuario empleado, Usuario cliente, decimal peso)
        {
            NroTracking = Guid.NewGuid().ToString();
            Empleado = empleado;
            Cliente = cliente;
            Peso = peso;
            Estado = Estados.EN_PROCESO;
            FechaCreacion = DateTime.Now;
        }
        public Envio() { }
    }
}
