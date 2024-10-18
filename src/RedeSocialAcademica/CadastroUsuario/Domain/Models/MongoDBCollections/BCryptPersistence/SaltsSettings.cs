namespace CadastroUsuario.Domain.Models.MongoDBCollections.BCryptPersistence
{
    public class SaltsSettings
    {
        public string? ConnectionString { get; set; }
        public string? DatabaseName { get; set; }
        public string? SaltsCollectionName { get; set; }
    }
}
