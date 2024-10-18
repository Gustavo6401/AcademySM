namespace CadastroUsuario.Domain.Services.Strategy.PasswordValidation.AllCharTypes.Strategy
{
    public class HasLowerCaseValidationStrategy : IAllTypesCharactersStrategy
    {
        public string Validate(string senha)
        {
            if (senha.Any(char.IsLower))
                return null!;

            return "Senha Inválida! Faltam Letras Minúsculas!";
        }
    }
}
