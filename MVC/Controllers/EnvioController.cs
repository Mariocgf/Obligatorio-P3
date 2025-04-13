using Compartido.DTOs.Envio;
using LogicaAplicacion.InterfacesCasosUso.AgenciaCU;
using LogicaAplicacion.InterfacesCasosUso.EnvioCU;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC.Helpers;
using MVC.Models;

namespace MVC.Controllers
{
    public class EnvioController : Controller
    {
        private readonly IAltaEnvio _altaEnvio;
        private readonly IListarSAgencia _listarSAgencia;
        public EnvioController(IAltaEnvio altaEnvio, IListarSAgencia listarSAgencia)
        {
            _altaEnvio = altaEnvio;
            _listarSAgencia = listarSAgencia;
        }
        // GET: EnvioController
        public ActionResult Index()
        {
            return View();
        }

        // GET: EnvioController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EnvioController/Create
        public ActionResult Create()
        {
            EnvioCreateViewModel envioVM = new EnvioCreateViewModel();
            try
            {
                CargarDatos.AgenciaSelect(envioVM, _listarSAgencia);
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
        public ActionResult Create(EnvioCreateViewModel envioVM)
        {

            try
            {
                CargarDatos.AgenciaSelect(envioVM, _listarSAgencia);
                if (!ModelState.IsValid)
                    throw new ArgumentException("Datos invalidos");
                EnvioDTO envioDTO = new EnvioDTO
                {
                    EsUrgente = envioVM.EsUrgente,
                    EmailCliente = envioVM.EmailCliente,
                    AgenciaId = envioVM.AgenciaId,
                    DireccionPostal = envioVM.DireccionPostal,
                    Peso = envioVM.Peso
                };
                int idFuncionario = HttpContext.Session.GetInt32("Id").Value;
                _altaEnvio.Ejecutar(envioDTO, idFuncionario);
                return RedirectToAction(nameof(Index));
            }
            catch(ArgumentException ex)
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
