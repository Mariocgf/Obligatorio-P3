using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    [Table("EnvioUrgente")]
    public class Urgente : Envio
    {
        public string Direccion { get; set; }
        public bool EntregadoEficiente { get; set; }
        public DateTime FechaEntrega { get; set; }
        public Urgente(Usuario empleado, Usuario cliente, decimal peso, string direccion) : base(empleado, cliente, peso)
        {
            Direccion = direccion;
        }
        private Urgente() { }
    }
}
