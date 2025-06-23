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
        public static List<EnvioUsuarioDto> EnviosTOEnvioUsuarioDto(IEnumerable<Envio> envios)
        {
            return envios.Select(e => new EnvioUsuarioDto
            {
                Id = e.Id,
                NroTracking = e.NroTracking,
                Fecha = e.FechaCreacion,
                Comentario = e.ListaSeguimiento.Any() ? e.ListaSeguimiento.Last().Comentario : "Sin comentarios",
                Peso = e.Peso,
                Estado = e.Estado.ToString(),
                TipoEnvio = e is Comun ? "Comun" : "Urgente"
            }).ToList();
        }

        public static EnvioAPInfoDto EnvioToEnvioAPInfoDto(Envio envio)
        {
            List<SeguimientoEnvioDto> comentarios = envio.ListaSeguimiento.Select(s => new SeguimientoEnvioDto { Comentario = s.Comentario, Fecha = s.Fecha}).OrderByDescending(s => s.Fecha).ToList();
            EnvioAPInfoDto envioAPInfoDto = new EnvioAPInfoDto
            {
                NroTracking = envio.NroTracking,
                Peso = envio.Peso,
                Estado = envio.Estado.ToString(),
                Comentarios = comentarios
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
        //x
        public static List<EnvioBuscadoXComentarioDto> EnviosTOEnvioBuscXComDto(IEnumerable<Envio> envios, string comentario)
        {
            return envios.Select(e => new EnvioBuscadoXComentarioDto
            {
                Id = e.Id,
                NroTracking = e.NroTracking,
                Estado = e.Estado.ToString(),
                Fecha = e.FechaCreacion,
                TipoEnvio = e is Comun ? "Comun" : "Urgente",
                Comentario = e.ListaSeguimiento.First(s => s.Comentario.ToUpper().Contains(comentario)).Comentario,
            }).ToList();
        }

        public static List<SeguimientoEnvioDto> EnviosToSeguimientoEnvioDto(IEnumerable<Envio> envios)
        {
            return envios.Select(e => e.ListaSeguimiento).SelectMany(s => s.Select(sg => new SeguimientoEnvioDto
            {
                Fecha = sg.Fecha,
                Comentario = sg.Comentario,
            })).OrderByDescending(s => s.Fecha).ToList();
        }
    }
}

