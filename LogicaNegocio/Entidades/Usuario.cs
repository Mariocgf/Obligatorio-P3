using LogicaNegocio.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class Usuario : IEquatable<Usuario>
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string CI { get; set; }
        public string Celular { get; set; }
        public Email Email { get; set; }
        public Password Password { get; set; }
        public int RolId { get; set; }
        public Usuario(string nombre, string apellido, string cI, string celular, string email, string password, int rolId)
        {
            Nombre = nombre;
            Apellido = apellido;
            CI = cI;
            Celular = celular;
            Email = new Email(email);
            Password = new Password(password);
            RolId = rolId;
        }
        public Usuario() { }

        public bool Equals(Usuario? other)
        {
            return Email.Equals(other?.Email);
        }
    }
}
