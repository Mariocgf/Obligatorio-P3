using Compartido.DTOs.Envio;
namespace LogicaAplicacion.InterfacesCasosUso.EnvioCU
{
    public interface IAltaEnvio
    {
        void Ejecutar(EnvioDTO envioDTO, int idFuncionario);
    }
}
