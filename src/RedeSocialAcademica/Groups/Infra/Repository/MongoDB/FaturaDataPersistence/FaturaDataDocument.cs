using MongoDB.Bson;

namespace Groups.Infra.Repository.MongoDB.FaturaDataPersistence
{
    public class FaturaDataDocument
    {
        public ObjectId Id { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataGeracao { get; set; }
        public Guid UserId { get; set; }
        public string? Status { get; set; }
    }
}
