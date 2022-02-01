using MediatR;
using System.Collections.Generic;
using Store.Models.Order;

namespace Store.MediatR.Query
{
    public class GetOrdersQuery : IRequest<List<OrderModel>>
    {

    }
}
