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
    public class ObtenerSeguimientos : IObtenerSeguimientos
    {
        private readonly IRepositorioEnvio _repoEnvio;
        public ObtenerSeguimientos(IRepositorioEnvio repoEnvio)
        {
            _repoEnvio = repoEnvio;
        }
        public List<SeguimientoEnvioDto> Ejecutar(int idEnvio)
        {
            if(idEnvio <= 0)
                throw new ArgumentException("El ID de envío debe ser válido.");
            IEnumerable<Envio> envios = _repoEnvio.GetSeguimientos(idEnvio);
            return EnvioMapper.EnviosToSeguimientoEnvioDto(envios);
        }
    }
}
