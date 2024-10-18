namespace Groups.Domain.Models.API
{
    public class TokenReturn
    {
        public string? Id { get; set; }
        public string? IntermediateToken { get; set; }
        public string? MainToken { get; set; }
    }
}
