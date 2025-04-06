using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class Urgente : Envio
    {
        public string Direccion { get; set; }
        public bool EntregadoEficiente { get; set; }
        public DateTime FechaEntrega { get; set; }
        public Urgente(string nroTracking, Usuario empleado, Usuario cliente, decimal peso, string direccion, bool entregadoEficiente, DateTime fechaEntrega) : base(nroTracking, empleado, cliente, peso)
        {
            Direccion = direccion;
            EntregadoEficiente = entregadoEficiente;
            FechaEntrega = fechaEntrega;
        }
    }
}
