using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOs.Envio
{
    public class EnvioComunDTO
    {
        public int ClienteId { get; set; }
        public int AgenciaId { get; set; }
        public decimal Peso { get; set; }
    }
}
