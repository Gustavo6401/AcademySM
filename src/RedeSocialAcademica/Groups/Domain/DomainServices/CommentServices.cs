using Groups.Domain.Interfaces.DomainServices;
using Groups.Domain.Models.SqlServerModels;

namespace Groups.Domain.DomainServices
{
    public class CommentServices : ICommentServices
    {
        public bool ValidateContent(string content)
        {
            if (string.IsNullOrWhiteSpace(content))
                throw new ArgumentException("Conteúdo Inválido!");

            return true;
        }

        public bool ValidateOnCreate(Comment comment)
        {
            ValidateContent(comment.Content!);

            return true;
        }
    }
}
