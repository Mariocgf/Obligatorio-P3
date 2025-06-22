
namespace LogicaNegocio.Entidades
{
    public class Auditoria
    {
        public int Id { get; set; }
        public string Accion { get; set; }
        public DateTime Fecha { get; set; }
        public Usuario Empleado { get; set; }
        public Auditoria(string accion, Usuario empleado)
        {
            Accion = accion;
            Fecha = DateTime.Now;
            Empleado = empleado;
        }
        private Auditoria() { }
    }
}
