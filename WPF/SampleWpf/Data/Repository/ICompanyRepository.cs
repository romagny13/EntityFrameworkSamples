using System.Collections.Generic;

namespace SampleWpf.Data
{
    public interface ICompanyRepository
    {
        List<Company> GetAll();
    }
}
