using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.Repositorio
{
    public class RepositorioAgencia : IRepositorioAgencia
    {
        private readonly Context _context;
        public RepositorioAgencia(Context context)
        {
            _context = context;
        }
        public void Add(Agencia entity)
        {
            if (entity == null)
                throw new ArgumentNullException("Los datos de la agencia son nulos");
            _context.Agencias.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Agencia entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Agencia> GetAll()
        {
            return _context.Agencias;
        }

        public Agencia? GetById(int id)
        {
            return _context.Agencias.Find(id);
        }

        public void Update(Agencia entity)
        {
            throw new NotImplementedException();
        }
    }
}
