using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCasosUso.EnvioCU
{
    public interface IAgregarComentario
    {
        void Ejecutar(int idEnvio, int idEmpleado, string comentario);
    }
}
