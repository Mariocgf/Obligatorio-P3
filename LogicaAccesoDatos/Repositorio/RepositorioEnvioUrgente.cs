using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.Repositorio
{
    public class RepositorioEnvioUrgente : IRepositorioEnvioUrgente
    {
        private readonly Context _context;
        public RepositorioEnvioUrgente(Context context)
        {
            _context = context;
        }
        public void Add(Urgente entity)
        {
            if(entity == null)
                throw new ArgumentNullException("Los datos del envio son nulos");
            _context.EnvioUrgente.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Urgente entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Urgente> GetAll()
        {
            throw new NotImplementedException();
        }

        public Urgente? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Urgente entity)
        {
            throw new NotImplementedException();
        }
    }
}
