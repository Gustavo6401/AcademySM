using Audit.Domain.Interfaces.ApplicationServices;
using Audit.Domain.Interfaces.Repository;
using Audit.Domain.Interfaces.Services;
using Audit.Domain.Models;
using Audit.Infra.API;

namespace Audit.Presentation.ApplicationServices
{
    public class UserActionApplicationServices : IUserActionApplicationServices
    {
        private readonly IUserActionServices _services;
        private readonly IUserActionRepository _repository;
        private readonly UserAPI _userAPI;
        public UserActionApplicationServices(IUserActionServices services, IUserActionRepository repository, UserAPI userAPI)
        {
            _services = services;
            _repository = repository;
            _userAPI = userAPI;
        }
        public async Task<string> ValidateUserAction(UserAction action)
        {
            _services.AuthorizeUser(action);

            await _repository.CreateAction(action);

            List<UserAction> lastFiveActions = await _repository.GetLastFiveActionsMadeByTheSameToken(action.Token!);

            if(IsSuspiciousActivity(lastFiveActions) == true)
            {
                await _userAPI.Logout();

                throw new UnauthorizedAccessException("Atividade Suspeita Detectada! Sua sessão irá expirar!");
            }

            return "Ação Válida.";
        }

        /// <summary>
        /// This method is checking whether users token was robbed. The objective of this algorithm is to see 
        /// whether the same token is been used by two different IpAdresses.
        /// </summary>
        /// <param name="listActions"></param>
        /// <param name="currentActions"></param>
        /// <returns></returns>
        private bool IsSuspiciousActivity(List<UserAction> listActions)
        {
            for (int i = 1; i < listActions.Count - 1; i++)
            {
                if (listActions[i].IPv4 != listActions[i - 1].IPv4 && (listActions[i].IPv6 != listActions[i - 1].IPv6))
                {
                    if(i == 4)
                    {
                        return false;
                    }

                    if (listActions[i].IPv4 != listActions[i + 1].IPv4 && listActions[i].IPv6 != listActions[i + 1].IPv6)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
