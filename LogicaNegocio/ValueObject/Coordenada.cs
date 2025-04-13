using LogicaNegocio.ExepcionesEntidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.ValueObject
{
    [ComplexType]
    public record Coordenada
    {
        public decimal Latitud { get; init; }
        public decimal Longitud { get; init; }
        private Coordenada() { }
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
