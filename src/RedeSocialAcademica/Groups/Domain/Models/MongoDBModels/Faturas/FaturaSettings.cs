namespace Groups.Domain.Models.MongoDBModels.Faturas
{
    public class FaturaSettings
    {
        public string? ConnectionString { get; set; }
        public string? DatabaseName { get; set; }
        public string? CollectionName { get; set; }
    }
}
