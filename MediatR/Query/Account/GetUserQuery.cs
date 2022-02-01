using MediatR;
using Store.Models.User;

namespace Store.MediatR.Query
{
    public class GetUserQuery : IRequest<UserModel>
    {
        public GetUserQuery(string userName)
        {
            UserName = userName;
        }

        public string UserName { get; set; }
    }
}
