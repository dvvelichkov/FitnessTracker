using System.Security.Claims;


namespace FitnessTracker.Infrastructure.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static string GetId(this ClaimsPrincipal user)
            => user.FindFirst(ClaimTypes.NameIdentifier).Value;

        public static string GetEmail(this ClaimsPrincipal user)
            => user.FindFirst(ClaimTypes.Email).Value;

    }
}
