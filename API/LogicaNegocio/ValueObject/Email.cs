using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio.ExepcionesEntidades;

namespace LogicaNegocio.ValueObject
{
    [ComplexType]
    public record Email
    {

        public string Value { get; init; }
        public Email() { }
        public Email(string value)
        {
            Value = value;
            Validate();
        }
        private void Validate()
        {
            if (string.IsNullOrEmpty(Value))
            {
                throw new UsuarioException("El email no puede estar vacio.");
            }
            if (!Value.Contains("@"))
            {
                throw new UsuarioException("El email debe contener un @.");
            }
            if (!Value.EndsWith(".com"))
            {
                throw new UsuarioException("El email debe terminar con .com.");
            }
        }
    }
}
