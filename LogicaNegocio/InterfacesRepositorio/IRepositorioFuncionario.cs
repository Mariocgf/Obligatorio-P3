using LogicaNegocio.Entidades;

namespace LogicaNegocio.InterfacesRepositorio
{
    public interface IRepositorioFuncionario : IRepositorio<Usuario>
    {
        IEnumerable<Usuario> GetByFuncionario(int rolId);
    }
}
