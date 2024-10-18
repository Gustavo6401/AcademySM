namespace CadastroUsuario.Domain.Services.Strategy.PasswordValidation.AllCharTypes
{
    public class ValidatePassword
    {
        private readonly List<IAllTypesCharactersStrategy> _strategies;

        public ValidatePassword(List<IAllTypesCharactersStrategy> strategies)
        {
            _strategies = strategies;
        }

        public string Validate(string senha)
        {
            List<string> errors = new List<string>();

            foreach (var strategy in _strategies)
            {
                var result = strategy.Validate(senha);
                if (result != null)
                    errors.Add(result);
            }

            return errors.Any() ? string.Join(", ", errors) : "Senha Válida!";
        }
    }
}
