using LogicaNegocio.Entidades;
using Compartido.DTOs.Funcionario;


namespace Compartido.Mappers
{
    public class FuncionarioMapper
    {
        public static Usuario FuncionarioFromFuncionarioDTO(FuncionarioDTO funcionarioDTO, Rol rol)
        {
            return new Usuario
                (funcionarioDTO.Nombre,
                 funcionarioDTO.Apellido,
                 funcionarioDTO.CI,
                 funcionarioDTO.Celular,
                 funcionarioDTO.Email,
                 funcionarioDTO.Password,
                 rol);

        }
        public static Usuario FuncionarioFromFuncionarioUpdateDTO(FuncionarioUpdateDTO funcionarioDTO, Rol rol)
        {
            return new Usuario
                (funcionarioDTO.Nombre,
                 funcionarioDTO.Apellido,
                 funcionarioDTO.CI,
                 funcionarioDTO.Celular,
                 funcionarioDTO.Email,
                 funcionarioDTO.Password,
                 rol);

        }
        public static FuncionarioUpdateDTO FuncionarioToFuncionarioUpdateDTO(Usuario funcionario)
        {
            return new FuncionarioUpdateDTO()
            {
                Id = funcionario.Id,
                Nombre = funcionario.Nombre,
                Apellido = funcionario.Apellido,
                CI = funcionario.CI,
                Celular = funcionario.Celular,
                Email = funcionario.Email.Value,
                Password = funcionario.Password.Value,
                RolId = funcionario.RolId
            };
        }
        public static List<FuncionarioListarDTO> FuncionarioToFuncionarioListarDTO(List<Usuario> funcionarios, List<Rol> rolList)
        {
            return funcionarios.Select(f => new FuncionarioListarDTO()
            {
                Id = f.Id,
                Nombre = f.Nombre,
                Apellido = f.Apellido,
                CI = f.CI,
                Email = f.Email.Value,
                Rol = f.Rol.Nombre,
            }).ToList();
        }
        public static FuncionarioDetailDTO FuncionarioToFuncionarioDetailDTO(Usuario funcionario)
        {
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
        //public static Usuario FuncionarioFromFuncionarioDTO(FuncionarioDTO funcionarioDTO)
        //{
        //    return new Usuario()
        //    {
        //        Nombre = funcionarioDTO.Nombre,
        //        Apellido = funcionarioDTO.Apellido,
        //        CI = funcionarioDTO.CI,
        //        Celular = funcionarioDTO.Celular,
        //        Email = funcionarioDTO.Email,
        //        Password = funcionarioDTO.Password
        //    };
        //}
    }
}
