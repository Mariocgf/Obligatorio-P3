using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class Seguimiento
    {
        public int Id { get; set; }
        public string Comentario { get; set; }
        public Usuario Empleado { get; set; }
        public DateTime Fecha { get; set; }
        public Seguimiento(string comentario, Usuario empleado)
        {
            Comentario = comentario;
            Empleado = empleado;
            Fecha = DateTime.Now;
        }
        private Seguimiento() { }
    }
}
