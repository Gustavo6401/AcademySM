using Microsoft.AspNetCore.Authorization;

namespace CadastroUsuario.Infra.Authentication
{
    public class IntermediateTokenSchemeRequirement : IAuthorizationRequirement { }
    public class IntermediateTokenSchemeHandler : AuthorizationHandler<IntermediateTokenSchemeRequirement>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public IntermediateTokenSchemeHandler(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IntermediateTokenSchemeRequirement requirement)
        {
            HttpContext httpContext = _httpContextAccessor.HttpContext!;

            var intermediateToken = httpContext.Request.Cookies["IntermediateToken"];

            if (!string.IsNullOrWhiteSpace(intermediateToken)) 
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
