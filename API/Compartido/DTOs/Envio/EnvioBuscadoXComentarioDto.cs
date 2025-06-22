using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOs.Envio
{
    public class EnvioBuscadoXComentarioDto
    {
        public string NroTracking { get; set; }
        public string Comentario { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; }
        public string TipoEnvio { get; set; }
    }
}
