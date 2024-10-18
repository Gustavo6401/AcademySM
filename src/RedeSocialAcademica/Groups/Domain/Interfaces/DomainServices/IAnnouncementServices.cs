using Groups.Domain.Models.SqlServerModels;

namespace Groups.Domain.Interfaces.DomainServices
{
    public interface IAnnouncementServices
    {
        bool ValidateOnCreate(Announcement announcement);
        bool ValidateAnnouncementText(string text);
    }
}
