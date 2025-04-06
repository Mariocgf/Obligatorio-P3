using Compartido.DTOs;
using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso
{
    public class DetalleFuncionario : IDetalleFuncionario
    {
        private IRepositorioUsuario _repoUsuario { get; set; }
        public DetalleFuncionario(IRepositorioUsuario repoUsuario)
        {
            _repoUsuario = repoUsuario;
        }

        public FuncionarioDetailDTO Ejecutar(int id)
        {
            Usuario? funcionario = _repoUsuario.GetById(id);
            if (funcionario == null)
                throw new ArgumentNullException("Funcionario no encontrado.");
            return new FuncionarioDetailDTO()
            {
                Id = funcionario.Id,
                Nombre = funcionario.Nombre,
                Apellido = funcionario.Apellido,
                CI = funcionario.CI,
                Celular = funcionario.Celular,
                Email = funcionario.Email.Value
            };
        }
    }
}
