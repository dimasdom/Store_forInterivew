using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Store.MediatR.Query;
using Store.Models.Context;
using Store.Models.Goods;

namespace Store.MediatR.Handler
{
    public class GetGoodsHandler : IRequestHandler<GetGoodsQuery, List<GoodsModel>>
    {
        private readonly StoreContext _context;

        public GetGoodsHandler(StoreContext context)
        {
            _context = context;
        }

        public async Task<List<GoodsModel>> Handle(GetGoodsQuery request, CancellationToken cancellationToken)
        {

            return _context.Goods.ToList();
        }
    }
}
