namespace CadastroUsuario.Domain.Services.Strategy.UserLockout.LockoutAccount.Strategy
{
    public class ThirtyMinutes : IUserBlock
    {
        public int TimeBlock()
        {
            return 30;
        }
    }
}
