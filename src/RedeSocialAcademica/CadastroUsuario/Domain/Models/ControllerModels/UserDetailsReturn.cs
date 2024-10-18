namespace CadastroUsuario.Domain.Models.ControllerModels
{
    public class UserDetailsReturn
    {
        public Guid Id { get; set; }
        public string? FullName { get; set; }
        public string? Formation { get; set; }
        public string? ProfilePicFileName { get; set; }

        public List<FormationName>? Formations { get; set; }
    }
}
