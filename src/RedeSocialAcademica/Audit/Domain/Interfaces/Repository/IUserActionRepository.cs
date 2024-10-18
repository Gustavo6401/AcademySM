using Audit.Domain.Models;

namespace Audit.Domain.Interfaces.Repository
{
    public interface IUserActionRepository
    {
        /// <summary>
        /// Saves an user action on the database.
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        Task CreateAction(UserAction action);
        /// <summary>
        /// Gets user's actions based in its Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<UserAction> GetAction(string? id);
        /// <summary>
        /// Gets the actions made by the same token.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<List<UserAction>> GetLastFiveActionsMadeByTheSameToken(string token);
    }
}
