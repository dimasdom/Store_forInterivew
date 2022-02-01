using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;
using Store.MediatR.Command;
using Store.Models.User;

namespace Store.MediatR.Handler
{
    public class LogOutHandler : IRequestHandler<LogOutCommand, bool>
    {
        private readonly SignInManager<UserModel> _signInManager;

        public LogOutHandler(SignInManager<UserModel> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<bool> Handle(LogOutCommand request, CancellationToken cancellationToken)
        {
            await _signInManager.SignOutAsync();
            return true;
        }
    }
}
