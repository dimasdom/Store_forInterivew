using MediatR;

namespace Store.MediatR.Command
{
    public class MakeOrderCommand : IRequest<bool>
    {
        public MakeOrderCommand(string userName, string address)
        {
            UserName = userName;
            Address = address;
        }

        public string UserName { get; set; }
        public string Address { get; set; }
    }
}
