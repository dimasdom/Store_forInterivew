using MediatR;
using Store.Models.Goods;

namespace Store.MediatR.Command
{
    public class EditGoodsCommand : IRequest<GoodsModel>
    {
        public GoodsModel NewGoods { get; set; }
        public EditGoodsCommand(GoodsModel newGoods)
        {
            NewGoods = newGoods;
        }


    }
}
