namespace CadastroUsuario.Domain.Services.Strategy.PasswordValidation.AllCharTypes
{
    public interface IAllTypesCharactersStrategy
    {
        string Validate(string senha);
    }
}
