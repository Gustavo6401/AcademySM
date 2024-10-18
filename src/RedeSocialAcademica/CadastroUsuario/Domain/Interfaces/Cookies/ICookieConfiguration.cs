namespace CadastroUsuario.Domain.Interfaces.Cookies
{
    public interface ICookieConfiguration
    {
        string GetHTTPOnlyCookie(string key);
        string SetHTTPOnlyCookie(string key, string value, DateTimeOffset expiration, bool isEssential);
        string DeleteHttpOnlyCookie(string key);
    }
}
