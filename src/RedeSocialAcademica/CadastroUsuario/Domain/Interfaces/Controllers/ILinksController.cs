using CadastroUsuario.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace CadastroUsuario.Domain.Interfaces.Controllers
{
    public interface ILinksController
    {
        Task<ActionResult<string>> Add(Links? links);
        Task<ActionResult<string>> Delete(int id);
        Task<ActionResult<Links>>? Get(int id);
        Task<ActionResult<List<Links>>>? Index(Guid id);
        Task<ActionResult<string>> Update(Links? links);
    }
}
