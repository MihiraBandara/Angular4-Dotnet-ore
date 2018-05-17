using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityModel;

namespace BreadShop.IdentityServer.Configuration
{
    /// <summary>
    /// Contains scope related inmemory configurations.
    /// </summary>
    public static class ScopeConfiguration
    {
        /// <summary>
        /// Retrieve sample scopes collection.
        /// </summary>
        /// <returns>Sample scopes collection.</returns>
        public static IList<Scope> Get()
        {
            return new List<Scope>
            {
                new Scope
                {
                    Name = "breadshop",
                    DisplayName = "breadshop",
                    Description = "breadshop",
                    UserClaims = new List<string>()
                    {
                        JwtClaimTypes.Role,
                        JwtClaimTypes.Name
                    }
                }
            };
        }

        /// <summary>
        /// Retrieve sample identity collection.
        /// </summary>
        /// <returns>Sample identity collection.</returns>
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        }
    }
}
