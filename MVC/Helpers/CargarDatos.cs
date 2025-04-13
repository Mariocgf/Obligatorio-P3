using Compartido.DTOs;
using Compartido.DTOs.Agencia;
using LogicaAplicacion.InterfacesCasosUso;
using LogicaAplicacion.InterfacesCasosUso.AgenciaCU;
using MVC.Models;
using MVC.Models.Agencia;
using MVC.Models.Funcionario;
using MVC.Models.Rol;

namespace MVC.Helpers
{
    public class CargarDatos
    {
        public static void RolesSelect(FuncionarioViewModel funcionarioVM, IListarRoles listaRoles)
        {
            List<RolDetallesDTO> listaRolDTO = listaRoles.Ejecutar();
            funcionarioVM.Roles = listaRolDTO.Select(r => new RolViewModel()
            {
                Id = r.Id,
                Nombre = r.Nombre
            }).ToList();
        }
        public static void RolesSelect(FuncionarioUpdateViewModel funcionarioVM, IListarRoles listaRoles)
        {
            List<RolDetallesDTO> listaRolDTO = listaRoles.Ejecutar();
            funcionarioVM.Roles = listaRolDTO.Select(r => new RolViewModel()
            {
                Id = r.Id,
                Nombre = r.Nombre
            }).ToList();
        }
        public static void AgenciaSelect(EnvioCreateViewModel envioVM, IListarSAgencia listaSAgencia)
        {
            List<AgenciaSelectDTO> listaAgenciaDTO = listaSAgencia.Ejecutar();
            envioVM.Agencias = listaAgenciaDTO.Select(r => new AgenciaSelectViewModel()
            {
                Id = r.Id,
                Nombre = r.Nombre
            }).ToList();
        }
    }
}
