using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Store.MediatR.Command;
using Store.Models.Context;
using Store.Models.Goods;

namespace Store.MediatR.Handler
{
    public class EditGoodsHandler : IRequestHandler<EditGoodsCommand, GoodsModel>
    {
        private readonly StoreContext _context;

        public EditGoodsHandler(StoreContext context)
        {
            _context = context;
        }

        public async Task<GoodsModel> Handle(EditGoodsCommand request, CancellationToken cancellationToken)
        {
            var oldGoods = await _context.Goods.FindAsync(request.NewGoods.Id);
            request.NewGoods.Id = oldGoods.Id;
            _context.Goods.Remove(oldGoods);
            _context.Goods.Add(request.NewGoods);
            await _context.SaveChangesAsync();
            return request.NewGoods;
        }
    }
}
