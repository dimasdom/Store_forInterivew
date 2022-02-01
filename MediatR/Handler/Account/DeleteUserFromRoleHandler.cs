using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Store.MediatR.Command;
using Store.Models.User;

namespace Store.MediatR.Handler
{
    public class DeleteUserFromRoleHandler : IRequestHandler<DeleteUserFromRoleCommand, List<UserModel>>
    {
        private readonly UserManager<UserModel> _userManager;

        public DeleteUserFromRoleHandler(UserManager<UserModel> userManager)
        {
            _userManager = userManager;
        }

        public async Task<List<UserModel>> Handle(DeleteUserFromRoleCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            var result = await _userManager.RemoveFromRoleAsync(user, request.RoleName);
            if (result.Succeeded)
            {
                var users = await _userManager.GetUsersInRoleAsync(request.RoleName);
                return new List<UserModel>(users);
            }
            return null;
        }
    }
}
