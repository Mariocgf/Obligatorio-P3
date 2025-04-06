using Compartido.DTOs;
namespace LogicaAplicacion.InterfacesCasosUso
{
    public interface IUsuarioLogin
    {
        UsuarioLoggedDTO Login(string username, string password);
    }
}
