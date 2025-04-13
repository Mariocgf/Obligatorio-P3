using LogicaNegocio.Entidades;

namespace LogicaNegocio.InterfacesRepositorio
{
    public interface IRepositorioRol : IRepositorio<Rol>
    {
        Rol? GetByName(string name);
    }
}
