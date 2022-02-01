using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Store.MediatR.Query;
using Store.Models.Context;
using Store.Models.Goods;

namespace Store.MediatR.Handler
{
    public class GetSingleGoodsHandler : IRequestHandler<GetSingleGoodsQuery, GoodsModel>
    {
        private readonly StoreContext _context;

        public GetSingleGoodsHandler(StoreContext context)
        {
            _context = context;
        }

        public async Task<GoodsModel> Handle(GetSingleGoodsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Goods.FindAsync(request.Id);
        }
    }
}
