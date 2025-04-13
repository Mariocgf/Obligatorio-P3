using Compartido.DTOs.Funcionario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCasosUso.FuncionarioCU
{
    public interface IDetalleFuncionario
    {
        FuncionarioDetailDTO Ejecutar(int id);
    }
}
