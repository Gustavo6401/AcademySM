using Groups.Domain.Models.SqlServerModels;

namespace Groups.Domain.Interfaces.DomainServices
{
    public interface IMessageServices
    {
        bool ValidateContent(string content);
        bool ValidateOnCreate(Message message);
    }
}
