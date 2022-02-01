using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Store.MediatR.Query;

namespace Store.MediatR.Handler
{
    public class GetRolesHandler : IRequestHandler<GetRolesQuery, List<IdentityRole>>
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public GetRolesHandler(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<List<IdentityRole>> Handle(GetRolesQuery request, CancellationToken cancellationToken)
        {
            var rolesList = _roleManager.Roles.ToList();
            return rolesList;
        }
    }
}
