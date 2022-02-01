using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Store.MediatR.Query;
using Store.Models.User;

namespace Store.MediatR.Handler
{
    public class GetUsersInRoleHandler : IRequestHandler<GetUsersInRoleQuery, List<UserModel>>
    {
        private readonly UserManager<UserModel> _userManager;

        public GetUsersInRoleHandler(UserManager<UserModel> userManager)
        {
            _userManager = userManager;
        }

        public async Task<List<UserModel>> Handle(GetUsersInRoleQuery request, CancellationToken cancellationToken)
        {
            var users = await _userManager.GetUsersInRoleAsync(request.RoleName);
            return new List<UserModel>(users);
        }
    }
}
