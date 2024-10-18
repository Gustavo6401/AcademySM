using Audit.Domain.Models;

namespace Audit.Domain.Interfaces.ApplicationServices
{
    public interface IUserActionApplicationServices
    {
        Task<string> ValidateUserAction(UserAction action);
    }
}
