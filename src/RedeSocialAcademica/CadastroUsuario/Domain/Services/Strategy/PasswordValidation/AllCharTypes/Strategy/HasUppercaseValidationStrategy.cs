namespace CadastroUsuario.Domain.Services.Strategy.PasswordValidation.AllCharTypes.Strategy
{
    public class HasUppercaseValidationStrategy : IAllTypesCharactersStrategy
    {
        public string Validate(string senha)
        {
            if (senha.Any(char.IsUpper))
                return null!;

            return "Senha Inválida! Faltam Letras Maiúsculas!";
        }
    }
}
