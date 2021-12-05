using System.Windows;
using WithHostFactoryWpf.Data;

namespace WithHostFactoryWpf
{
    public partial class MainWindow : Window
    {
        private ICompanyRepository _companyRepository;

        public MainWindow(ICompanyRepository companyRepository)
        {
            InitializeComponent();

            _companyRepository = companyRepository;
            LoadCompanies();
        }

        private void LoadCompanies()
        {
            var companies = _companyRepository.GetAll();
            listBox.ItemsSource = companies;
        }
    }
}
