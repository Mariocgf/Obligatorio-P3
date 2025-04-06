using LogicaNegocio.ExepcionesEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.ValueObject
{
    public class Coordenada
    {
        public decimal Latitud { get; }
        public decimal Longitud { get; }
        public Coordenada(decimal latitud, decimal longitud)
        {
            Latitud = latitud;
            Longitud = longitud;
            Validate();
        }
        public void Validate()
        {
            if (Latitud < -90 || Latitud > 90)
            {
                throw new AgenciaException("Latitud fuera de rango");
            }
            if (Longitud < -180 || Longitud > 180)
            {
                throw new AgenciaException("Longitud fuera de rango");
            }
        }
    }
}
