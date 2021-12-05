using System.Collections.Generic;

namespace SampleWebNet6.Data
{
    public interface ICompanyRepository
    {
        List<Company> GetAll();
    }
}
