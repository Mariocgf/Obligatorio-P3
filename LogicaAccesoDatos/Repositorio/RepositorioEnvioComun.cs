using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorio;
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
            throw new NotImplementedException();
        }
    }
}
