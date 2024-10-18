namespace Groups.Domain.Interfaces.Repositories.SqlServer.Base
{
    public interface ISqlServerRepositoryBase<T> where T : class
    {
        Task Create(T entity);
        Task<T> Get(int id);
        Task Delete(int id);
        Task Update(T entity);
    }
}
