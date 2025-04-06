using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class Comun : Envio
    {
        public Agencia AgenciaDestino { get; set; }
        public Comun(string nroTracking, Usuario empleado, Usuario cliente, decimal peso, Agencia agenciaDestino) : base(nroTracking, empleado, cliente, peso)
        {
            AgenciaDestino = agenciaDestino;
        }
    }
}
