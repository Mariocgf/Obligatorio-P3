using Compartido.DTOs.Agencia;
using MVC.Models.Agencia;

namespace MVC.Models
{
    public class EnvioCreateViewModel
    {
        public bool EsUrgente { get; set; }
        public int EmailCliente { get; set; }
        public int AgenciaId { get; set; }
        public string DireccionPostal { get; set; }
        public decimal Peso { get; set; }

        public IEnumerable<AgenciaSelectViewModel> Agencias { get; set; } = new List<AgenciaSelectViewModel>();
        public IEnumerable<SelectInfoViewModel> Usuarios { get; set; } = new List<SelectInfoViewModel>();

    }
}
