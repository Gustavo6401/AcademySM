namespace CadastroUsuario.Domain.Models.MongoDBCollections.BCryptPersistence
{
    public class SaltsData
    {
        public string? Id { get; set; }
        public string? Salt { get; set; }
        public string? Email { get; set; }
    }
}
