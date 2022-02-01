using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;
using Store.MediatR.Command;
using Store.Models.User;

namespace Store.MediatR.Handler
{
    public class UserLoginHandler : IRequestHandler<UserLoginCommand, UserModel>
    {
        private readonly UserManager<UserModel> _userManager;
        private readonly SignInManager<UserModel> _signInManager;

        public UserLoginHandler(UserManager<UserModel> userManager, SignInManager<UserModel> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<UserModel> Handle(UserLoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.User.Email);
            var result = await _signInManager.CheckPasswordSignInAsync(user, request.User.Password, false);
            if (result.Succeeded)
            {
                return user;
            }
            return null;
        }
    }
}
