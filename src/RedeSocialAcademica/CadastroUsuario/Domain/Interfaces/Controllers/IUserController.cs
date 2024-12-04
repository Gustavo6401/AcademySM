using CadastroUsuario.Domain.Models;
using CadastroUsuario.Domain.Models.API;
using CadastroUsuario.Domain.Models.ControllerModels;
using Microsoft.AspNetCore.Mvc;

namespace CadastroUsuario.Domain.Interfaces.Controllers
{
    public interface IUserController
    {
        /// <summary>
        /// This route returns only one user based in its ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ActionResult<ApplicationUser>> Index(Guid id);
        Task<ActionResult<UserCreateReturn>> Create(ApplicationUser user);
        Task<ActionResult<ApplicationUser>> GetByEmail(string email);
        Task<ActionResult<LoginReturn>> Login(Login login);
        Task<ActionResult> Delete(Guid id);
        Task<ActionResult> Update(ApplicationUser user);
        Task<ActionResult<string>> Logout();
        Task<ActionResult<UserDetailsReturn>> UserDetails(Guid id);
        Task<UserPortfolio> Portfolio(Guid id);
    }
}
