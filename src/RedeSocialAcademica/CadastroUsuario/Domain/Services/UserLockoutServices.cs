using CadastroUsuario.Domain.Interfaces.Services;
using CadastroUsuario.Domain.Models;
using CadastroUsuario.Domain.Services.Strategy.UserLockout.LockoutAccount;
using CadastroUsuario.Domain.Services.Strategy.UserLockout.LockoutAccount.Strategy;

namespace CadastroUsuario.Domain.Services
{
    public class UserLockoutServices : IUserLockoutServices
    {
        private readonly LockoutStrategyManager manager;        

        Dictionary<int, IUserBlock> _lockoutStrategies = new Dictionary<int, IUserBlock>
        {
            { 0, new FiveMinutes() },
            { 5, new TenMinutes() },
            { 10, new FifteenMinutes() },
            { 15, new ThirtyMinutes() },
            { 30, new AnHour() },
            { 60, new AnHour() }
        };

        public UserLockoutServices()
        {
            manager = new LockoutStrategyManager(_lockoutStrategies);
        }
        public int TimeBlock(UserLockout lockout)
        {
            IUserBlock block = manager.GetStrategyClass(lockout.LockoutDate, lockout.QtdMinutes);
            int resp = block.TimeBlock();

            return resp;
        }
    }
}
