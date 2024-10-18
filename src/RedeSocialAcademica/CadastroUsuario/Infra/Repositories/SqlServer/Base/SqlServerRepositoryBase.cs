using CadastroUsuario.Domain.Interfaces.Repositories.SqlServer.Base;
using CadastroUsuario.Infra.Context;

namespace CadastroUsuario.Infra.Repositories.SqlServer.Base;

public class SqlServerRepositoryBase<T> : ISqlServerRepositoryBase<T> where T : class
{
    private readonly UserDbContext _context;
    public SqlServerRepositoryBase(UserDbContext context)
    {
        _context = context;
    }
    public virtual async Task CreateAsync(T entity)
    {
        _context.Set<T>()
                .Add(entity);

        await _context.SaveChangesAsync();
    }

    public virtual async Task DeleteAsync(Guid id)
    {
        var entity = await GetAsync(id);

        _context.Set<T>()
                .Remove(entity);

        await _context.SaveChangesAsync();
    }

    public virtual async Task<T> GetAsync(Guid id)
    {
        var resp = await _context.Set<T>()
                                 .FindAsync(id)!;

        return resp!;
    }

    public virtual async Task UpdateAsync(T entity)
    {
        _context.Set<T>()
                .Update(entity);

        await _context.SaveChangesAsync();
    }
}
