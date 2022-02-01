using MediatR;
using Store.Models.Goods;

namespace Store.MediatR.Command
{
    public class CreateGoodsCommand : IRequest<bool>
    {
        public CreateGoodsCommand(GoodsModel goods)
        {
            Goods = goods;
        }

        public GoodsModel Goods { get; set; }
    }
}
