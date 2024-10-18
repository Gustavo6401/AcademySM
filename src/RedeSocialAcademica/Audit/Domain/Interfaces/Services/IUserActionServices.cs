using Audit.Domain.Models;

namespace Audit.Domain.Interfaces.Services
{
    public interface IUserActionServices
    {
        bool AuthorizeUser(UserAction action);
        bool ValidateAPIName(string apiName);
        bool ValidateUserId(string? userId);
        bool ValidateIPv4(string ipv4);
        bool ValidateIPv6(string ipv6);
        bool ValidateAction(string action);
        bool ValidateToken(string token);
    }
}
