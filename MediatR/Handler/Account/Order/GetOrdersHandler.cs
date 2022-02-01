using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Store.MediatR.Query;
using Store.Models.Context;
using Store.Models.Order;

namespace WeedStore.MediatR.Handler
{
    public class GetOrdersHandler : IRequestHandler<GetOrdersQuery, List<OrderModel>>
    {
        private readonly StoreContext _context;

        public GetOrdersHandler(StoreContext context)
        {
            _context = context;
        }

        public async Task<List<OrderModel>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {

            var Orders = _context.Orders.ToList();
            return Orders;

        }
    }
}
