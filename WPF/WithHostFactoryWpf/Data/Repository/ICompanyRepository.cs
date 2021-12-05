using System.Collections.Generic;

namespace WithHostFactoryWpf.Data
{
    public interface ICompanyRepository
    {
        List<Company> GetAll();
    }
}
