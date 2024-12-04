using CadastroUsuario.Domain.Interfaces.Repositories.SqlServer;
using CadastroUsuario.Domain.Models;
using CadastroUsuario.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace CadastroUsuario.Infra.Repositories.SqlServer
{
    public class LinksRepository : ILinksRepository
    {
        private readonly UserDbContext _context;
        public LinksRepository(UserDbContext context)
        {
            _context = context;
        }
        public async Task Add(Links? links)
        {
            _context.Links.Add(links!);

            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Links? links = await Get(id)!;

            _context.Links.Remove(links);

            await _context.SaveChangesAsync();
        }

        public async Task<Links>? Get(int id)
        {
            Links? links = await _context.Links.FindAsync(id);

            return links!;
        }

        public async Task<List<Links>>? GetByUserId(Guid id)
        {
            List<Links>? listLinks = await _context.Links.Where(t => t.UserId == id)
                                                         .ToListAsync();

            return listLinks!;
        }

        public async Task Update(Links links)
        {
            _context.Links.Update(links);

            await _context.SaveChangesAsync();
        }
    }
}
