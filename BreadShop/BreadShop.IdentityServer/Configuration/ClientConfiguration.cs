using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;
using IdentityModel;

namespace BreadShop.IdentityServer.Configuration
{
    /// <summary>
    /// Contains client related inmemory configurations.
    /// </summary>
    public static class ClientConfiguration
    {
        /// <summary>
        /// Retrieve sample client collection.
        /// </summary>
        /// <returns>Sample client collection.</returns>
        public static IList<Client> Get()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "js",
                    ClientName = "JavaScript Client",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,

                    RedirectUris =           { "http://localhost:4200/login/callback" },
                    PostLogoutRedirectUris = { "http://localhost:4200/index.html" },
                    AllowedCorsOrigins =     { "http://localhost:4200" },

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        JwtClaimTypes.Role,
                        "breadshop"
                    }
                }
            };
        }
    }
}
