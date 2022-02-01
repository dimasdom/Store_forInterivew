using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Store.MediatR.Query;
using Store.Models.Context;
using Store.Models.Goods;

namespace Store.MediatR.Handler
{
    public class GetGoodsWithParamsHandler : IRequestHandler<GetGoodsWithParamsQuery, List<GoodsModel>>
    {
        private readonly StoreContext _context;

        public GetGoodsWithParamsHandler(StoreContext context)
        {
            _context = context;
        }

        public async Task<List<GoodsModel>> Handle(GetGoodsWithParamsQuery request, CancellationToken cancellationToken)
        {
            if (request.CategoryId != "feebf306-793f-4525-c992-08d93175e7fb")
            {
                if (request.MaxPrice != null || request.MinPrice != null)
                {
                    if (request.MaxPrice != null && request.MinPrice != null)
                    {
                        return _context.Goods.Where(x => x.CategoryId == Guid.Parse(request.CategoryId) && x.Price < Int32.Parse(request.MaxPrice) && x.Price > Int32.Parse(request.MinPrice)).ToList();
                    }
                    if (request.MaxPrice != null)
                    {
                        return _context.Goods.Where(x => x.CategoryId == Guid.Parse(request.CategoryId) && x.Price < Int32.Parse(request.MaxPrice)).ToList();
                    }
                    if (request.MinPrice != null)
                    {
                        return _context.Goods.Where(x => x.CategoryId == Guid.Parse(request.CategoryId) && x.Price < Int32.Parse(request.MinPrice)).ToList();
                    }

                }
                return _context.Goods.Where(x => x.CategoryId == Guid.Parse(request.CategoryId)).ToList();
            }
            if (request.MaxPrice != null || request.MinPrice != null)
            {
                if (request.MaxPrice != null && request.MinPrice != null)
                {
                    return _context.Goods.Where(x => x.Price < Int32.Parse(request.MaxPrice) && x.Price > Int32.Parse(request.MinPrice)).ToList();
                }
                if (request.MaxPrice != null)
                {
                    return _context.Goods.Where(x => x.Price < Int32.Parse(request.MaxPrice)).ToList();
                }
                if (request.MinPrice != null)
                {
                    return _context.Goods.Where(x => x.Price > Int32.Parse(request.MinPrice)).ToList();
                }

            }
            return _context.Goods.ToList();
        }
    }
}
