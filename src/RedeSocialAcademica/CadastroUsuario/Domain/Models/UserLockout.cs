namespace CadastroUsuario.Domain.Models
{
    public class UserLockout
    {
        public Guid Id { get; set; }
        public DateTime LockoutDate { get; set; }
        public int QtdMinutes { get; set; }

        public ApplicationUser? User { get; set; }
        public Guid UserId { get; set; }
    }
}
