using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Store.MediatR.Query;
using Store.Models.Context;
using Store.Models.Order;
using Store.Models.User;

namespace Store.MediatR.Handler
{
    public class GetMyOrdersHandler : IRequestHandler<GetMyOrdersQuery, List<OrderModel>>
    {
        private readonly UserManager<UserModel> _userManager;
        private readonly StoreContext _context;

        public GetMyOrdersHandler(UserManager<UserModel> userManager, StoreContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<List<OrderModel>> Handle(GetMyOrdersQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            var UsersOrders = _context.Orders.Where(x => x.UserId == Guid.Parse(user.Id)).ToList();
            return UsersOrders;
        }
    }
}
