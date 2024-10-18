using Groups.Domain.Models.SqlServerModels;

namespace Groups.Domain.Interfaces.DomainServices
{
    public interface IPostServices
    {
        bool ValidateTitle(string title);
        bool ValidateContent(string content);
        bool ValidateOnCreate(Post post);
    }
}
