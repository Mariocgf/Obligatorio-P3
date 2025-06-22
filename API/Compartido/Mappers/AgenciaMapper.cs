using Compartido.DTOs;
using Compartido.DTOs.Agencia;
using LogicaNegocio.Entidades;

namespace Compartido.Mappers
{
    public class AgenciaMapper
    {
        public static List<InfoSelectDTO> AgenciaToInfoSelectDTO(List<Agencia> agencias)
        {
            return agencias.Select(a => new InfoSelectDTO()
            {
                Id = a.Id,
                Nombre = a.Nombre,
            }).ToList();
        }
    }
}
