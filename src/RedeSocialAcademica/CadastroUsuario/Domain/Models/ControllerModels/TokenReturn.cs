namespace CadastroUsuario.Domain.Models.ControllerModels
{
    public class TokenReturn
    {
        public string? Id { get; set; }
        public string? IntermediateToken { get; set; }
        public string? MainToken { get; set; }
    }
}
