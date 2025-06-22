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
            return _context.Envios.Where(e => e.Id == id).Include(e => e.Cliente).Include(e => e.Empleado).Include(e => e.ListaSeguimiento).SingleOrDefault();
        }

        public void Update(Envio entity)
        {
            ArgumentNullException.ThrowIfNull(entity);
            Envio envio = GetById(entity.Id) ?? throw new EnvioException("El envio a actualizar no existe.");
            _context.Entry(envio).State = EntityState.Detached;
            _context.Envios.Update(entity);
            _context.SaveChanges();
        }

        public Envio? GetByNroTracking(string nroTracking)
        {
            return _context.Envios.Include(e => e.Cliente).Include(e => e.Empleado).Include(e => e.ListaSeguimiento).FirstOrDefault(e => e.NroTracking.Trim() == nroTracking.Trim());
        }

        public IEnumerable<Envio> GetByUsuario(int id)
        {
            return _context.Envios.Where(e => e.Cliente.Id == id).Include(e => e.ListaSeguimiento).OrderByDescending(e => e.FechaCreacion);
        }

        public IEnumerable<Envio> GetByFechaUsuario(int id, DateTime fechaDesde, DateTime fechaHasta, int estado)
        {
            IEnumerable<Envio> envios = new List<Envio>();
            if (estado != -1)
                envios = _context.Envios.Where(e => e.FechaCreacion >= fechaDesde && e.FechaCreacion <= fechaHasta && e.Cliente.Id == id && (int)e.Estado == estado);
            else
                envios = _context.Envios.Where(e => e.FechaCreacion >= fechaDesde && e.FechaCreacion <= fechaHasta && e.Cliente.Id == id);
            return envios.OrderBy(e => e.NroTracking);
        }
        public IEnumerable<Envio> GetByComentario(string comentario, int idUser)
        {
            return _context.Envios.Include(e => e.ListaSeguimiento).Where(e => e.ListaSeguimiento.Any(s => s.Comentario.ToUpper().Contains(comentario)) && e.Cliente.Id == idUser).OrderByDescending(e => e.FechaCreacion);
        }
        public IEnumerable<Envio> GetSeguimientos(int idEnvio) { return _context.Envios.Where(e => e.Id == idEnvio).Include(e => e.ListaSeguimiento); }
    }
}
