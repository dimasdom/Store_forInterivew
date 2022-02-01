using MediatR;

namespace Store.MediatR.Command
{
    public class AddToCartCommand : IRequest<bool>
    {
        public AddToCartCommand(string userName, string goodsId)
        {
            UserName = userName;
            GoodsId = goodsId;
        }

        public string UserName { get; set; }
        public string GoodsId { get; set; }
    }
}
