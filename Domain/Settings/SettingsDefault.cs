using Microsoft.Extensions.Configuration;

namespace Domain
{
    public class SettingsDefault
    {
        public static IConfigurationRoot ConfiguracaoAppSettings;

        public static void Load(IConfigurationRoot configuracao)
        {
            ConfiguracaoAppSettings = configuracao;
        }
    }
}
