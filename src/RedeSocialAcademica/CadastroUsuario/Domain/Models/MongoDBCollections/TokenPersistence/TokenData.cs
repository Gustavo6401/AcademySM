namespace CadastroUsuario.Domain.Models.MongoDBCollections.TokenPersistence
{
    public class TokenData
    {
        public string? Id { get; set; }
        public string? Token { get; set; }
        public DateTime? DataCriacaoToken { get; set; }
        public string? UsuarioId { get; set; }
    }
}
