using Compartido.DTOs;
using Compartido.Mappers;
using LogicaAplicacion.InterfacesCasosUso.UsuarioCU;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.UsuarioCU
{
    public class ListarSelectUsuario : IListarSelectUsuario
    {
        private readonly IRepositorioUsuario _repoUsuario;
        public ListarSelectUsuario(IRepositorioUsuario repoUsuario)
        {
            _repoUsuario = repoUsuario;
        }
        public List<InfoSelectDTO> Ejecutar()
        {
            List<Usuario> usuarios = [.. _repoUsuario.GetAll()];
            return UsuarioMapper.UsuarioToInfoSelectDto(usuarios);
        }
    }
}
