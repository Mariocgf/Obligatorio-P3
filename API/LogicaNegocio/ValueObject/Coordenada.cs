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

        }
        
    }
}
