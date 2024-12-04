using CadastroUsuario.Domain.Interfaces.ApplicationServices;
using CadastroUsuario.Domain.Interfaces.Repositories.SqlServer;
using CadastroUsuario.Domain.Interfaces.Services;
using CadastroUsuario.Domain.Models;

namespace CadastroUsuario.Presentation.ApplicationServices
{
    public class LinksApplicationServices : ILinksApplicationServices
    {
        private readonly ILinksRepository _repository;
        private readonly ILinksServices _services;
        public LinksApplicationServices(ILinksRepository repository, ILinksServices services)
        {
            _repository = repository;
            _services = services;
        }
        public async Task Create(Links? links)
        {
            _services.Validate(links!);

            await _repository.Add(links);
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<Links>? Get(int id)
        {
            Links? links = await _repository.Get(id)!;

            return links!;
        }

        public async Task<List<Links>>? GetByUserId(Guid id)
        {
            List<Links>? links = await _repository.GetByUserId(id)!;

            return links!;
        }

        public async Task Update(Links? links)
        {
            _services.Validate(links!);

            await _repository.Update(links!);
        }
    }
}
