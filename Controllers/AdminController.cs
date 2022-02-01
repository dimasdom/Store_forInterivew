using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Store.MediatR.Command;
using Store.MediatR.Query;
using Store.Models.DTOs;

namespace Store.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private readonly IMediator _mediator;

        public AdminController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Roles()
        {
            var command = new GetRolesQuery();
            var result = await _mediator.Send(command);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(string RoleName)
        {
            var command = new AddRoleCommand(RoleName);
            var result = await _mediator.Send(command);
            return RedirectToAction("Roles", "Admin");
        }
        [HttpGet]
        public async Task<IActionResult> DeleteRole(string Id)
        {
            var command = new DeleteRoleCommand(Id);
            var result = await _mediator.Send(command);
            return RedirectToAction("Roles", "Admin");
        }
        [HttpGet]
        public async Task<IActionResult> UsersInRole(string Id)
        {
            var command = new GetUsersInRoleQuery(Id);
            var result = await _mediator.Send(command);
            ViewBag.RoleName = Id;
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> GetUserByName([FromForm] string UserName)
        {
            var command = new GetUserQuery(UserName);
            var result = await _mediator.Send(command);
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> AddUserToRole([FromForm] UserRoleDTOs data)
        {
            var command = new AddUserToRoleCommand(data.UserName, data.RoleName);
            var result = await _mediator.Send(command);
            return Redirect($"/Admin/UsersInRole/{data.RoleName}");
        }
        [HttpPost]
        public async Task<IActionResult> DeleteUserFromRole([FromForm] UserRoleDTOs data)
        {
            var command = new DeleteUserFromRoleCommand(data.UserName, data.RoleName);
            var result = await _mediator.Send(command);
            return Redirect($"/Admin/UsersInRole/{data.RoleName}");
        }
        [HttpGet]
        public async Task<IActionResult> Orders()
        {
            var command = new GetOrdersQuery();
            var result = await _mediator.Send(command);
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> ChangeOrderStatus([FromForm] string Id, string Status)
        {

            var command = new ChangeOrderStatusCommand(Guid.Parse(Id), Status);
            await _mediator.Send(command);
            return Redirect($"/Shop/OrderDetails/{Id}");
        }
    }
}
