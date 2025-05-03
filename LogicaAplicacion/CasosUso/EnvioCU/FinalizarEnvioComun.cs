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
    public class FinalizarEnvioComun : IFinalizarEnvioComun
    {
        private readonly IRepositorioEnvioComun _repoEnvio;
        public FinalizarEnvioComun(IRepositorioEnvioComun repoEnvio)
        {
            _repoEnvio = repoEnvio;
        }
        public void Ejecutar(EnvioUpdateDTO envioDto)
        {
            ArgumentNullException.ThrowIfNull(envioDto);
            
        }
    }
}
