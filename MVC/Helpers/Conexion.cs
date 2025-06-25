using MVC.Helpers.Interface;
using MVC.Models.Usuario;
using System.Runtime.Intrinsics.Arm;
using System.Security.Policy;

namespace MVC.Helpers
{
    public class Conexion : IConexion
    {
        private readonly string urlBase;
        public Conexion(IConfiguration configuration)
        {
            urlBase = configuration.GetValue<string>("UrlBase");
        }
        public (bool IsSuccessStatusCode, string datos) Start(string url, string metodo)
        {
            return Start(url, metodo, null, null);
        }
        public (bool IsSuccessStatusCode, string datos) Start(string url, string metodo, object body)
        {
            return Start(url, metodo, null, body);
        }
        public (bool IsSuccessStatusCode, string datos) Start(string url, string metodo, string token)
        {
            return Start(url, metodo, token, null);
        }
        public (bool IsSuccessStatusCode, string datos) Start(string url, string metodo, string token, object body)
        {
            string urlFinal = urlBase + url;
            HttpClient client = new HttpClient();
            if (!string.IsNullOrEmpty(token))
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            Task<HttpResponseMessage> task;
            switch (metodo.ToUpper())
            {
                case "POST":
                    task = client.PostAsJsonAsync(urlFinal, body);
                    break;
                case "PUT":
                    task = client.PutAsJsonAsync(urlFinal, body);
                    break;
                default:
                    task = client.GetAsync(urlFinal);
                    break;
            }
            task.Wait();
            HttpResponseMessage response = task.Result;
            HttpContent contenido = response.Content;
            Task<string> bodyAPI = contenido.ReadAsStringAsync();
            bodyAPI.Wait();
            string datos = bodyAPI.Result;
            return (response.IsSuccessStatusCode, datos);
        }
    }
}
