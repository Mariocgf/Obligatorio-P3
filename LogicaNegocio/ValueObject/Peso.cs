using LogicaNegocio.ExepcionesEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.ValueObject
{
    public class Peso
    {
        public decimal Value { get; }
        public Peso(decimal value)
        {
            Value = value;
            Validate();
        }
        private void Validate()
        {
            if (Value < 0)
            {
                throw new EnvioException("El peso no puede ser negativo.");
            }
        }
    }
}
