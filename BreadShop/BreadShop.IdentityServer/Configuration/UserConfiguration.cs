using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityModel;

namespace BreadShop.IdentityServer.Configuration
{
    /// <summary>
    /// Contains user related inmemory configurations.
    /// </summary>
    public static class UserConfiguration
    {
        /// <summary>
        /// Retrieve sample user collection.
        /// </summary>
        /// <returns>Sample user collection.</returns>
        public static List<TestUser> Get() {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "Mihira",
                    Password = "pass@123",
                    Claims = new []
                    {
                        new Claim(JwtClaimTypes.Role, "Admin"), 
                        new Claim("name", "Alice"),
                        new Claim("website", "https://alice.com")
                    }
                }
            };
        }
    }
}
