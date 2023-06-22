using Microsoft.Extensions.Configuration;
using System.IO;

namespace Endeavours.DAL
{
    public class Connection
    {
        private readonly IConfiguration _configuration;

        public Connection()
        {
            // Build the configuration object
            var configurationBuilder = new ConfigurationBuilder().SetBasePath(@"F:\portfolio\EndeavoursAPI\EndeavoursAPI")
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            _configuration = configurationBuilder.Build();
        }

        public string GetConnectionString()
        {
            // Retrieve the connection string value
            string connectionString = _configuration.GetConnectionString("Connect");

            return connectionString;
        }
    }
}
