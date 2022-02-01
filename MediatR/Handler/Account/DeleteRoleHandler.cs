using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Store.MediatR.Command;

namespace Store.MediatR.Handler
{
    public class DeleteRoleHandler : IRequestHandler<DeleteRoleCommand, List<IdentityRole>>
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public DeleteRoleHandler(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<List<IdentityRole>> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            var role = await _roleManager.FindByIdAsync(request.Id);
            var result = await _roleManager.DeleteAsync(role);
            if (result.Succeeded)
            {
                return _roleManager.Roles.ToList();
            }
            return null;
        }
    }
}
