using System.Collections.Generic;

namespace SampleWeb.Data
{
    public interface ICompanyRepository
    {
        List<Company> GetAll();
    }
}
