namespace CadastroUsuario.Domain.Services.Strategy.PasswordValidation.MaximumFiveCharacters.Classes
{
    public class UpperStrategy : IFiveCharacterStrategy
    {
        public bool CharacterValid(char character)
        {
            return char.IsUpper(character);
        }
    }
}
