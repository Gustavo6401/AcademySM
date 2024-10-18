using Groups.Domain.Models.SqlServerModels;

namespace Groups.Domain.Interfaces.DomainServices
{
    public interface IArticleServices
    {
        bool ValidateTitle(string title);
        bool ValidateAuthor(string author);
        bool ValidateYearWriting(int yearWriting);
        bool ValidateOnCreate(Article article);
    }
}
