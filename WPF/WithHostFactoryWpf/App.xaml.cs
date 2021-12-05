using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;
using WithHostFactoryWpf.Data;

namespace WithHostFactoryWpf
{
    public partial class App : Application
    {
        private IHost host;

        public App()
        {
            host = CreateHostBuilder().Build();
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            host.Start();

            IDbInitializer initializer = host.Services.GetService<IDbInitializer>();
            initializer.Initialize();

            var shell = host.Services.GetRequiredService<MainWindow>();
            shell.Show();
        }

        public static IHostBuilder CreateHostBuilder() =>
            Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(context.Configuration.GetConnectionString("DefaultConnection")));
                services.AddScoped<IDbInitializer, DbInitializer>();
                services.AddScoped<ICompanyRepository, CompanyRepository>();
                services.AddScoped<MainWindow>();
            })
            .ConfigureAppConfiguration((context, configurationBuilder) =>
            {
                configurationBuilder.SetBasePath(context.HostingEnvironment.ContentRootPath);
                configurationBuilder.AddJsonFile("appsettings.json", optional: false);
            });
    }
}
