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

            var roles = User.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value).ToList();

            //var roleAdmin = new CreateRoleCommand("Admin", "Administrateur du blog");
            //var roleUser = new CreateRoleCommand("User");

            //await _commandMediator.SendAsync(roleAdmin);
            //await _commandMediator.SendAsync(roleUser);

            //var roleUserUpdate = new UpdateRoleCommand(2, "User", "Utilisateur du blog");

            //await _commandMediator.SendAsync(roleUserUpdate);

            //var roleToDelete = new DeleteRoleCommand(2);
            //await _commandMediator.SendAsync(roleToDelete);




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
