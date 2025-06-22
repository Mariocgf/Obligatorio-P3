
namespace LogicaNegocio.ExepcionesEntidades
{
    public class RolException : Exception
    {
        public RolException(string message) : base(message)
        {
        }

        public RolException(string message, Exception innerException) : base(message, innerException)
        {
        }
        public RolException() { }
    }
}
