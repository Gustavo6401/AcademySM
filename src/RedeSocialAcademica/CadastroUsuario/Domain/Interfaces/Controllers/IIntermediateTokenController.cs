using Microsoft.AspNetCore.Mvc;

namespace CadastroUsuario.Domain.Interfaces.Controllers
{
    public interface IIntermediateTokenController
    {
        Task<ActionResult<string>> GetByUserId(Guid id);
        Task<ActionResult<string>> RegenerateToken(Guid id);
    }
}
