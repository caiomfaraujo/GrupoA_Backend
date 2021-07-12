using Microsoft.AspNetCore.Hosting;

namespace Domain
{
    public class HostingEnvironmentService
    {
        public static IHostingEnvironment Environment;
        public static void Load(IHostingEnvironment env)
        {
            Environment = env;
        }
    }
}
