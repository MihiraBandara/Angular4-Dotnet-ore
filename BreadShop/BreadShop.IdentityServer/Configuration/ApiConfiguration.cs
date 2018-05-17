using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityModel;

namespace BreadShop.IdentityServer.Configuration
{
    /// <summary>
    /// Contains api related inmemory configurations.
    /// </summary>
    public static class ApiConfiguration
    {
        /// <summary>
        /// Retrieve sample api resource collection.
        /// </summary>
        /// <returns>Sample api resource collection.</returns>
        public static IList<ApiResource> Get() {
            return new List<ApiResource>()
            {
                new ApiResource("breadshop", "My API",new[] { JwtClaimTypes.Name, JwtClaimTypes.Role })
            };
        }
    }


}
