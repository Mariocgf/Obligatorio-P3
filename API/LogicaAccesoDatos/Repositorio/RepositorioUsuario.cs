using LogicaNegocio.Entidades;
using LogicaNegocio.ExepcionesEntidades;
using LogicaNegocio.InterfacesRepositorio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.Repositorio
{
    public class RepositorioUsuario : IRepositorioUsuario
    {
        private readonly Context _context;
        public RepositorioUsuario(Context context)
        {
            _context = context;
        }
        public void Add(Usuario entity)
        {
            if (entity == null)
                throw new ArgumentNullException("Datos vacios.");
            Usuario? usuario = GetByEmail(entity.Email.Value);
            if (usuario != null)
                throw new UsuarioException("El usuario o mail ya esta registrado!");
            if (GetByCI(entity.CI) != null)
                throw new UsuarioException("Ya existe un usuario con esa cedula de identidad.");
            _context.Usuarios.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Usuario entity)
        {
            if (entity == null)
                throw new ArgumentNullException("Datos vacios.");
            Usuario? usuario = GetById(entity.Id) ?? throw new UsuarioException("El usuario a eliminar no existe.");
            _context.Usuarios.Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<Usuario> GetAll()
        {
            return _context.Usuarios;
        }

        public Usuario? GetByEmail(string email)
        {
            return _context.Usuarios.FirstOrDefault(user => user.Email.Value == email);
        }

        public Usuario? GetById(int id)
        {
            return _context.Usuarios.Find(id);
        }

        public void Update(Usuario entity)
        {
            if (entity == null)
                throw new ArgumentNullException("Datos vacios, no se puede actualizar los cambios.");
            Usuario? usuario = GetById(entity.Id) ?? throw new UsuarioException("El usuario no esta registrado.");
            if (usuario.Id != entity.Id && usuario.Email.Value == entity.Email.Value)
                throw new UsuarioException("Ya existe un usuario con ese email.");
            _context.Entry(usuario).State = EntityState.Detached;                                                                                                                                                                                                                                                                                                                                       
            _context.Usuarios.Update(entity);
            _context.SaveChanges();
        }
        public IEnumerable<Usuario> GetByRol(int rolId)
        {
            return _context.Usuarios.Where(user => user.Rol.Id == rolId);
        }
        private Usuario? GetByCI(string ci)
        {
            return _context.Usuarios.FirstOrDefault(user => user.CI == ci);
        }

        public Usuario? Login(string email, string password)
        {
            return _context.Usuarios.Where(u => u.Email.Value.Equals(email) && u.Password.Value.Equals(password)).SingleOrDefault();
        }
    }                                                                                                                                                                                                                                
}
