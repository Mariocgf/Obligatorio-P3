using Compartido.DTOs.Envio;
using LogicaAplicacion.InterfacesCasosUso.EnvioCU;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorio;
using LogicaNegocio.ExepcionesEntidades;
using Compartido.Mappers;

namespace LogicaAplicacion.CasosUso.EnvioCU
{
    public class DetalleEnvio : IDetalleEnvio
    {
        private readonly IRepositorioEnvio _repositorioEnvio;
        public DetalleEnvio(IRepositorioEnvio repositorioEnvio)
        {
            _repositorioEnvio = repositorioEnvio;
        }
        public EnvioDetalleDto Ejecutar(int id)
        {
            Envio envio = _repositorioEnvio.GetById(id) ?? throw new EnvioException();
            return EnvioMapper.EnvioTOEnvioDetalleDTO(envio);
        }
    }
}
