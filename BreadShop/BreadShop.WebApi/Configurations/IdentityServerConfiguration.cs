using Microsoft.Extensions.Configuration;

namespace BreadShop.WebApi.Configurations
{
    public class IdentityServerConfiguration
    {
        public static OidcConfiguration GetOidcConfiguration()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .AddJsonFile(Constant.AppSettingsJsonFileName, false)
                .Build();

            OidcConfiguration oidcConfiguration = new OidcConfiguration();
            configuration.GetSection(Constant.OidcConfigurationSectionName)
                .Bind(oidcConfiguration);

            return oidcConfiguration;
        }
    }
}
