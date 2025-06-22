using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOs.Envio
{
    public class ComentarioDto
    {
        public int IdEnvio { get; set; }
        public int IdEmpleado { get; set; }
        public string Comentario { get; set; }
    }
}
