using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace sale_API.Handler
{
    public class AuthHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        public AuthHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock)
                :base( options , logger , encoder , clock )
        {
            
        }
        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if(!Request.Headers.ContainsKey("Authorization"))
            {
                return AuthenticateResult.Fail("bearer Token Failed");
            }

            var authValue =  AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
            var bytes = Convert.FromBase64String(authValue.Parameter);
            String[] authcredential = Encoding.UTF8.GetString(bytes).Split(":");
            String email = authcredential[0];
            String pass = authcredential[1];

            //admin
            String adminemail = "test@gmail.com";
            String adminpass = "testpass";

            //validatingadmin

            try
            {

                if (!(adminemail == email && adminpass == pass))
                {
                    return AuthenticateResult.Fail("admin login required");
                }

                else
                {
                    var claims = new[] { new Claim(ClaimTypes.Name, email) };
                    var identity = new ClaimsIdentity(claims, Scheme.Name);
                    var Priciples = new ClaimsPrincipal(identity);
                    var ticket = new AuthenticationTicket(Priciples, Scheme.Name);

                    return AuthenticateResult.Success(ticket);
                }

            }
            catch (Exception)
            {

                return AuthenticateResult.Fail("bearer Token Failed");
            }

            
        }
    }
}
