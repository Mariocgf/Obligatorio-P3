using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.Repositorio
{
    public class RepositorioAuditoria : IRepositorioAuditoria
    {
        private readonly Context _context;
        public RepositorioAuditoria(Context context)
        {
            _context = context;
        }
        public void Add(Auditoria entity)
        {
            if (entity == null)
                throw new ArgumentNullException("Datos vacios.");
            _context.Auditorias.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Auditoria entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Auditoria> GetAll()
        {
            throw new NotImplementedException();
        }

        public Auditoria? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Auditoria entity)
        {
            throw new NotImplementedException();
        }
    }
}
