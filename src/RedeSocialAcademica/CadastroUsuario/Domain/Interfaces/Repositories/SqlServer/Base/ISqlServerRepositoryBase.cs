namespace CadastroUsuario.Domain.Interfaces.Repositories.SqlServer.Base
{
    public interface ISqlServerRepositoryBase<T> where T : class
    {
        Task CreateAsync(T entity);
        Task DeleteAsync(Guid id);
        Task<T> GetAsync(Guid id);
        Task UpdateAsync(T entity);
    }
}
