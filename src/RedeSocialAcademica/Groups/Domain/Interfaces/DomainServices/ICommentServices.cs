using Groups.Domain.Models.SqlServerModels;

namespace Groups.Domain.Interfaces.DomainServices
{
    public interface ICommentServices
    {
        bool ValidateContent(string content);
        bool ValidateOnCreate(Comment comment);
    }
}
