using System;
using System.Collections.Generic;
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
    public abstract class Envio
    {
        public int Id { get; set; }
        private static int _ultimoId = 0;
        public string NroTracking { get; set; }
        public Usuario Empleado { get; set; }
        public Usuario Cliente { get; set; }
        public decimal Peso { get; set; }
        public Estado Estado { get; set; }
        public Envio(string nroTracking, Usuario empleado, Usuario cliente, decimal peso)
        {
            Id = _ultimoId++;
            NroTracking = nroTracking;
            Empleado = empleado;
            Cliente = cliente;
            Peso = peso;
            Estado = Estado.EN_PROCESO;
        }
        private Envio() { }
    }
}
