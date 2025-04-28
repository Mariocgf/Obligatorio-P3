using Compartido.DTOs.Envio;
using LogicaAplicacion.InterfacesCasosUso.AgenciaCU;
using LogicaAplicacion.InterfacesCasosUso.EnvioCU;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC.Helpers;
using MVC.Models;
using MVC.Models.Envio;
using MVC.Filter;
using LogicaAplicacion.InterfacesCasosUso.UsuarioCU;

namespace MVC.Controllers
{
    public class EnvioController : Controller
    {
        private readonly IAltaEnvioUrgente _altaEnvioUrgente;
        private readonly IAltaEnvioComun _altaEnvioComun;
        private readonly IListarSAgencia _listarSAgencia;
        private readonly IListarEnvios _listarEnvios;
        private readonly IListarSelectUsuario _listarSUsuario;
        public EnvioController(IAltaEnvioUrgente altaEnvioUrgente, IAltaEnvioComun altaEnvioComun,
                               IListarSAgencia listarSAgencia, IListarEnvios listarEnvios,
                               IListarSelectUsuario listarSUsuario)
        {
            _altaEnvioUrgente = altaEnvioUrgente;
            _altaEnvioComun = altaEnvioComun;
            _listarSAgencia = listarSAgencia;
            _listarEnvios = listarEnvios;
            _listarSUsuario = listarSUsuario;
        }
        // GET: EnvioController
        [Funcionarios]
        [IsAuthenticated]
        public ActionResult Index()
        {
            List<EnvioListadoViewModel> enviosVM = new List<EnvioListadoViewModel>();
            try
            {
                List<EnvioListadoDTO> envios = _listarEnvios.Ejecutar();
                enviosVM = envios.Select(e => new EnvioListadoViewModel
                {
                    Id = e.Id,
                    NroTracking = e.NroTracking,
                    Empleado = e.Empleado,
                    Cliente = e.Cliente,
                    Peso = e.Peso,
                    Estado = e.Estado,
                    TipoEnvio = e.TipoEnvio,
                }).ToList();
            }
            catch (Exception ex)
            {
                ViewBag.Msg = ex.Message;
            }
            return View(enviosVM);
        }

        // GET: EnvioController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        [Funcionarios]
        [IsAuthenticated]
        // GET: EnvioController/Create
        public ActionResult Create()
        {
            EnvioCreateViewModel envioVM = new EnvioCreateViewModel();
            try
            {
                CargarDatos.AgenciaSelect(envioVM, _listarSAgencia);
                CargarDatos.UsuarioSelect(envioVM, _listarSUsuario);
            }
            catch (Exception)
            {

                ViewBag.Msg = "Error al cargar las agencias";
            }
            return View(envioVM);
        }

        // POST: EnvioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Funcionarios]
        [IsAuthenticated]
        public ActionResult Create(EnvioCreateViewModel envioVM)
        {

            try
            {
                CargarDatos.AgenciaSelect(envioVM, _listarSAgencia);
                CargarDatos.UsuarioSelect(envioVM, _listarSUsuario);
                if (!ModelState.IsValid)
                    throw new ArgumentException("Datos invalidos");
                int idFuncionario = HttpContext.Session.GetInt32("Id").Value;
                if (envioVM.EsUrgente)
                {
                    EnvioUrgenteDTO envioUDto = new EnvioUrgenteDTO
                    {
                        EsUrgente = envioVM.EsUrgente,
                        ClienteId = envioVM.EmailCliente,
                        DireccionPostal = envioVM.DireccionPostal,
                        Peso = envioVM.Peso
                    };
                    _altaEnvioUrgente.Ejecutar(envioUDto, idFuncionario);
                }
                else
                {
                    EnvioComunDTO envioCDto = new EnvioComunDTO
                    {
                        AgenciaId = envioVM.AgenciaId,
                        ClienteId = envioVM.EmailCliente,
                        Peso = envioVM.Peso
                    };
                    _altaEnvioComun.Ejecutar(envioCDto, idFuncionario);
                }
                return RedirectToAction(nameof(Index));
            }
            catch (ArgumentException ex)
            {
                ViewBag.Msg = ex.Message;
            }
            catch (Exception ex)
            {
                ViewBag.Msg = ex.Message;
            }
            return View(envioVM);
        }

        // GET: EnvioController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EnvioController/Edit/5
        [HttpPost]
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

        // GET: EnvioController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EnvioController/Delete/5
        [HttpPost]
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
