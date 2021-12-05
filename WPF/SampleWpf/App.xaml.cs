using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SampleWpf.Data;
using System.IO;
using System.Windows;

namespace SampleWpf
{
    public partial class App : Application
    {
        private ServiceProvider _serviceProvider;

        public App()
        {
            // Build
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            _serviceProvider = serviceCollection.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ApplicationDbContext>();
            services.AddSingleton<IDbInitializer, DbInitializer>();
            services.AddTransient<ICompanyRepository, CompanyRepository>();
            services.AddTransient<MainWindow>();
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            // Run
            IDbInitializer dbInitializer = _serviceProvider.GetService<IDbInitializer>();
            dbInitializer.Initialize();

            var shell = _serviceProvider.GetRequiredService<MainWindow>();
            shell.Show();
        }
    }

    public class ConfigurationManager
    {
        private IConfiguration _configuration;
        private static ConfigurationManager _default;

        public ConfigurationManager()
        {
            // Configuration (Microsoft.Extensions.Configuration + Microsoft.Extensions.Configuration.Json)
            var builder = new ConfigurationBuilder();
            builder
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true); // set appsettings.json file as content and copy
            _configuration = builder.Build();
        }

        public static ConfigurationManager Default
        {
            get
            {
                if (_default == null)
                    _default = new ConfigurationManager();

                return _default;
            }
        }

        public string GetConnectionString(string connectionStringName)
        {
            // Microsoft.Extensions.Options.ConfigurationExtensions
            return _configuration.GetConnectionString(connectionStringName);
        }

        public IConfigurationSection GetSection(string sectionName)
        {
            return _configuration.GetSection(sectionName);
        }
    }
}
