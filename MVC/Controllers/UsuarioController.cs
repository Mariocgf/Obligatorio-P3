using Compartido.DTOs;
using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio.ExepcionesEntidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC.Filter;
using MVC.Models.Funcionario;
using MVC.Models.Usuario;

namespace MVC.Controllers
{
    public class UsuarioController : Controller
    {
        private IUsuarioLogin _usuarioLogin { get; set; }
        private IAltaFuncionario _altaFuncionario { get; set; }
        private IListarFuncionarios _listarFuncionarios { get; set; }
        private IDetalleFuncionario _detalleFuncionario { get; set; }
        public UsuarioController(IUsuarioLogin usuarioLogin, IAltaFuncionario altaFuncionario, IListarFuncionarios listarFuncionarios, IDetalleFuncionario detalleFuncionario)
        {
            _usuarioLogin = usuarioLogin;
            _altaFuncionario = altaFuncionario;
            _listarFuncionarios = listarFuncionarios;
            _detalleFuncionario = detalleFuncionario;
        }
        // GET: UsuarioController
        [Admin]
        public ActionResult Index()
        {
            List<FuncionarioListarViewModel> listaFuncionarioVM = new List<FuncionarioListarViewModel>();
            List<FuncionarioListarDTO> listaFuncionarioDTO = _listarFuncionarios.Ejecutar();
            try
            {
                listaFuncionarioVM = listaFuncionarioDTO.Select(f => new FuncionarioListarViewModel()
                {
                    Id = f.Id,
                    Nombre = f.Nombre,
                    Apellido = f.Apellido,
                    CI = f.CI,
                    Email = f.Email
                }).ToList();
            }
            catch (Exception ex)
            {
                ViewBag.Msg = ex.Message;
            }
            return View(listaFuncionarioVM);
        }

        // GET: UsuarioController/Details/5
        [Admin]
        public ActionResult Details(int id)
        {
            FuncionarioDetailViewModel funcionarioVM = new FuncionarioDetailViewModel();
            try
            {
                FuncionarioDetailDTO funcionarioDetailDTO = _detalleFuncionario.Ejecutar(id);
                funcionarioVM = new FuncionarioDetailViewModel()
                {
                    Id = funcionarioDetailDTO.Id,
                    Nombre = funcionarioDetailDTO.Nombre,
                    Apellido = funcionarioDetailDTO.Apellido,
                    CI = funcionarioDetailDTO.CI,
                    Celular = funcionarioDetailDTO.Celular,
                    Email = funcionarioDetailDTO.Email
                };
            }
            catch (UsuarioException ex)
            {
                ViewBag.Msg = ex.Message;
            }
            catch (ArgumentNullException ex)
            {
                ViewBag.Msg = ex.Message;
            }
            catch (Exception ex)
            {
                ViewBag.Msg = "Error inesperado.";
            }
            return View(funcionarioVM);
        }
        // GET: UsuarioController/Login
        [IsAuthenticated]
        public ActionResult Login()
        {
            return View();
        }

        // POST: UsuarioController/Login
        [HttpPost]
        [IsAuthenticated]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UsuarioLoginViewModel usuarioLoginVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsuarioLoggedDTO usuario = _usuarioLogin.Login(usuarioLoginVM.Email, usuarioLoginVM.Password);
                    HttpContext.Session.SetString("Usuario", usuario.Nombre);
                    HttpContext.Session.SetString("Apellido", usuario.Apellido);
                    HttpContext.Session.SetString("Email", usuario.Email);
                    HttpContext.Session.SetString("Rol", usuario.Rol);
                }

                return Redirect("/");
            }
            catch (UsuarioException ex)
            {
                ViewBag.Msg = ex.Message;
            }
            return View();
        }

        // GET: UsuarioController/Create
        [Admin]
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsuarioController/Create
        [HttpPost]
        [Admin]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FuncionarioViewModel funcionarioVM)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new ArgumentException("Datos invalidos.");

                FuncionarioDTO funcionarioDTO = new FuncionarioDTO()
                {
                    Nombre = funcionarioVM.Nombre,
                    Apellido = funcionarioVM.Apellido,
                    CI = funcionarioVM.CI,
                    Celular = funcionarioVM.Celular,
                    Email = funcionarioVM.Email,
                    Password = funcionarioVM.Password,
                };
                _altaFuncionario.Ejecutar(funcionarioDTO);
                return RedirectToAction(nameof(Index));
            }
            catch (UsuarioException ex)
            {
                ViewBag.Msg = ex.Message;
            }
            catch (ArgumentException ex)
            {
                ViewBag.Msg = ex.Message;
            }
            catch (Exception ex)
            {
                ViewBag.Msg = "Error inesperado.";
            }
            return View();
        }

        // GET: UsuarioController/Edit/5
        [Admin]
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UsuarioController/Edit/5
        [HttpPost]
        [Admin]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuarioController/Delete/5
        [Admin]
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UsuarioController/Delete/5
        [HttpPost]
        [Admin]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
