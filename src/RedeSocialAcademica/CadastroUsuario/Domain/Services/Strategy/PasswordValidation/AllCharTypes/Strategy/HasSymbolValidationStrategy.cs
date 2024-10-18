namespace CadastroUsuario.Domain.Services.Strategy.PasswordValidation.AllCharTypes.Strategy
{
    public class HasSymbolValidationStrategy : IAllTypesCharactersStrategy
    {
        private string _symbols = "!@#$%¨&*()£¢¬/?°\\|\":;.,><^~`´}]º{{ª=+§-_\'";
        public string Validate(string senha)
        {
            if (senha.Any(c => _symbols.Contains(c)))
                return null!;

            return "Senha Inválida! Faltam Caracteres Especiais!";
        }
    }
}
