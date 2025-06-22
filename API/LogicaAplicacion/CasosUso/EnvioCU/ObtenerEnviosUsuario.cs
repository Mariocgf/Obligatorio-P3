using Compartido.DTOs.Envio;
using Compartido.Mappers;
using LogicaAplicacion.InterfacesCasosUso.EnvioCU;
using LogicaNegocio.Entidades;
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
        public ObtenerEnviosUsuario(IRepositorioEnvio repoEnvio)
        {
            _repoEnvio = repoEnvio;
        }

        public List<EnvioUsuarioDto> Ejecutar(int id)
        {
            IEnumerable<Envio> envios = _repoEnvio.GetByUsuario(id);
            List<EnvioUsuarioDto> enviosDto = EnvioMapper.EnviosTOEnvioUsuarioDto(envios);
            return enviosDto;
        }
    }
}
