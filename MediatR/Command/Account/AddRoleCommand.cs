using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Store.MediatR.Command
{
    public class AddRoleCommand : IRequest<List<IdentityRole>>
    {
        public AddRoleCommand(string roleName)
        {
            RoleName = roleName;
        }

        public string RoleName { get; set; }
    }
}
