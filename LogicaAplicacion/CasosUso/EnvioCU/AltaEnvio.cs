using Compartido.DTOs.Envio;
using LogicaAplicacion.InterfacesCasosUso.EnvioCU;
using LogicaNegocio.Entidades;
using LogicaNegocio.ExepcionesEntidades;
using LogicaNegocio.InterfacesRepositorio;
using Compartido.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.EnvioCU
{
    public class AltaEnvio : IAltaEnvio
    {
        private readonly IRepositorioEnvioUrgente _repoEnvioUrgente;
        private readonly IRepositorioEnvioComun _repoEnvioComun;
        private readonly IRepositorioUsuario _repoUsuario;
        private readonly IRepositorioAgencia _repoAgencia;
        public AltaEnvio(IRepositorioEnvioUrgente repoEnvioUrgente,
                         IRepositorioEnvioComun repoEnvioComun,
                         IRepositorioUsuario repoUsuario,
                         IRepositorioAgencia repoAgencia)
        {
            _repoEnvioUrgente = repoEnvioUrgente;
            _repoEnvioComun = repoEnvioComun;
            _repoUsuario = repoUsuario;
            _repoAgencia = repoAgencia;
        }
        public void Ejecutar(EnvioDTO envioDTO, int idFuncionario)
        {
            ArgumentNullException.ThrowIfNull(envioDTO);
            Usuario cliente = _repoUsuario.GetByEmail(envioDTO.EmailCliente) ?? throw new UsuarioException("Cliente no registrado.");
            Usuario funcionario = _repoUsuario.GetById(idFuncionario) ?? throw new UsuarioException("Funcionario no registrado.");
            if (envioDTO.EsUrgente)
            {
                Urgente envioUrgente = EnvioMapper.UrgenteFromEnvioDTO(envioDTO, cliente, funcionario);
                _repoEnvioUrgente.Add(envioUrgente);
            }
            else
            {
                Agencia agencia = _repoAgencia.GetById(envioDTO.AgenciaId) ?? throw new AgenciaException("La agencia no fue encontrada.");
                Comun envioComun = EnvioMapper.ComunFromEnvioDTO(envioDTO, cliente, funcionario, agencia);
                _repoEnvioComun.Add(envioComun);
            }
        }
    }
}
