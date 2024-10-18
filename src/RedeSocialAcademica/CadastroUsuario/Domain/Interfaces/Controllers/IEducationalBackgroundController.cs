using CadastroUsuario.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace CadastroUsuario.Domain.Interfaces.Controllers
{
    public interface IEducationalBackgroundController
    {
        Task<ActionResult<EducationalBackground>> Index(Guid id);
        Task<ActionResult<List<EducationalBackground>>> GetByUserId(Guid userId);
        Task<ActionResult<string>> Create([FromBody] EducationalBackground background);
        Task<ActionResult<string>> Update([FromBody] EducationalBackground background);
        Task<ActionResult<string>> Delete(Guid id);
    }
}
