using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;
using Store.MediatR.Command;
using Store.Models.User;

namespace Store.MediatR.Handler
{
    public class UserRegisterHandler : IRequestHandler<UserRegisterCommand, UserModel>
    {
        private UserManager<UserModel> _userManager;
        private SignInManager<UserModel> _signInManager;
        private RoleManager<IdentityRole> _roleManager;

        public UserRegisterHandler(UserManager<UserModel> userManager, SignInManager<UserModel> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public async Task<UserModel> Handle(UserRegisterCommand request, CancellationToken cancellationToken)
        {
            var newUser = new UserModel
            {
                First_name = request.User.First_name,
                Second_name = request.User.Second_name,
                Email = request.User.Email,
                Address = request.User.Address,
                Cart = "[]",
                UserName = request.User.UserName
            };
            var result = await _userManager.CreateAsync(newUser, request.User.Password);

            if (result.Succeeded)
            {

                var user = await _userManager.FindByEmailAsync(request.User.Email);
                await _userManager.AddToRoleAsync(user, "admin");

                return user;
            }

            return null;
        }
    }
}
