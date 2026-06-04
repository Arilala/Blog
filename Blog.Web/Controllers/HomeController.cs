using Blog.Application.Features.Users.Commands.CreateUser;
using Blog.Web.Models;
using LiteBus.Commands.Abstractions;
using LiteBus.Queries.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
namespace Blog.Web.Controllers
{

    [Authorize]
    public class HomeController : Controller
    {
        private readonly ICommandMediator _commandMediator;
        private readonly IQueryMediator _queryMediator;
        public HomeController(ICommandMediator commandMediator, IQueryMediator queryMediator)
        {
            _commandMediator = commandMediator;
            _queryMediator = queryMediator;
        }

        public async Task<IActionResult> Index()
        {
            //for (int i = 1; i <= 3; i++)
            //{
            //    var userInsert = new CreateUserCommand($"monjy-{i}", $"monjy{i}@email.fr", "145264");
            //    await _commandMediator.SendAsync(userInsert);



            //}
            //try
            //{
            //    var userInsert = new CreateUserCommand("", "", "");
            //    await _commandMediator.SendAsync(userInsert);
            //}
            //catch (BadRequestException ex)
            //{
            //    var exception = ex.ValidationErrors;

            //}

            string? username = User.Identity?.Name;

            string? userId = User.FindFirstValue(
                ClaimTypes.NameIdentifier);

            string? email = User.FindFirstValue(
                ClaimTypes.Email);


            return View();
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
