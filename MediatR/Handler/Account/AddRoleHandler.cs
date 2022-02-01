using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Store.MediatR.Command;

namespace Store.MediatR.Handler
{
    public class AddRoleHandler : IRequestHandler<AddRoleCommand, List<IdentityRole>>
    {


        private readonly RoleManager<IdentityRole> _roleManager;

        public AddRoleHandler(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<List<IdentityRole>> Handle(AddRoleCommand request, CancellationToken cancellationToken)
        {
            var result = await _roleManager.CreateAsync(new IdentityRole(request.RoleName));

            if (result.Succeeded)
            {
                var rolesList = _roleManager.Roles.ToList();
                return rolesList;
            }
            return null;
        }


    }
}
