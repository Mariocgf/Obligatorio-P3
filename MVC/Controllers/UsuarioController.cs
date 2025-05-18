using Compartido.DTOs;
using Compartido.DTOs.Funcionario;
using LogicaAplicacion.InterfacesCasosUso;
using LogicaAplicacion.InterfacesCasosUso.FuncionarioCU;
using LogicaNegocio.ExepcionesEntidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC.Filter;
using MVC.Helpers;
using MVC.Models.Funcionario;
using MVC.Models.Rol;
using MVC.Models.Usuario;

namespace MVC.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioLogin _usuarioLogin;
        private readonly IAltaFuncionario _altaFuncionario;
        private readonly IListarFuncionarios _listarFuncionarios;
        private readonly IDetalleFuncionario _detalleFuncionario;
        private readonly IListarRoles _listarRoles;
        private readonly IUpdateFuncionario _updateFuncionario;
        private readonly IDetalleUpdateFuncionario _detalleUpdateFuncionario;
        private readonly IEliminarFuncionario _eliminarFuncionario;
        public UsuarioController(IUsuarioLogin usuarioLogin,
                                 IAltaFuncionario altaFuncionario,
                                 IListarFuncionarios listarFuncionarios,
                                 IDetalleFuncionario detalleFuncionario,
                                 IListarRoles listarRoles,
                                 IUpdateFuncionario updateFuncionario,
                                 IDetalleUpdateFuncionario detalleUpdateFuncionario,
                                 IEliminarFuncionario eliminarFuncionario)
        {
            _usuarioLogin = usuarioLogin;
            _altaFuncionario = altaFuncionario;
            _listarFuncionarios = listarFuncionarios;
            _detalleFuncionario = detalleFuncionario;
            _listarRoles = listarRoles;
            _updateFuncionario = updateFuncionario;
            _detalleUpdateFuncionario = detalleUpdateFuncionario;
            _eliminarFuncionario = eliminarFuncionario;
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
                    Email = f.Email,
                    Rol = f.Rol
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
                    UsuarioLoggedDTO usuario = _usuarioLogin.Login(usuarioLoginVM.Email, usuarioLoginVM.Password);
                    HttpContext.Session.SetInt32("Id", usuario.Id);
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
        // GET: UsuarioController/Logout
        [HttpGet]
        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        // GET: UsuarioController/Create
        [Admin]
        public ActionResult Create()
        {
            FuncionarioViewModel funcionarioVM = new FuncionarioViewModel();
            CargarRoles(funcionarioVM);
            return View(funcionarioVM);
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
                    RolId = funcionarioVM.RolId
                };
                int idUsuario = HttpContext.Session.GetInt32("Id").Value;
                _altaFuncionario.Ejecutar(funcionarioDTO, idUsuario);
                return RedirectToAction(nameof(Index));
            }
            catch (UsuarioException ex)
            {
                ViewBag.Msg = ex.Message;
            }
            catch (RolException ex)
            {
                ViewBag.Msg = ex.Message;
            }
            catch (ArgumentException ex)
            {
                ViewBag.Msg = ex.Message;
            }
            catch (Exception ex)
            {
                ViewBag.Msg = "Ups, acaba de ocurrir un error inesperado.";
            }
            CargarRoles(funcionarioVM);
            return View(funcionarioVM);
        }
        private void CargarRoles(FuncionarioViewModel funcionarioVM)
        {
            try
            {
                List<InfoSelectDTO> listaRolDTO = _listarRoles.Ejecutar();
                funcionarioVM.Roles = listaRolDTO.Select(r => new RolViewModel()
                {
                    Id = r.Id,
                    Nombre = r.Nombre
                }).ToList();
            }
            catch (Exception ex)
            {
                ViewBag.Msg = ex.Message;
            }
        }

        // GET: UsuarioController/Edit/5
        [Admin]
        public ActionResult Edit(int id)
        {
            FuncionarioUpdateViewModel funcionarioUpdateViewModel = new FuncionarioUpdateViewModel();
            try
            {
                CargarDatos.RolesSelect(funcionarioUpdateViewModel, _listarRoles);
                FuncionarioUpdateDTO funcionarioDTO = _detalleUpdateFuncionario.Ejecutar(id);
                funcionarioUpdateViewModel.Id = funcionarioDTO.Id;
                funcionarioUpdateViewModel.Nombre = funcionarioDTO.Nombre;
                funcionarioUpdateViewModel.Apellido = funcionarioDTO.Apellido;
                funcionarioUpdateViewModel.CI = funcionarioDTO.CI;
                funcionarioUpdateViewModel.Celular = funcionarioDTO.Celular;
                funcionarioUpdateViewModel.Email = funcionarioDTO.Email;
                funcionarioUpdateViewModel.Password = funcionarioDTO.Password;
                funcionarioUpdateViewModel.RolId = funcionarioDTO.RolId;
            }
            catch (UsuarioException ex)
            {
                ViewBag.Msg = ex.Message;
            }
            return View(funcionarioUpdateViewModel);
        }

        // POST: UsuarioController/Edit/5
        [HttpPost]
        [Admin]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FuncionarioUpdateViewModel funcionarioUpdateViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new ArgumentException("Datos invalidos.");
                FuncionarioUpdateDTO funcionarioDTO = new FuncionarioUpdateDTO()
                {
                    Id = funcionarioUpdateViewModel.Id,
                    Nombre = funcionarioUpdateViewModel.Nombre,
                    Apellido = funcionarioUpdateViewModel.Apellido,
                    CI = funcionarioUpdateViewModel.CI,
                    Celular = funcionarioUpdateViewModel.Celular,
                    Email = funcionarioUpdateViewModel.Email,
                    Password = funcionarioUpdateViewModel.Password,
                    RolId = funcionarioUpdateViewModel.RolId
                };
                int idAdmin = HttpContext.Session.GetInt32("Id").Value;
                _updateFuncionario.Ejecutar(funcionarioDTO, idAdmin);
                return RedirectToAction(nameof(Index));
            }
            catch (UsuarioException ex)
            {
                ViewBag.Msg = ex.Message;
            }
            catch (RolException ex)
            {
                ViewBag.Msg = ex.Message;
            }
            catch (ArgumentException ex)
            {
                ViewBag.Msg = ex.Message;
            }
            catch (Exception ex)
            {
                ViewBag.Msg = "Ups, acaba de ocurrir un error inesperado.";
            }
            CargarDatos.RolesSelect(funcionarioUpdateViewModel, _listarRoles);
            return View(funcionarioUpdateViewModel);
        }

        // GET: UsuarioController/Delete/5
        [Admin]
        public ActionResult Delete(int id)
        {
            try
            {
                FuncionarioDetailDTO funcionarioDetailDTO = _detalleFuncionario.Ejecutar(id);
                FuncionarioDetailViewModel funcionarioVM = new FuncionarioDetailViewModel()
                {
                    Id = funcionarioDetailDTO.Id,
                    Nombre = funcionarioDetailDTO.Nombre,
                    Apellido = funcionarioDetailDTO.Apellido,
                    CI = funcionarioDetailDTO.CI,
                    Celular = funcionarioDetailDTO.Celular,
                    Email = funcionarioDetailDTO.Email
                };
                return View(funcionarioVM);
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
            return View(new FuncionarioDetailViewModel());
        }

        // POST: UsuarioController/Delete/5
        [HttpPost]
        [Admin]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FuncionarioDetailViewModel funcionarioDetailVM)
        {
            try
            {
                int idAdmin = HttpContext.Session.GetInt32("Id").Value;
                _eliminarFuncionario.Ejecutar(id, idAdmin);
                return RedirectToAction(nameof(Index));
            }
            catch (UsuarioException ex)
            {
                ViewBag.Msg = ex.Message;
            }
            catch(Exception ex)
            {
                ViewBag.Msg = "Error inesperado.";
            }
            return View();
        }
    }
}
