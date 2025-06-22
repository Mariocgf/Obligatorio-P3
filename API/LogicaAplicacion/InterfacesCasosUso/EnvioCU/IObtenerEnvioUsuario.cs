using Compartido.DTOs.Envio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCasosUso.EnvioCU
{
    public interface IObtenerEnvioUsuario
    {
        List<EnvioUsuarioDto> Ejecutar(int id);
    }
}
