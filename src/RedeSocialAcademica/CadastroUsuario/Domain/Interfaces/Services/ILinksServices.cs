using CadastroUsuario.Domain.Models;

namespace CadastroUsuario.Domain.Interfaces.Services
{
    public interface ILinksServices
    {
        void ValidateLink(string? link);
        void ValidateSource(string? source);
        void Validate(Links? links);
    }
}
