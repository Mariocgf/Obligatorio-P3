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
    public class AltaEnvioComun : IAltaEnvioComun
    {
        private readonly IRepositorioEnvioComun _repoEnvioComun;
        private readonly IRepositorioUsuario _repoUsuario;
        private readonly IRepositorioAgencia _repoAgencia;
        public AltaEnvioComun(IRepositorioEnvioComun repoEnvioComun,
                         IRepositorioUsuario repoUsuario,
                         IRepositorioAgencia repoAgencia)
        {
            _repoEnvioComun = repoEnvioComun;
            _repoUsuario = repoUsuario;
            _repoAgencia = repoAgencia;
        }
        public void Ejecutar(EnvioComunDTO envioDTO, int idFuncionario)
        {
            ArgumentNullException.ThrowIfNull(envioDTO);
            Usuario cliente = _repoUsuario.GetById(envioDTO.ClienteId) ?? throw new UsuarioException("Cliente no registrado.");
            Usuario funcionario = _repoUsuario.GetById(idFuncionario) ?? throw new UsuarioException("Funcionario no registrado.");
            Agencia agencia = _repoAgencia.GetById(envioDTO.AgenciaId) ?? throw new AgenciaException("La agencia no fue encontrada.");
            Comun envioComun = EnvioMapper.ComunFromEnvioDTO(envioDTO, cliente, funcionario, agencia);
            _repoEnvioComun.Add(envioComun);

        }
    }
}
