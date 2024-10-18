using CadastroUsuario.Domain.Interfaces.Cookies;

namespace CadastroUsuario.Infra.Cookies
{
    public class CookieConfiguration : ICookieConfiguration
    {
        private readonly IHttpContextAccessor _httpContextAcessor;
        public CookieConfiguration(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAcessor = httpContextAccessor;
        }

        public string DeleteHttpOnlyCookie(string key)
        {
            _httpContextAcessor.HttpContext!.Response.Cookies.Delete(key);

            return "Cookie Deletado com Sucesso!";
        }

        public string GetHTTPOnlyCookie(string key)
        {
            string? cookie = _httpContextAcessor.HttpContext!.Request.Cookies[key]!;

            return cookie!;
        }

        public string SetHTTPOnlyCookie(string key, string value, DateTimeOffset expiration, bool isEssential)
        {
            CookieOptions cookie = new CookieOptions
            {
                HttpOnly = true,
                SameSite = SameSiteMode.None,
                Expires = expiration,
                Domain = "localhost",
                Path = "/"
            };

            _httpContextAcessor.HttpContext!.Response.Cookies.Append(key, value, cookie);

            return "Cookie Persistido com Sucesso!";
        }
    }
}
