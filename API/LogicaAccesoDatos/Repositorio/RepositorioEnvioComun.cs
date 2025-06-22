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
    public class RepositorioEnvioComun : IRepositorioEnvioComun
    {
        private readonly Context _context;
        public RepositorioEnvioComun(Context context)
        {
            _context = context;
        }

        public void Add(Comun entity)
        {
            if (entity == null)
                throw new ArgumentNullException("Los datos del envio son nulos");
            _context.EnvioComun.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Comun entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Comun> GetAll()
        {
            throw new NotImplementedException();
        }

        public Comun? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Comun entity)
        {
            ArgumentNullException.ThrowIfNull(entity);
            Comun envio = GetById(entity.Id) ?? throw new EnvioException("El envio a actualizar no existe.");
            _context.Entry(envio).State = EntityState.Detached;
            _context.EnvioComun.Update(entity);
            _context.SaveChanges();
        }
    }
}
