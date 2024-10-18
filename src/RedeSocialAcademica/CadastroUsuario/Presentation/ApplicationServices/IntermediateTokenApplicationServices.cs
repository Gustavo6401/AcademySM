using CadastroUsuario.Domain.Interfaces.ApplicationServices;
using CadastroUsuario.Domain.Interfaces.Cookies;
using CadastroUsuario.Domain.Interfaces.Repositories.MongoDB.Tokens;
using CadastroUsuario.Domain.Models.MongoDBCollections.TokenPersistence;
using CadastroUsuario.Infra.Tokens.IntermediateToken;

namespace CadastroUsuario.Presentation.ApplicationServices
{
    public class IntermediateTokenApplicationServices : IIntermediateTokenApplicationServices
    {
        private readonly ITokenRepository _repository;
        private readonly ICookieConfiguration _cookieConfiguration;
        public IntermediateTokenApplicationServices(ITokenRepository repository, ICookieConfiguration cookieConfiguration)
        {
            _repository = repository;
            _cookieConfiguration = cookieConfiguration;
        }
        public async Task<string> GetToken(Guid id)
        {
            TokenData? data = await _repository.GetTokenByUserId(id.ToString());

            return data.Token!;
        }

        public async Task<string> RefreshIntermediateToken(Guid id)
        {
            TokenData? data = await _repository.GetTokenByUserId(id.ToString());

            string token = IntermediateTokenService.GenerateToken(data);

            _cookieConfiguration.DeleteHttpOnlyCookie("IntermediateToken");
            _cookieConfiguration.SetHTTPOnlyCookie("IntermediateToken", token, DateTime.UtcNow.AddMinutes(30), true);

            return "Refresh Token Salvo com Sucesso! Podes usá-lo durante 30 minutos!";
        }
    }
}
