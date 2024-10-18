namespace CadastroUsuario.Domain.Models
{
    public class Institution
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? BrazilianCity { get; set; }
        public string? BrazilianState { get; set; }
    }
}
