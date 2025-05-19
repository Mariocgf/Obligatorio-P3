using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    [Table("EnvioComun")]
    public class Comun : Envio
    {
        public Agencia AgenciaDestino { get; set; }
        public Comun(Usuario empleado, Usuario cliente, decimal peso, Agencia agenciaDestino) : base( empleado, cliente, peso)
        {
            AgenciaDestino = agenciaDestino;
        }
        private Comun() { }

        public override void FinalizarEnvio()
        {
            base.FinalizarEnvio();
        }
    }
}
