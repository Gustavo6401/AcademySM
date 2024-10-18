namespace CadastroUsuario.Domain.Models
{
    public class ProfilePic
    {
        public Guid Id { get; set; }
        public string? FileNameAndPath { get; set; }
        public DateTime DateCreation { get; set; }
        public bool IsActive { get; set; }

        public Guid UserId { get; set; }
        public ApplicationUser? User { get; set; }
    }
}
