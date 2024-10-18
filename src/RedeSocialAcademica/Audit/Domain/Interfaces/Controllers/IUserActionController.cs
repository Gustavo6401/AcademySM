using Audit.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Audit.Domain.Interfaces.Controllers
{
    public interface IUserActionController
    {
        Task<ActionResult<string>> AuthorizeUserAction(UserAction action);
    }
}
