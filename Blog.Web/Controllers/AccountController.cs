using System.Security.Claims;
using Blog.Application.Features.Users.Queries.CheckUser;
using Blog.Web.Models;
using LiteBus.Queries.Abstractions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IQueryMediator _queryMediator;
        private readonly ILogger<AccountController> _logger;

        public AccountController(IQueryMediator queryMediator, ILogger<AccountController> logger)
        {
            _queryMediator = queryMediator;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            _logger.LogInformation("Page login");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid) {
                return View(model);
            }
            var user = await _queryMediator.QueryAsync(new CheckUserQuery(model.Username, model.Password));
            if (user == null)
            {
                ModelState.AddModelError("", "Invalid credentials");
                return View(model);
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Email, user.Email),
               
            };


            if(user.Roles != null)
            {
                foreach (var role in user.Roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }
            }

            var identity = new ClaimsIdentity(
                claims,
                CookieAuthenticationDefaults.AuthenticationScheme
            );

            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                principal
            );

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(Login));
        }
    }
}
