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
        public static Urgente UrgenteFromEnvioDTO(EnvioUrgenteDTO envioDTO, Usuario cliente, Usuario funcionario)
        {
            return new Urgente(funcionario, cliente, envioDTO.Peso, envioDTO.DireccionPostal);
        }
        public static Comun ComunFromEnvioDTO(EnvioComunDTO envioDTO, Usuario cliente, Usuario funcionario, Agencia agencia)
        {
            return new Comun(funcionario, cliente, envioDTO.Peso, agencia);
        }
        public static List<EnvioListadoDTO> EnvioTOEnvioListadoDTO(List<Envio> envio, List<Usuario> usuarios)
        {
            return envio.Select(e => new EnvioListadoDTO
            {
                Id = e.Id,
                NroTracking = e.NroTracking,
                Empleado = $"{usuarios.FirstOrDefault(u => u.Id == e.Empleado.Id).Nombre} {usuarios.FirstOrDefault(u => u.Id == e.Empleado.Id).Apellido}",
                Cliente = $"{usuarios.FirstOrDefault(u => u.Id == e.Cliente.Id).Nombre} {usuarios.FirstOrDefault(u => u.Id == e.Cliente.Id).Apellido}",
                Peso = e.Peso,
                Estado = e.Estado.ToString(),
                TipoEnvio = e is Comun ? "Comun" : "Urgente",
            }).ToList();
        }
        public static EnvioDetalleDto EnvioTOEnvioDetalleDTO(Envio envio)
        {
            List<string> estados = [.. Enum.GetNames(typeof(Estados))];

            return new EnvioDetalleDto
            {
                Id = envio.Id,
                NroTracking = envio.NroTracking,
                Empleado = $"{envio.Empleado.Nombre} {envio.Empleado.Apellido}",
                Cliente = $"{envio.Cliente.Nombre} {envio.Cliente.Apellido}",
                Peso = envio.Peso,
                Estado = envio.Estado.ToString(),
                TipoEnvio = envio is Comun ? "Comun" : "Urgente",
                FechaCreacion = envio.FechaCreacion,
                FechaEntrega = envio.FechaEntrega,
                Estados = estados
            };
        }

        public static EnvioAPInfoDto EnvioToEnvioAPInfoDto(Envio envio)
        {
            EnvioAPInfoDto envioAPInfoDto = new EnvioAPInfoDto
            {
                NroTracking = envio.NroTracking,
                Peso = envio.Peso,
                Estado = envio.Estado.ToString(),
                Comentario = envio.ListaSeguimiento.LastOrDefault()?.Comentario
            };
            if (envio is Comun comun)
            {
                envioAPInfoDto.TipoEnvio = "Comun";
                envioAPInfoDto.InfoAdicional = comun.AgenciaDestino.Nombre;
            }
            else
            {
                envioAPInfoDto.TipoEnvio = "Urgente";
                envioAPInfoDto.InfoAdicional = ((Urgente)envio).Direccion;
            }
            return envioAPInfoDto;
        }
    }
}
