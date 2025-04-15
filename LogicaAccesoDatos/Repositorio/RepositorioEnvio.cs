using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.Repositorio
{
    public class RepositorioEnvio : IRepositorioEnvio
    {
        private readonly Context _context;
        public RepositorioEnvio(Context context)
        {
            _context = context;
        }
        public void Add(Envio entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Envio entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Envio> GetAll()
        {
            return _context.Envios;
        }

        public Envio? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Envio entity)
        {
            throw new NotImplementedException();
        }
    }
}
