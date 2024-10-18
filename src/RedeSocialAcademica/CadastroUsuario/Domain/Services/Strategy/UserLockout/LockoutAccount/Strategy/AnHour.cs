namespace CadastroUsuario.Domain.Services.Strategy.UserLockout.LockoutAccount.Strategy
{
    public class AnHour : IUserBlock
    {
        public int TimeBlock()
        {
            return 60;
        }
    }
}
