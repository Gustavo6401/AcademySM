using CadastroUsuario.Domain.Interfaces.ApplicationServices;
using CadastroUsuario.Domain.Interfaces.Repositories.SqlServer;
using CadastroUsuario.Domain.Models;

namespace CadastroUsuario.Presentation.ApplicationServices
{
    public class ProfilePicApplicationServices : IProfilePicApplicationServices
    {
        private readonly IProfilePictureRepository _repository;
        public ProfilePicApplicationServices(IProfilePictureRepository repository)
        {
            _repository = repository;
        }
        public async Task Create(ProfilePic profile)
        {
            await _repository.CreateAsync(profile);
        }

        public async Task Delete(Guid id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<ProfilePic> Get(Guid id)
        {
            ProfilePic? profile = await _repository.GetValidProfilePic(id);

            return profile!;
        }

        public async Task<List<ProfilePic>> GetByUserId(Guid id)
        {
            List<ProfilePic>? list = await _repository.GetByUserId(id);

            return list!;
        }

        public async Task<ProfilePic> GetById(Guid id)
        {
            ProfilePic? profile = await _repository.GetAsync(id);

            return profile!;
        }
    }
}
