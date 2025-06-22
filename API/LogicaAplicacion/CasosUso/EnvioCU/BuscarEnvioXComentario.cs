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
    public class BuscarEnvioXComentario : IBuscarEnvioXComentario
    {
        private readonly IRepositorioEnvio _repoEnvio;
        public BuscarEnvioXComentario(IRepositorioEnvio repoEnvio)
        {
            _repoEnvio = repoEnvio;
        }
        public List<EnvioBuscadoXComentarioDto> Ejecutar(string comentario, int idUser)
        {
            if(string.IsNullOrEmpty(comentario))
                throw new ArgumentException("El comentario no puede estar vacío.");
            if(idUser <= 0)
                throw new ArgumentException("El ID de usuario debe ser valido.");
            IEnumerable<Envio> envios = _repoEnvio.GetByComentario(comentario, idUser);
            return EnvioMapper.EnviosTOEnvioBuscXComDto(envios, comentario);
        }
    }
}
