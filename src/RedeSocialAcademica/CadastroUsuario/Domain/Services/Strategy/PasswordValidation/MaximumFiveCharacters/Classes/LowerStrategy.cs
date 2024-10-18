namespace CadastroUsuario.Domain.Services.Strategy.PasswordValidation.MaximumFiveCharacters.Classes
{
    public class LowerStrategy : IFiveCharacterStrategy
    {
        public bool CharacterValid(char character)
        {
            return char.IsLower(character);
        }
    }
}
