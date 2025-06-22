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
    public class BuscarEnvioXFechaUsuario : IBuscarEnvioXFechaUsuario
    {
        private readonly IRepositorioEnvio _repoEnvio;
        public BuscarEnvioXFechaUsuario(IRepositorioEnvio repoEnvio)
        {
            _repoEnvio = repoEnvio;
        }
        public List<EnvioUsuarioDto> Ejecutar(EnvioXFechaDto dto)
        {
            if(dto.IdUser <= 0)
                throw new ArgumentException("El ID del usuario debe ser mayor a 0.");
            if (dto.FechaDesde > dto.FechaHasta)
                throw new ArgumentException("La fecha de inicio no puede ser mayor que la fecha de fin.");

            IEnumerable<Envio> envios = _repoEnvio.GetByFechaUsuario(dto.IdUser, dto.FechaDesde, dto.FechaHasta, dto.Estado);
            List<EnvioUsuarioDto> enviosDto = EnvioMapper.EnviosTOEnvioUsuarioDto(envios);
            return enviosDto;
        }
    }
}
