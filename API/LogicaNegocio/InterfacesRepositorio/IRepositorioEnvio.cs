using LogicaNegocio.Entidades;

namespace LogicaNegocio.InterfacesRepositorio
{
    public interface IRepositorioEnvio : IRepositorio<Envio>
    {
        Envio? GetByNroTracking(string nroTracking);
        IEnumerable<Envio> GetByUsuario(int id);
        IEnumerable<Envio> GetByFechaUsuario(int id, DateTime fechaDesde, DateTime fechaHasta, int estado);
        IEnumerable<Envio> GetByComentario(string comentario, int idUser);
        IEnumerable<Envio> GetSeguimientos(int idEnvio);
    }
}
