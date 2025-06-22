using Compartido.DTOs.Usuario;
using Compartido.Exceptions;
using LogicaAplicacion.InterfacesCasosUso.UsuarioCU;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorio;
using LogicaNegocio.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.UsuarioCU
{
    public class CambiarPassword : ICambiarPassword
    {
        private readonly IRepositorioUsuario _repoUsuario;
        public CambiarPassword(IRepositorioUsuario repoUsuario)
        {
            _repoUsuario = repoUsuario;
        }
        public void Ejecutar (CambioPasswordDto dto)
        {
            Usuario usuario = _repoUsuario.GetById(dto.Id) ?? throw new ArgumentException("No se encontro el usuario");
            if (usuario.Password.Value != dto.PasswordOld)
                throw new ConflictException("Contrasenia actual distina a la original");
            Password password = new Password(dto.PasswordNew);
            usuario.Password = password;
            _repoUsuario.Update(usuario);
        }
    }
}
