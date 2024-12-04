namespace Groups.Domain.Models.MongoDBModels.Faturas;

public class Fatura 
{
    public string? Id { get; set; }
    public decimal Valor { get; set; }
    public DateTime DataGeracao { get; set; }
    public Guid UserId { get; set; }
    public string? Status { get; set; }
}