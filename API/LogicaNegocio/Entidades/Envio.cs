using LogicaNegocio.ExepcionesEntidades;
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
        public List<Seguimiento> ListaSeguimiento { get; set; } = new List<Seguimiento>();
        public Envio(Usuario empleado, Usuario cliente, decimal peso)
        {
            NroTracking = Guid.NewGuid().ToString();
            Empleado = empleado;
            Cliente = cliente;
            Peso = peso;
            Estado = Estados.EN_PROCESO;
            FechaCreacion = DateTime.Now;
            Validate();
        }
        public void Validate()
        {
            if (Peso <= 0)
                throw new EnvioException("El peso debe ser mayor a 0");
            if (Empleado == null)
                throw new EnvioException("El empleado no puede ser nulo");
            if (Cliente == null)
                throw new EnvioException("El cliente no puede ser nulo");
        }
        public Envio() { }

        public virtual void FinalizarEnvio()
        {
            FechaEntrega = DateTime.Now;
            Estado = Estados.FINALIZADO;
        }
    }
}
