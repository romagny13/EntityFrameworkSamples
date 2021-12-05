using System.Linq;

namespace SampleWebNet6.Data
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext context;

        public DbInitializer(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Initialize()
        {
            try
            {
                if (context.Companies.Any())
                    return;

                context.Companies.Add(new Company { Name = "Company 1" });
                context.Companies.Add(new Company { Name = "Company 2" });

                context.SaveChanges();
            }
            catch
            { }
        }
    }

}
