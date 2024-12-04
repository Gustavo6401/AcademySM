using CadastroUsuario.Domain.Interfaces.Services;
using CadastroUsuario.Domain.Models;

namespace CadastroUsuario.Domain.Services
{
    public class LinksServices : ILinksServices
    {
        public void Validate(Links? links)
        {
            ValidateLink(links!.Link);
            ValidateSource(links!.Origin);
        }

        public void ValidateLink(string? link)
        {
            // Code generated with ChatGPT.
            if (string.IsNullOrWhiteSpace(link) ||
                !Uri.TryCreate(link, UriKind.Absolute, out Uri? uriResult) ||
                (uriResult.Scheme != Uri.UriSchemeHttp && uriResult.Scheme != Uri.UriSchemeHttps))
            {
                throw new ArgumentException("Link Inválido.");
            }
        }

        public void ValidateSource(string? source)
        {
            if(string.IsNullOrWhiteSpace(source))
            {
                throw new ArgumentException("Fonte do Link Inválida!");
            }
        }
    }
}
