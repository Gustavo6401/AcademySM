namespace CadastroUsuario.Domain.Services.Strategy.UserLockout.LockoutAccount.Strategy
{
    public class FifteenMinutes : IUserBlock
    {
        public int TimeBlock()
        {
            return 15;
        }
    }
}
