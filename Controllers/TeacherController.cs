using Medhavi_MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Medhavi_MVC.Controllers
{
    [Authorize]
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
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var cover = _applicationDbContext.Teachers.Find(id);
            if (cover == null)
            {
                return NotFound();
            }
            return View(cover);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                _applicationDbContext.Update(teacher);
                _applicationDbContext.SaveChanges();
                TempData["Sucess"] = "Teacher Edited sucessfully";
                return RedirectToAction("Index");
            }
            return View(teacher);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var cover = _applicationDbContext.Teachers.Where(x => x.Id == id).FirstOrDefault();
            return View(cover);


        }
        //post
        [HttpPost]
        public IActionResult Delete(Teacher teacher)
        {
            _applicationDbContext.Teachers.Remove(teacher);
            _applicationDbContext.SaveChanges();
            TempData["Sucess"] = "Teacher deleted sucessfully";
            return RedirectToAction("Index");

        }

    }
}
