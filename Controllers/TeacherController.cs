using Medhavi_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace Medhavi_MVC.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public TeacherController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public IActionResult Index()
        {
            var list = _applicationDbContext.Teachers.ToList();
            return View(list);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                _applicationDbContext.Add(teacher);
                _applicationDbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(teacher);
        }

    }
}
