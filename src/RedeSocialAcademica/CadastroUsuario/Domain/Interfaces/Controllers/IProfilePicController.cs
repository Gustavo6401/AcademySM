using CadastroUsuario.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace CadastroUsuario.Domain.Interfaces.Controllers
{
    public interface IProfilePicController
    {
        Task<ActionResult<string>> Create(ProfilePic picture);
        Task<ActionResult<string>> Delete(Guid id);
        Task<ActionResult<ProfilePic>> Index(Guid id);
        Task<ActionResult<ProfilePic>> GetLastProfilePic(Guid userId);
        Task<ActionResult<List<ProfilePic>>> GetProfilePicturesByUserId(Guid userId);
    }
}
