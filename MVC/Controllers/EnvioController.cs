using Microsoft.AspNetCore.Mvc;
using MVC.Filter;
using MVC.Helpers.Interface;
using MVC.Models.Envio;
using Newtonsoft.Json;

namespace MVC.Controllers
{
    [IsAuthenticated]
    public class EnvioController : Controller
    {
        private readonly IConexion _conexion;
        public EnvioController(IConexion conexion)
        {
            _conexion = conexion;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<EnvioListadoViewModel> enviosVM = new List<EnvioListadoViewModel>();
            try
            {
                int idUser = (int)HttpContext.Session.GetInt32("Id");
                string token = HttpContext.Session.GetString("Token");
                var (IsSuccessStatusCode, datos) = _conexion.Start($"envio/usuario/{idUser}", "GET", token);
                if (IsSuccessStatusCode)
                {
                    enviosVM = JsonConvert.DeserializeObject<List<EnvioListadoViewModel>>(datos);
                }
                else
                {
                    ViewBag.Msg = datos;
                }
            }
            catch (Exception)
            {
                ViewBag.Msg = "Error al obtener los envíos.";
            }
            return View(enviosVM);
        }
        [HttpGet]
        public IActionResult Seguimientos(int idEnvio)
        {
            List<SeguimientoEnvioViewModel> seguimientosVM = new List<SeguimientoEnvioViewModel>();
            try
            {
                if (idEnvio > 0)
                {
                    string token = HttpContext.Session.GetString("Token");
                    var (IsSuccessStatusCode, datos) = _conexion.Start($"envio/seguimientos/{idEnvio}", "GET", token);
                    if (IsSuccessStatusCode)
                    {
                        seguimientosVM = JsonConvert.DeserializeObject<List<SeguimientoEnvioViewModel>>(datos);
                    }
                }
            }
            catch (Exception)
            {
                ViewBag.Msg = "Error.";
            }
            return View(seguimientosVM);
        }
        [HttpGet]
        public IActionResult Buscar()
        {
            List<EnvioListadoViewModel> enviosVM = new List<EnvioListadoViewModel>();
            return View(enviosVM);
        }
        [HttpPost]
        public IActionResult BuscarXFecha(BuscarEnvioFechaViewModel vm)
        {
            List<EnvioListadoViewModel> enviosVM = new List<EnvioListadoViewModel>();
            try
            {
                vm.IdUser = (int)HttpContext.Session.GetInt32("Id");
                string token = HttpContext.Session.GetString("Token");

                if (ModelState.IsValid)
                {
                    string query = query = $"?IdUser={vm.IdUser}&FechaDesde={vm.FechaDesde.ToString("yyyy-MM-dd")}&FechaHasta={vm.FechaHasta.ToString("yyyy-MM-dd")}&Estado={vm.Estado}";
                    var (IsSuccessStatusCode, datos) = _conexion.Start($"envio/fecha{query}", "GET", token);
                    if (IsSuccessStatusCode)
                        enviosVM = JsonConvert.DeserializeObject<List<EnvioListadoViewModel>>(datos);
                    else
                        ViewBag.Msg = datos;
                }
                else
                    ViewBag.Msg = "Por favor, complete todos los campos requeridos.";
            }
            catch (Exception)
            {
                ViewBag.Msg = "Error.";
            }
            return View("Buscar", enviosVM);
        }
        [HttpPost]
        public IActionResult BuscarXComentario(BuscarEnvioComentarioViewModel vm)
        {
            List<EnvioListadoViewModel> enviosVM = new List<EnvioListadoViewModel>();
            try
            {
                vm.IdUser = (int)HttpContext.Session.GetInt32("Id");
                string token = HttpContext.Session.GetString("Token");
                if (ModelState.IsValid)
                {
                    string query = $"?IdUser={vm.IdUser}&Comentario={vm.Comentario}";
                    var (IsSuccessStatusCode, datos) = _conexion.Start($"envio/comentario{query}", "GET", token);
                    if (IsSuccessStatusCode)
                        enviosVM = JsonConvert.DeserializeObject<List<EnvioListadoViewModel>>(datos);
                    else
                        ViewBag.Msg = datos;
                }
                else
                    ViewBag.Msg = "Por favor, complete todos los campos requeridos.";
            }
            catch (Exception)
            {
                ViewBag.Msg = "Error.";
            }
            return View("Buscar",enviosVM);
        }
    }
}
