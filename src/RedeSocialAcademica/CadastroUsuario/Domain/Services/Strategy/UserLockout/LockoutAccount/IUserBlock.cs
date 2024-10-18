namespace CadastroUsuario.Domain.Services.Strategy.UserLockout.LockoutAccount
{
    public interface IUserBlock
    {
        /// <summary>
        /// This should determinate User's Time of lockout.
        /// </summary>
        /// <returns></returns>
        int TimeBlock();
    }
}
