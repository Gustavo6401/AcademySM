using Groups.Domain.Interfaces.Repositories.SqlServer.Base;
using Groups.Infra.Context;

namespace Groups.Infra.Repository.SqlServer.Base
{
    public class SqlServerRepositoryBase<T> : ISqlServerRepositoryBase<T> where T : class
    {
        private readonly GroupsDbContext _context;
        public SqlServerRepositoryBase(GroupsDbContext context)
        {
            _context = context;
        }
        public virtual async Task Create(T entity)
        {
            _context.Set<T>().Add(entity);

            await _context.SaveChangesAsync();
        }

        public virtual async Task Delete(int id)
        {
            T entity = await Get(id);

            _context.Set<T>().Remove(entity);

            await _context.SaveChangesAsync();
        }

        public virtual async Task<T> Get(int id)
        {
            T? entity = await _context.Set<T>().FindAsync(id);

            return entity!;
        }

        public virtual async Task Update(T entity)
        {
            _context.Set<T>().Update(entity);

            await _context.SaveChangesAsync();
        }
    }
}
