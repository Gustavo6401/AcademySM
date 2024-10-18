using Groups.Domain.Interfaces.DomainServices;
using Groups.Domain.Models.SqlServerModels;

namespace Groups.Domain.DomainServices
{
    public class PostServices : IPostServices
    {
        public bool ValidateContent(string content)
        {
            if (string.IsNullOrWhiteSpace(content))
                throw new ArgumentException("Conteúdo do Post Inválido!");

            return true;
        }

        public bool ValidateOnCreate(Post post)
        {
            ValidateContent(post.Content!);
            ValidateTitle(post.Title!);

            return true;
        }

        public bool ValidateTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Título de Post Inválido!");

            return true;
        }
    }
}
