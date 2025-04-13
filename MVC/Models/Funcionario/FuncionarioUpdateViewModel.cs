using MVC.Models.Rol;

namespace MVC.Models.Funcionario
{
    public class FuncionarioUpdateViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string CI { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RolId { get; set; }
        public IEnumerable<RolViewModel> Roles { get; set; } = new List<RolViewModel>();
    }
}
