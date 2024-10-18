using Groups.Domain.Interfaces.DomainServices;
using Groups.Domain.Models.SqlServerModels;

namespace Groups.Domain.DomainServices
{
    public class AnnouncementServices : IAnnouncementServices
    {
        public bool ValidateAnnouncementText(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                throw new ArgumentException("Texto de Aviso Inválido!");

            return true;
        }

        public bool ValidateOnCreate(Announcement announcement)
        {
            ValidateAnnouncementText(announcement.AnnouncementText!);

            return true;
        }
    }
}
