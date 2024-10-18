namespace CadastroUsuario.Domain.Services.Strategy.PasswordValidation.AllCharTypes.Strategy
{
    public class HasNumberValidationStrategy : IAllTypesCharactersStrategy
    {
        public string Validate(string senha)
        {
            if (senha.Any(char.IsNumber))
                return null!;

            return "Senha Inválida! Faltam Números!";
        }
    }
}
