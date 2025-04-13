using Compartido.DTOs.Agencia;
using Compartido.Mappers;
using LogicaAplicacion.InterfacesCasosUso.AgenciaCU;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.AgenciaCU
{
    public class ListarSAgencia : IListarSAgencia
    {
        private readonly IRepositorioAgencia _repoAgencia;
        public ListarSAgencia(IRepositorioAgencia repoAgencia)
        {
            _repoAgencia = repoAgencia;
        }

        public List<AgenciaSelectDTO> Ejecutar()
        {
            List<Agencia> agencias = _repoAgencia.GetAll().ToList();
            return AgenciaMapper.AgenciaToAgenciaSelectDTO(agencias);
        }
    }
}
