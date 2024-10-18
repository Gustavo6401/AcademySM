using Groups.Domain.Interfaces.ApplicationServices;
using Groups.Domain.Interfaces.DomainServices;
using Groups.Domain.Interfaces.Repositories.SqlServer;
using Groups.Domain.Models.SqlServerModels;
using Microsoft.AspNetCore.Mvc;

namespace Groups.Presentation.ApplicationServices
{
    public class AnnouncementApplicationServices : IAnnouncementApplicationServices
    {
        private readonly IAnnouncementRepository _repository;
        private readonly IAnnouncementServices _services;
        public AnnouncementApplicationServices(IAnnouncementRepository repository, IAnnouncementServices services)
        {
            _repository = repository;
            _services = services;
        }
        public async Task Create(Announcement announcement)
        {
            _services.ValidateOnCreate(announcement);

            await _repository.Create(announcement);
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<Announcement> Get(int id)
        {
            Announcement? announcement = await _repository.Get(id);

            return announcement;
        }

        public async Task<List<Announcement>> Index(int groupId)
        {
            List<Announcement>? list = await _repository.GetAnnouncementsByGroupId(groupId);

            return list!;
        }

        public async Task Update(Announcement announcement)
        {
            _services.ValidateOnCreate(announcement);

            await _repository.Update(announcement);
        }
    }
}
