namespace CadastroUsuario.Domain.Services.Strategy.PasswordValidation.MaximumFiveCharacters
{
    public interface IFiveCharacterStrategy
    {
        /// <summary>
        /// Validates whether the password has more than 5 characters followed of the same type.
        /// </summary>
        /// <param name="character"></param>
        /// <returns></returns>
        bool CharacterValid(char character);
    }
}
