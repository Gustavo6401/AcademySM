namespace CadastroUsuario.Domain.Services.Strategy.UserLockout.LockoutAccount.Strategy
{
    public class TenMinutes : IUserBlock
    {
        public int TimeBlock()
        {
            return 10;
        }
    }
}
