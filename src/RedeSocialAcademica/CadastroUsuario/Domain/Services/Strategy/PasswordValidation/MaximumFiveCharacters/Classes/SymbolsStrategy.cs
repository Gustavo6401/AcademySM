namespace CadastroUsuario.Domain.Services.Strategy.PasswordValidation.MaximumFiveCharacters.Classes
{
    public class SymbolsStrategy : IFiveCharacterStrategy
    {
        private string _symbols = "!@#$%¨&*()£¢¬/?°\\|\":;.,><^~`´}]º{{ª=+§-_\'";
        public bool CharacterValid(char character)
        {
            return _symbols.Contains(character);
        }
    }
}
