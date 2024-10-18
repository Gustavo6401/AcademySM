namespace CadastroUsuario.Domain.Models.ControllerModels
{
    public class LoginReturn
    {
        public Guid Id { get; set; }
        public string? UserFullName { get; set; }
        public string? UserProfilePicPath { get; set; }
        public string? ReturnMessage { get; set; }
    }
}
