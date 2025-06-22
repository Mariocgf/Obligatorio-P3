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
    public class ListarEnvios : IListarEnvios
    {
        private readonly IRepositorioEnvio _repoEnvio;
        private readonly IRepositorioUsuario _repoUsuario;

        public ListarEnvios(IRepositorioEnvio repositorioEnvio, IRepositorioUsuario repoUsuario)
        {
            _repoEnvio = repositorioEnvio;
            _repoUsuario = repoUsuario;
        }

        public List<EnvioListadoDTO> Ejecutar()
        {
            List<Usuario> usuarios = _repoUsuario.GetAll().ToList();
            List<Envio> envios = _repoEnvio.GetAll().ToList();
            return EnvioMapper.EnvioTOEnvioListadoDTO(envios, usuarios);
        }
    }
}
