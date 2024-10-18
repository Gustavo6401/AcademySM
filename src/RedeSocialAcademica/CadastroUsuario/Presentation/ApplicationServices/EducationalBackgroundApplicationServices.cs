using CadastroUsuario.Domain.Interfaces.ApplicationServices;
using CadastroUsuario.Domain.Interfaces.Repositories.SqlServer;
using CadastroUsuario.Domain.Interfaces.Services;
using CadastroUsuario.Domain.Models;

namespace CadastroUsuario.Presentation.ApplicationServices
{
    public class EducationalBackgroundApplicationServices : IEducationalBackgroundApplicationServices
    {
        private readonly IEducationalBackgroundRepository _repository;
        private readonly IEducationalBackgroundServices _domainServices;
        public EducationalBackgroundApplicationServices(IEducationalBackgroundRepository repository, IEducationalBackgroundServices domainServices)
        {
            _repository = repository;
            _domainServices = domainServices;
        }

        public async Task Create(EducationalBackground background)
        {
            _domainServices.ValidateOnCreateEducationalBackground(background);

            await _repository.CreateAsync(background);
        }

        public async Task Delete(Guid id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<EducationalBackground> Get(Guid id)
        {
            EducationalBackground? background = await _repository.GetAsync(id);

            return background!;
        }

        public async Task<List<EducationalBackground>> GetByUserId(Guid userId)
        {
            List<EducationalBackground>? list = await _repository.GetByUserId(userId);

            return list!;
        }

        public async Task Update(EducationalBackground background)
        {
            _domainServices.ValidateOnCreateEducationalBackground(background);

            await _repository.UpdateAsync(background);
        }
    }
}
