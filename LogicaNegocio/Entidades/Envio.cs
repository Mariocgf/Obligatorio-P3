using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public enum Estado
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
        public Estado Estado { get; set; }
        public Envio(Usuario empleado, Usuario cliente, decimal peso)
        {
            NroTracking = Guid.NewGuid().ToString();
            Empleado = empleado;
            Cliente = cliente;
            Peso = peso;
            Estado = Estado.EN_PROCESO;
        }
        public Envio() { }
    }
}
