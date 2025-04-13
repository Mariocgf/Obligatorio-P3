using Compartido.DTOs.Envio;
using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.Mappers
{
    public class EnvioMapper
    {
        public static Urgente UrgenteFromEnvioDTO(EnvioDTO envioDTO, Usuario cliente, Usuario funcionario)
        {
            return new Urgente(funcionario, cliente, envioDTO.Peso, envioDTO.DireccionPostal);
        }
        public static Comun ComunFromEnvioDTO(EnvioDTO envioDTO, Usuario cliente, Usuario funcionario, Agencia agencia)
        {
            return new Comun(funcionario, cliente, envioDTO.Peso, agencia);
        }
    }
}
