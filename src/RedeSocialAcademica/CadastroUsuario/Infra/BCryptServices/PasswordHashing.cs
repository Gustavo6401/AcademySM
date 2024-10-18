using BCrypt.Net;

namespace CadastroUsuario.Infra.BCryptServices
{
    public class PasswordHashing
    {
        public static string HashPassword(string password, string salt)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, salt, enhancedEntropy: true, HashType.SHA512);
        }

        public static string GenerateSalt(int workFactor)
        {
            return BCrypt.Net.BCrypt.GenerateSalt(workFactor);
        }
    }
}
