using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace E.S.Api.Helpers.Extensions
{
    public static class HttpContextAccessorExtensions
    {
        public static string ToUserName(this IHttpContextAccessor httpContextAccessor)
        {
            var token = httpContextAccessor.ToToken();

            if (token is null)
                return "Unauthorized";

            return token.ToUserNameFromToken();
        }

        public static string ToAuthorizationHeader(this IHttpContextAccessor httpContextAccessor)
        {
            if (httpContextAccessor == null) return null;

            var authorizationHeader = httpContextAccessor?.HttpContext?.Request?.Headers["Authorization"]
                .ToString();

            if (string.IsNullOrEmpty(authorizationHeader)) return null;

            return authorizationHeader;
        }


        public static string ToToken(this IHttpContextAccessor httpContextAccessor)
        {
            if (httpContextAccessor == null) return null;

            var authorizationHeader = httpContextAccessor.ToAuthorizationHeader();

            if (string.IsNullOrEmpty(authorizationHeader)) return null;

            return authorizationHeader.ToTokenFromAuthorizationHeader();
        }

        public static string ToTokenFromAuthorizationHeader(this string authorizationHeader)
        {
            if (string.IsNullOrWhiteSpace(authorizationHeader)) return null;

            var authorizationHeaders = authorizationHeader.Split(' ');
            if (authorizationHeaders.Length <= 1) return null;

            var token = authorizationHeaders[1];

            return token;
        }

        public static string ToUserNameFromToken(this string token)
        {
            if (string.IsNullOrEmpty(token))
                return "Unauthorized";

            var jwt = new JwtSecurityToken(token);

            var userName = jwt?.Claims?.FirstOrDefault(x => x.Type.Equals("upn"))
                ?.Value;

            return userName ?? "Unauthorized";
        }
    }
}