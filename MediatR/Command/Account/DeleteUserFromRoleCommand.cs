using MediatR;
using System.Collections.Generic;
using Store.Models.User;

namespace Store.MediatR.Command
{
    public class DeleteUserFromRoleCommand : IRequest<List<UserModel>>
    {
        public DeleteUserFromRoleCommand(string userName, string roleName)
        {
            UserName = userName;
            RoleName = roleName;
        }

        public string UserName { get; set; }
        public string RoleName { get; set; }
    }
}
