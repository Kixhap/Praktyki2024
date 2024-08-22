using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
{
    public BasicAuthenticationHandler(
        IOptionsMonitor<AuthenticationSchemeOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder,
        ISystemClock clock)
        : base(options, logger, encoder, clock)
    {
    }

    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        if (!Request.Headers.ContainsKey("Authorization"))
            return AuthenticateResult.Fail("Missing Authorization Header");

        try
        {
            string authHeader = Request.Headers["Authorization"].ToString();
            var authHeaderVal = System.Net.Http.Headers.AuthenticationHeaderValue.Parse(authHeader);

            if (authHeaderVal.Scheme.Equals("basic", StringComparison.OrdinalIgnoreCase) && authHeaderVal.Parameter != null)
            {
                var credentials = Encoding.UTF8.GetString(Convert.FromBase64String(authHeaderVal.Parameter)).Split(':', 2);
                var username = credentials[0];
                var password = credentials[1];

                if (username == "admin" && password == "admin1")
                {
                    var claims = new[]
                    {
                        new Claim(ClaimTypes.Name, username),
                        new Claim(ClaimTypes.Role, "Admin")
                    };
                    var identity = new ClaimsIdentity(claims, Scheme.Name);
                    var principal = new ClaimsPrincipal(identity);
                    var ticket = new AuthenticationTicket(principal, Scheme.Name);

                    return AuthenticateResult.Success(ticket);
                }
            }

            return AuthenticateResult.Fail("Invalid Authorization Header");
        }
        catch
        {
            return AuthenticateResult.Fail("Invalid Authorization Header");
        }
    }
}
