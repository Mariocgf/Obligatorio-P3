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
    public class UpdateEnvio : IUpdateEnvio
    {
        private readonly IRepositorioEnvio _repoEnvio;
        public UpdateEnvio(IRepositorioEnvio repoEnvio)
        {
            _repoEnvio = repoEnvio;
        }
        public void Ejecutar(EnvioUpdateDTO envioDto)
        {
            ArgumentNullException.ThrowIfNull(envioDto);
            Envio envio = _repoEnvio.GetById(envioDto.Id) ?? throw new EnvioException("Envio no encontrado.");
            Estados estado;
            Enum.TryParse(envioDto.Estado, ignoreCase: true, out estado);
            envio.Estado = estado;
            envio.FechaEntrega = DateTime.Now;
            if (envio is Urgente envioU)
            {
                TimeSpan timeSpan = DateTime.Now - envioU.FechaCreacion;
                if (timeSpan.TotalHours < 24)
                    envioU.EntregadoEficiente = true;

                _repoEnvio.Update(envioU);
            }else
                _repoEnvio.Update(envio);

        }
    }
}
