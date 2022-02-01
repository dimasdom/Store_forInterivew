using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Store.MediatR.Query;
using Store.Models.Context;
using Store.Models.Goods;
using Store.Models.User;

namespace Store.MediatR.Handler
{
    public class GetUserCartHandler : IRequestHandler<GetUserCartQuery, List<GoodsModel>>
    {
        private readonly StoreContext _context;
        private readonly UserManager<UserModel> _userManager;

        public GetUserCartHandler(StoreContext context, UserManager<UserModel> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<List<GoodsModel>> Handle(GetUserCartQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            var userFromContext = await _context.Users.FindAsync(user.Id);
            var userCart = JsonSerializer.Deserialize<List<Guid>>(userFromContext.Cart);
            List<GoodsModel> CartList = new List<GoodsModel>();
            foreach (Guid guid in userCart)
            {
                CartList.Add(_context.Goods.Find(guid));
            }
            return CartList;
        }
    }
}
