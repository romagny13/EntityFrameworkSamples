using SampleWpf.Data;
using System.Windows;

namespace SampleWpf
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
