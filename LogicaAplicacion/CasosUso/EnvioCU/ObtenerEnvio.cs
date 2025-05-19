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
    public class ObtenerEnvio : IObtenerEnvio
    {
        private readonly IRepositorioEnvio _repoEnvio;
        public ObtenerEnvio(IRepositorioEnvio repoEnvio)
        {
            _repoEnvio = repoEnvio;
        }
        public EnvioAPInfoDto Ejecutar(string nroTracking)
        {
            if(String.IsNullOrEmpty(nroTracking))
                throw new ArgumentNullException("El numero de tracking no puede ser nulo o vacio.");
            Envio envio = _repoEnvio.GetByNroTracking(nroTracking) ?? throw new EnvioException("El envio no existe.");
            return EnvioMapper.EnvioToEnvioAPInfoDto(envio);
        }
    }
}
