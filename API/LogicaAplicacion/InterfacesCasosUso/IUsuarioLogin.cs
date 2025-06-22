using Compartido.DTOs;
namespace LogicaAplicacion.InterfacesCasosUso
{
    public interface IUsuarioLogin
    {
        UsuarioLoggedDTO Login(LoginDTO loginDto);
    }
}
