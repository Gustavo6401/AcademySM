namespace CadastroUsuario.Domain.Interfaces.ApplicationServices
{
    public interface IIntermediateTokenApplicationServices
    {
        Task<string> GetToken(Guid id);
        Task<string> RefreshIntermediateToken(Guid id);
    }
}
