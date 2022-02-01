using MediatR;
using System.Collections.Generic;
using Store.Models.User;

namespace Store.MediatR.Query
{
    public class GetUsersInRoleQuery : IRequest<List<UserModel>>
    {
        public GetUsersInRoleQuery(string roleName)
        {
            RoleName = roleName;
        }

        public string RoleName { get; set; }
    }
}
