namespace CadastroUsuario.Domain.Services.Strategy.UserLockout.LockoutAccount.Strategy
{
    public class FiveMinutes : IUserBlock
    {
        public int TimeBlock()
        {
            return 5;
        }
    }
}
