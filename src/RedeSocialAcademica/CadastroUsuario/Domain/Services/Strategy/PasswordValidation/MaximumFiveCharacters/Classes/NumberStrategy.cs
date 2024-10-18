namespace CadastroUsuario.Domain.Services.Strategy.PasswordValidation.MaximumFiveCharacters.Classes
{
    public class NumberStrategy : IFiveCharacterStrategy
    {
        public bool CharacterValid(char character)
        {
            return char.IsNumber(character);
        }
    }
}
