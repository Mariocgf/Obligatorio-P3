using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOs.Envio
{
    public class EnvioUsuarioDto
    {
        public int Id { get; set; }
        public string NroTracking { get; set; }
        public DateTime Fecha { get; set; }
        public string Comentario { get; set; }
        public decimal Peso { get; set; }
        public string Estado { get; set; }
        public string TipoEnvio { get; set; }
    }
}
