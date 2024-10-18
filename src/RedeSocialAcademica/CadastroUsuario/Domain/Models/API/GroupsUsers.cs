namespace CadastroUsuario.Domain.Models.API
{
    public class GroupsUsers
    {
        public int Id { get; set; }
        public string? Role { get; set; }

        public Guid UserId { get; set; }
        public int GroupId { get; set; }
    }
}
