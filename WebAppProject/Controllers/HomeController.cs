using DataAccessLibrary.Model;
using DataAccessLibrary.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebAppProject.Models;

namespace WebAppProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBranchRepository _branchRepo;
        private readonly IDepartmentRepository _deptRepo;
        private readonly IStudentRepository _studentRepo;

        public HomeController(ILogger<HomeController> logger,
            IBranchRepository branchRepo,
            IDepartmentRepository deptRepo,
            IStudentRepository studentRepo)
        {
            _logger = logger;
            _branchRepo = branchRepo;
            _deptRepo = deptRepo;
            _studentRepo = studentRepo;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            Branch branch = _branchRepo.Select(e => e.Id == 2);
            Department dept = new Department() { Name = "Another New Dept", BranchId = 2 };
            _deptRepo.Add(dept);
            return Content($"id={branch.Id} name={branch.Name} location={branch.Location}");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
