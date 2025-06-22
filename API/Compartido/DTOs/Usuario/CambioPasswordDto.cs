using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOs.Usuario
{
    public class CambioPasswordDto
    {
        public int Id { get; set; }
        public string PasswordOld { get; set; }
        public string PasswordNew { get; set; }
    }
}
