using Audit.Domain.Interfaces.Services;
using Audit.Domain.Models;

namespace Audit.Domain.Services
{
    public class UserActionServices : IUserActionServices
    {
        public bool AuthorizeUser(UserAction action)
        {
            ValidateAction(action.Action!);
            ValidateAPIName(action.APIName!);
            ValidateIPv4(action.IPv4!);
            ValidateIPv6(action.IPv6!);
            ValidateToken(action.Token!);
            ValidateUserId(action.UserId!);

            return true;
        }

        public bool ValidateAction(string action)
        {
            List<string> actions = new List<string>
            {
                "GET",
                "POST",
                "PUT",
                "PATCH",
                "DELETE",
                "OPTIONS"
            };

            if (!actions.Contains(action))
                throw new ArgumentException("Wrong HTTP Verb");

            return true;
        }

        public bool ValidateAPIName(string apiName)
        {
            List<string> apis = new List<string>
            {
                "CadastroUsuario",
                "Audit",
                "Groups"
            };

            if (!apis.Contains(apiName))
                throw new ArgumentException("Invalid API's Name");

            return true;
        }

        public bool ValidateIPv4(string ipv4)
        {
            if (string.IsNullOrWhiteSpace(ipv4))
                throw new ArgumentException("Invalid IPv4 Address!");

            return true;
        }

        public bool ValidateIPv6(string ipv6)
        {
            if (string.IsNullOrWhiteSpace(ipv6))
                throw new ArgumentException("Invalid IPv6 Address!");

            return true;
        }

        public bool ValidateToken(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
                throw new ArgumentException("Invalid Main Token!");

            return true;
        }

        public bool ValidateUserId(string? userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
                throw new ArgumentException("Invalid User Id!");

            return true;
        }
    }
}
