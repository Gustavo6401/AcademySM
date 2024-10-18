namespace CadastroUsuario.Domain.Services.Strategy.UserLockout.LockoutAccount
{
    public class LockoutStrategyManager
    {
        private readonly Dictionary<int, IUserBlock> _lockoutStrategies;
        public LockoutStrategyManager(Dictionary<int, IUserBlock> lockoutStrategies)
        {
            _lockoutStrategies = lockoutStrategies;
        }

        public IUserBlock GetStrategyClass(DateTime date, int bloqueio)
        {
            // It means that if the previous Lockout was in another day, even yesterday, we should block the user by the same way.
            if (date < DateTime.Today)
            {
                return _lockoutStrategies.Values.ElementAt(0); // FiveMinutes strategy
            }

            if (_lockoutStrategies.TryGetValue(bloqueio, out IUserBlock? blockPassword))
            {
                return blockPassword;
            }

            throw new ArgumentException("Número de bloqueio inválido");
        }
    }
}
