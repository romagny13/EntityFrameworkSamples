using System.Collections.Generic;
using System.Linq;

namespace SampleWeb.Data
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ApplicationDbContext _db;

        public CompanyRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public List<Company> GetAll()
        {
            return _db.Companies.ToList();
        }
    }
}
