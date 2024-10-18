using CadastroUsuario.Domain.Models;

namespace CadastroUsuario.Domain.Interfaces.Services
{
    public interface IUserLockoutServices
    {
        int TimeBlock(UserLockout lockout);
    }
}
