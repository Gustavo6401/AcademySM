using Microsoft.AspNetCore.Authorization;

namespace Groups.Infra.Authentication
{
    public class MultipleSchemesRequirement : IAuthorizationRequirement { }
    public class MultipleSchemesHandler : AuthorizationHandler<MultipleSchemesRequirement>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public MultipleSchemesHandler(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MultipleSchemesRequirement requirement)
        {
            HttpContext? httpContext = _httpContextAccessor.HttpContext!;

            var mainToken = httpContext.Request.Cookies["MainToken"];
            var intermediateToken = httpContext.Request.Cookies["IntermediateToken"];

            if (!string.IsNullOrWhiteSpace(mainToken) || !string.IsNullOrWhiteSpace(intermediateToken))
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
