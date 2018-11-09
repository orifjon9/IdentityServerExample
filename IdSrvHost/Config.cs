using System;
using System.Collections.Generic;
using System.Security.Claims;
using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Test;

namespace IdSrvHost
{
    public class Config
    {
        public static IEnumerable<Client> GetClients()
            => new List<Client>
            {
                new Client
                {
                    ClientId = "mvc",
                    ClientName = "MVC App",
                    AllowedGrantTypes = GrantTypes.Implicit,

                    RequireConsent = false,

                    RedirectUris = { "http://localhost:5002/signin-oidc" },
                    PostLogoutRedirectUris = { "http://localhost:5002/signout-callback-oidc" },

                    AllowedScopes = { "openid", "email", "office", "api1" } 
                }
            };

        public static List<TestUser> GetTestUsers() 
            => new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "info@orifjon.net",
                    Password = "Pass123!$",
                    Claims = new List<Claim>
                    {
                        new Claim("office_number", "25"),
                        new Claim(JwtClaimTypes.Name, "Orifjon Narkulov"),
                        new Claim(JwtClaimTypes.Email, "info@orifjon.net"),
                        new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Email),
                        new Claim(JwtClaimTypes.WebSite, "http://www.orifjon.net")
                    }
                }
            };

        public static IEnumerable<IdentityResource> GetIdentityResources()
            => new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Email(),
                new IdentityResources.Profile(),
                new IdentityResource
                {
                    Name = "office",
                    Description = "Office number",
                    DisplayName = "Office number",
                    UserClaims = { "office_number" }
                }
            };

        public static IEnumerable<ApiResource> GetApiResources() => new List<ApiResource>();
    }
}
