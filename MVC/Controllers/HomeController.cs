using Microsoft.AspNetCore.Mvc;
using MVC.Helpers.Interface;
using MVC.Models;
using MVC.Models.Envio;
using Newtonsoft.Json;
using System.Diagnostics;


namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConexion _conexion;

        public HomeController(ILogger<HomeController> logger, IConexion conexion)
        {
            _conexion = conexion;
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Index()
        {
            EnvioDetalleViewModel envioVM = new EnvioDetalleViewModel();
            return View(envioVM);
        }
        [HttpPost]
        public IActionResult Index(string nroTracking)
        {
            EnvioDetalleViewModel envioVM = new EnvioDetalleViewModel();
            try
            {
                if (!String.IsNullOrEmpty(nroTracking))
                {
                    var (IsSuccessStatusCode, datos) = _conexion.Start($"envio/{nroTracking}", "GET");
                    if (IsSuccessStatusCode)
                        envioVM = JsonConvert.DeserializeObject<EnvioDetalleViewModel>(datos);
                    else
                        ViewBag.Msg = datos;
                }
                else
                {
                    ViewBag.Msg = "Ingrese un numero de tracking valido.";
                }
            }
            catch (Exception)
            {
                ViewBag.Msg("Error");
            }
            return View(envioVM);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
