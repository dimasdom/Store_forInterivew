using MediatR;
using System.Collections.Generic;
using Store.Models.Order;

namespace Store.MediatR.Query
{
    public class GetMyOrdersQuery : IRequest<List<OrderModel>>
    {
        public GetMyOrdersQuery(string userName)
        {
            UserName = userName;
        }

        public string UserName { get; set; }
    }
}
