using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreadShop.WebApi
{
    /// <summary>
    /// this includes oidc configuration properties.
    /// </summary>
    public static class Constant
    {
        /// <summary>
        /// Filename of appsettings json file.
        /// </summary>
        public const string AppSettingsJsonFileName = "appsettings.json";

        /// <summary>
        /// Authuntication header value prefix.
        /// </summary>
        public const string AuthenticationHeaderPrefix = "Bearer";

        /// <summary>
        /// Oidc configuration section name.
        /// </summary>
        public const string OidcConfigurationSectionName = "OidcConfiguration";
    }
}
