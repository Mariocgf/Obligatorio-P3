using LogicaNegocio.Entidades;

namespace LogicaNegocio.InterfacesRepositorio
{
    public interface IRepositorioEnvio : IRepositorio<Envio>
    {
        Envio? GetByNroTracking(string nroTracking);
    }
}
