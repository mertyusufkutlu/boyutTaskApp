using Microsoft.Extensions.Configuration;

namespace boyutTaskAppAPI.Persistence
{
    static class Configuration
    {
        public static string ConnectionString 
        {
            get
            {
                ConfigurationManager configurationManager = new();
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/boyutTaskApp.API"));
                configurationManager.AddJsonFile("appsettings.json");
                return configurationManager.GetConnectionString("PostgreSQL");
            }
        }
    }
}
