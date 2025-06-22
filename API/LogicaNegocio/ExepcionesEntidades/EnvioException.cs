using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.ExepcionesEntidades
{
    public class EnvioException : Exception
    {
        public EnvioException() { }
        public EnvioException(string message) : base(message) { }
        public EnvioException(string message, Exception inner) : base(message, inner) { }
    }
}
