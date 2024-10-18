namespace CadastroUsuario.Domain.Models.MongoDBCollections.TokenPersistence
{
    public class TokenSettings
    {
        public string? ConnectionString { get; set; }
        public string? DatabaseName { get; set; }
        public string? CollectionName { get; set; }
    }
}
