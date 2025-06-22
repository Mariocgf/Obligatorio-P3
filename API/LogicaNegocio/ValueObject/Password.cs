using LogicaNegocio.ExepcionesEntidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.ValueObject
{
    [ComplexType]
    public class Password
    {
        public string Value { get; private set; }
        public Password() { }
        public Password(string value)
        {
            Value = value;
            Validate();
        }
        private void Validate()
        {
            if (string.IsNullOrEmpty(Value))
            {
                throw new UsuarioException("La contraseña no puede estar vacia.");
            }
            if (Value.Length < 8)
            {
                throw new UsuarioException("La contraseña debe tener al menos 8 caracteres");
            }
        }
    }
}
