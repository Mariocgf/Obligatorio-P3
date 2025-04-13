using LogicaNegocio.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class Agencia
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public Coordenada Coordenada { get; set; }
        public Agencia(string nombre, string direccion, decimal latitud, decimal longitud)
        {
            Nombre = nombre;
            Direccion = direccion;
            Coordenada = new Coordenada(latitud, longitud);
        }
        private Agencia() { }
    }
}
