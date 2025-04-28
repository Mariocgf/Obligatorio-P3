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
    public class AltaEnvioUrgente : IAltaEnvioUrgente
    {
        private readonly IRepositorioEnvioUrgente _repoEnvioUrgente;
        private readonly IRepositorioUsuario _repoUsuario;
        public AltaEnvioUrgente(IRepositorioEnvioUrgente repoEnvioUrgente,
                         IRepositorioUsuario repoUsuario)
        {
            _repoEnvioUrgente = repoEnvioUrgente;
            _repoUsuario = repoUsuario;
        }
        public void Ejecutar(EnvioUrgenteDTO envioDTO, int idFuncionario)
        {
            ArgumentNullException.ThrowIfNull(envioDTO);
            Usuario cliente = _repoUsuario.GetById(envioDTO.ClienteId) ?? throw new UsuarioException("Cliente no registrado.");
            Usuario funcionario = _repoUsuario.GetById(idFuncionario) ?? throw new UsuarioException("Funcionario no registrado.");
            Urgente envioUrgente = EnvioMapper.UrgenteFromEnvioDTO(envioDTO, cliente, funcionario);
            _repoEnvioUrgente.Add(envioUrgente);
        }
    }
}
