namespace MVC.Helpers.Interface
{
    public interface IConexion
    {
        (bool IsSuccessStatusCode, string datos) Start(string url, string metodo);
        (bool IsSuccessStatusCode, string datos) Start(string url, string metodo, object body);
        (bool IsSuccessStatusCode, string datos) Start(string url, string metodo, string token);
        (bool IsSuccessStatusCode, string datos) Start(string url, string metodo, string token, object body);
    }
}
