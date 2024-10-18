using Microsoft.AspNetCore.Authorization;

namespace CadastroUsuario.Infra.Authentication
{
    public class MainTokenSchemeRequirement : IAuthorizationRequirement { }
    public class MainTokenSchemeHandler : AuthorizationHandler<MainTokenSchemeRequirement>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public MainTokenSchemeHandler(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MainTokenSchemeRequirement requirement)
        {
            HttpContext? httpContext = _httpContextAccessor.HttpContext!;

            var mainToken = httpContext.Request.Cookies["MainToken"];

            if(!string.IsNullOrWhiteSpace(mainToken))
            {
                context.Succeed(requirement);
            }
            else
            {
                context.Fail();
            }

            return Task.CompletedTask;
        }
    }
}
