using LogicaAplicacion.InterfacesCasosUso.EnvioCU;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorio;
using LogicaNegocio.ExepcionesEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.EnvioCU
{
    public class AgregarComentario : IAgregarComentario
    {
        private readonly IRepositorioEnvio _repoEnvio;
        private readonly IRepositorioUsuario _repoUsuario;
        public AgregarComentario(IRepositorioEnvio repoEnvio, IRepositorioUsuario repoUsuario)
        {
            _repoEnvio = repoEnvio;
            _repoUsuario = repoUsuario;
        }
        void IAgregarComentario.Ejecutar(int idEnvio, int idEmpleado, string comentario)
        {
            Usuario usuario = _repoUsuario.GetById(idEmpleado) ?? throw new UsuarioException();
            Envio envio = _repoEnvio.GetById(idEnvio) ?? throw new EnvioException();
            if (envio.Estado == Estados.FINALIZADO)
                throw new EnvioException("No se puede agregar un comentario a un envio finalizado");
            List<Seguimiento> seguimientos = envio.ListaSeguimiento;
            seguimientos.Add(new Seguimiento(comentario, usuario));
            _repoEnvio.Update(envio);
        }
    }
}
