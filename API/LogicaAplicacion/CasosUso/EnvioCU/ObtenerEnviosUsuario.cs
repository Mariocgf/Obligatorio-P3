using Compartido.DTOs.Envio;
using Compartido.Mappers;
using LogicaAplicacion.InterfacesCasosUso.EnvioCU;
using LogicaNegocio.Entidades;
using LogicaNegocio.ExepcionesEntidades;
using LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.EnvioCU
{
    public class ObtenerEnviosUsuario : IObtenerEnvioUsuario
    {
        private readonly IRepositorioEnvio _repoEnvio;
        private readonly IRepositorioUsuario _repoUsuario;
        public ObtenerEnviosUsuario(IRepositorioEnvio repoEnvio, IRepositorioUsuario repoUsuario)
        {
            _repoEnvio = repoEnvio;
            _repoUsuario = repoUsuario;
        }

        public List<EnvioUsuarioDto> Ejecutar(int id)
        {
            Usuario usuario = _repoUsuario.GetById(id) ?? throw new UsuarioException("Usuario no encontrado");
            IEnumerable<Envio> envios = _repoEnvio.GetByUsuario(id);
            List<EnvioUsuarioDto> enviosDto = EnvioMapper.EnviosTOEnvioUsuarioDto(envios);
            return enviosDto;
        }
    }
}
