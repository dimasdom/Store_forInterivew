using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using Store.MediatR.Command;
using Store.MediatR.Command.Account;
using Store.MediatR.Query;
using Store.Models.DTOs;
using Store.Models.User;

namespace Store.Controllers
{
    public class AccountController : Controller
    {
        private readonly IMediator _mediator;
        private UserManager<UserModel> _userManager;
        private SignInManager<UserModel> _signInManager;

        public AccountController(IMediator mediatR, UserManager<UserModel> userManager, SignInManager<UserModel> signInManager)
        {
            _mediator = mediatR;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View("Register");
        }
        [HttpPost]
        public async Task<ActionResult<UserModel>> Register([FromForm] UserRegisterDTOs userRegisterDTOs)
        {
            
            var newUser = new UserModel
            {
                First_name = userRegisterDTOs.First_name,
                Second_name = userRegisterDTOs.Second_name,
                Email = userRegisterDTOs.Email,
                Address = userRegisterDTOs.Address,
                Cart = "[]",
                UserName = userRegisterDTOs.UserName
            };
            var result = await _userManager.CreateAsync(newUser, userRegisterDTOs.Password);

            if (result.Succeeded)
            {


                return RedirectToAction("Index","Home");
            }
            return NotFound();

        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromForm] UserLoginDTOs userLoginDTOs)
        {
            var user = await _userManager.FindByEmailAsync(userLoginDTOs.Email);
            var result = await _signInManager.PasswordSignInAsync(user.UserName, userLoginDTOs.Password, false, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            return NotFound("Ivalid Data"); ;
            
        }
        
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> MyAccount()
        {
            var AccountUser = await _userManager.FindByNameAsync(User.Identity.Name);

            return View(AccountUser);
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> MyOrders()
        {
            var query = new GetMyOrdersQuery(User.Identity.Name);
            var result = await _mediator.Send(query);
            return View(result);
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            var command = new LogOutCommand();
            await _mediator.Send(command);
            return RedirectToAction("Index", "Home");
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ChangeAccData([FromForm] UserRegisterDTOs userData)
        {
            var command = new ChangeUserDataCommand(User.FindFirstValue(ClaimTypes.NameIdentifier), userData);
            await _mediator.Send(command);
            return RedirectToAction("MyAccount", "Account");
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> ChangeAccData()
        {
            var AccountUser = await _userManager.FindByNameAsync(User.Identity.Name);

            return View(AccountUser);
        }
    }
}
