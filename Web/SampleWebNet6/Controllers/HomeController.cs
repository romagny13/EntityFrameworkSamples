using Microsoft.AspNetCore.Mvc;
using SampleWebNet6.Data;
using SampleWebNet6.Models;
using System.Diagnostics;

namespace SampleWebNet6.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ICompanyRepository companyRepository, ILogger<HomeController> logger)
        {
            _companyRepository = companyRepository;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(_companyRepository.GetAll());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}