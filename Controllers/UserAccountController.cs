using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using System.Security.Claims;
using System.Text;
using Medhavi_MVC.Models;
using Medhavi_MVC.ViewModels;
using System.Security.Cryptography;

namespace Medhavi_MVC.Controllers
{
    public class UserAccountController : Controller
    {
        readonly ApplicationDbContext _applicationDbContext;
        public UserAccountController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Login(UserAccountViewModel userAccountViewModel)
        {
            if (ModelState.IsValid)
            {
                UserAccount? userAccount = _applicationDbContext.UserAccount.Where(x => x.UserName == userAccountViewModel.UserName).FirstOrDefault();
                if (userAccount == null)
                {
                    return BadRequest("User Not Found");
                }
                var hashedPassword = HashPassword(userAccountViewModel.PassWord);
                if (userAccount.PassWord != hashedPassword)
                {
                    return View(userAccount);
                }
                else
                {

                    var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, userAccount.UserName),
                    new Claim(ClaimTypes.Role, userAccount.RoleName),
                };
                    var claimsIdentity = new ClaimsIdentity(
                        claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var authProperties = new AuthenticationProperties
                    {
                        ExpiresUtc = DateTime.Now.AddMinutes(10),
                    };
                    await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);
                    return RedirectToAction("Index", "Home");
                }

            }
            return View(userAccountViewModel);
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(UserAccount userAccount)
        {
            if (ModelState.IsValid)
            {
                userAccount.PassWord = HashPassword(userAccount.PassWord);
                _applicationDbContext.UserAccount.Add(userAccount);
                _applicationDbContext.SaveChanges();
                return RedirectToAction("Login");
            }
            return View(userAccount);
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }
        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }
    }
}
