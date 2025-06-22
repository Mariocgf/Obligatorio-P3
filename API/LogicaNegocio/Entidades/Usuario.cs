using LogicaNegocio.ExepcionesEntidades;
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
        public Rol Rol { get; set; }
        public int RolId { get; set; }
        public Usuario(string nombre, string apellido, string cI, string celular, string email, string password, Rol rol)
        {
            Nombre = nombre;
            Apellido = apellido;
            CI = cI;
            Celular = celular;
            Email = new Email(email);
            Password = new Password(password);
            Rol = rol;
            RolId = rol.Id;
            Validate();
            FormatearCedula();
        }
        public Usuario() { }
        public void Validate()
        {
            if(string.IsNullOrEmpty(CI))
                throw new UsuarioException("CI no puede estar vacío");
            if(CI.Length != 8)
                throw new UsuarioException("CI debe tener 8 dígitos");
        }
        public void FormatearCedula()
        {
            string cedula = $"{CI[0]}.";
            for (int i = 1; i < CI.Length; i++)
            {
                if (i == 3)
                    cedula += $"{CI[i]}.";
                else if (i == 6)
                    cedula += $"{CI[i]}-";
                else
                    cedula += CI[i];
            }
            CI = cedula;
        }
        public bool Equals(Usuario? other)
        {
            return Email.Equals(other?.Email);
        }
    }
}
