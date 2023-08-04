using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using QuadTheoryTestProject.Models;
using QuadTheoryTestProject.Models.ViewModel;
using QuadTheoryTestProject.Repository.Interface;
using QuadTheoryTestProject.Repository.InterFace;
using System.Diagnostics;

namespace QuadTheoryTestProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IClassRepository _classRepository;
        private readonly IStudentRepository _studentRepository;
        public HomeController(ILogger<HomeController> logger, IClassRepository classRepository, IStudentRepository studentRepository)
        {
            _logger = logger;
            _classRepository = classRepository;
            _studentRepository = studentRepository;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _studentRepository.GetAllStudentAsync();

            return View(list);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public async Task<IActionResult> AddStudent()
        {
            var model = await _classRepository.GetAllClassAsync();

            ViewBag.Classes = new SelectList(model, "Id", "Name");

            return View();
        }
        public async Task<IActionResult> UpdateStudent(Guid id)
        {
            var model = await _classRepository.GetAllClassAsync();

            ViewBag.Classes = new SelectList(model, "Id", "Name");

            StudentViewModel item = await _studentRepository.GetStudentByIdAsync(id);

            return View(item);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}