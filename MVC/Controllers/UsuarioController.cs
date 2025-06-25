using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC.Filter;
using MVC.Helpers.Interface;
using MVC.Models.Usuario;
using Newtonsoft.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MVC.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IConexion _conexion;
        public UsuarioController(IConexion conexion)
        {
            _conexion = conexion;
        }

        // GET: UsuarioController/Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: UsuarioController/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UsuarioLoginViewModel usuarioLoginVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var (IsSuccessStatusCode, datos) = _conexion.Start("usuario/login", "POST", usuarioLoginVM);
                    if ((bool)IsSuccessStatusCode)
                    {
                        UsuarioLoggedViewModel usuario = JsonConvert.DeserializeObject<UsuarioLoggedViewModel>(datos);
                        HttpContext.Session.SetInt32("Id", usuario.Id);
                        HttpContext.Session.SetString("Usuario", usuario.Nombre);
                        HttpContext.Session.SetString("Apellido", usuario.Apellido);
                        HttpContext.Session.SetString("Email", usuario.Email);
                        HttpContext.Session.SetString("Rol", usuario.Rol);
                        HttpContext.Session.SetString("Token", usuario.Token);
                        return RedirectToAction("Index", "Envio");
                    }
                    else
                    {
                        ViewBag.Msg = datos;
                    }
                }
                else
                {
                    ViewBag.Msg = "Por favor, complete todos los campos requeridos.";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Msg = "Error";
            }
            return View();
        }
        // GET: UsuarioController/Logout
        [HttpGet]
        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
        [IsAuthenticated]
        [HttpGet]
        public IActionResult ChangePassword()
        {
            ChangePasswordViewModel chPassVM = new ChangePasswordViewModel();
            return View(chPassVM);
        }
        [IsAuthenticated]
        [HttpPost]
        public IActionResult ChangePassword(ChangePasswordViewModel chPassVM)
        {
            try
            {
                int usuarioId = (int)HttpContext.Session.GetInt32("Id");
                string token = HttpContext.Session.GetString("Token");
                if (ModelState.IsValid)
                {
                    chPassVM.Id = usuarioId;
                    var (IsSuccessStatusCode, datos) = _conexion.Start("usuario/changePassword", "PUT", token, chPassVM);
                    if (IsSuccessStatusCode)
                    {
                        ViewBag.Msg = "Contraseña cambiada correctamente.";
                        ViewBag.Success = "true";
                    }
                    else
                        ViewBag.Msg = datos;
                }
                else
                {
                    ViewBag.Msg = "Por favor, complete todos los campos requeridos.";
                }
            }
            catch (Exception)
            {
                ViewBag.Msg = "Error";
            }
            return View(chPassVM);
        }
    }
}
