using Medhavi_MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using NuGet.Common;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;

namespace Medhavi_MVC.Controllers
{
    public class FriendController : Controller
    {
        private readonly ApplicationDbContext _db;
        public FriendController(ApplicationDbContext db)
        {

        }


        // GET: FriendController
        public ActionResult Index()
        {
            IEnumerable<Friend> friends = _db.Friend.ToList();
            return View(friends);
        }

        // GET: FriendController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FriendController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FriendController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Friend friend)
        {
            if (ModelState.IsValid)
            {
                //string ujjwal = HashPassword(friend.Name);
                _db.Friend.Add(friend);
                _db.SaveChanges();
                TempData["Sucess"] = "Friend  Added sucessfully";
                return RedirectToAction("Index");
            }
            return View(friend);
        }

        private string HashPassword(string name)
        {
            using (var sha25 = SHA256.Create())
            {
                var hasedByte = sha25.ComputeHash(Encoding.UTF8.GetBytes(name));
                return Convert.ToBase64String(hasedByte);
            }
        }

        // GET: FriendController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FriendController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FriendController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FriendController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
