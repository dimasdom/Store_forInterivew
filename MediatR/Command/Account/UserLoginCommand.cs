using MediatR;
using Store.Models.DTOs;
using Store.Models.User;

namespace Store.MediatR.Command
{
    public class UserLoginCommand : IRequest<UserModel>
    {
        public UserLoginCommand(UserLoginDTOs user)
        {
            User = user;
        }

        public UserLoginDTOs User { get; set; }
    }
}
