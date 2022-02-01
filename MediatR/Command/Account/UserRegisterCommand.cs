using MediatR;
using Store.Models.DTOs;
using Store.Models.User;

namespace Store.MediatR.Command
{
    public class UserRegisterCommand : IRequest<UserModel>
    {
        public UserRegisterCommand(UserRegisterDTOs user)
        {
            User = user;
        }

        public UserRegisterDTOs User { get; set; }
    }
}
