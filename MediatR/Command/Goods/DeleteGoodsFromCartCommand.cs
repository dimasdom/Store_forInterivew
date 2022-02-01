using MediatR;

namespace Store.MediatR.Command
{
    public class DeleteGoodsFromCartCommand : IRequest<bool>
    {
        public DeleteGoodsFromCartCommand(string userName, string goodsId)
        {
            UserName = userName;
            GoodsId = goodsId;
        }

        public string UserName { get; set; }
        public string GoodsId { get; set; }
    }
}
