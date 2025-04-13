using Compartido.DTOs.Agencia;
using LogicaNegocio.Entidades;

namespace Compartido.Mappers
{
    public class AgenciaMapper
    {
        public static List<AgenciaSelectDTO> AgenciaToAgenciaSelectDTO(List<Agencia> agencias)
        {
            return agencias.Select(a => new AgenciaSelectDTO()
            {
                Id = a.Id,
                Nombre = a.Nombre,
            }).ToList();
        }
    }
}
