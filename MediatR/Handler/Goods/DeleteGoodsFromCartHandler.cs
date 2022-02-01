using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Store.MediatR.Command;
using Store.Models.Context;
using Store.Models.User;

namespace Store.MediatR.Handler
{
    public class DeleteGoodsFromCartHandler : IRequestHandler<DeleteGoodsFromCartCommand, bool>
    {
        private readonly StoreContext _context;
        private readonly UserManager<UserModel> _userManager;

        public DeleteGoodsFromCartHandler(StoreContext context, UserManager<UserModel> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<bool> Handle(DeleteGoodsFromCartCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);

            var userFromContext = await _context.Users.FindAsync(user.Id);
            List<string> newUserCart = JsonSerializer.Deserialize<List<string>>(userFromContext.Cart);
            newUserCart.Remove(request.GoodsId);
            userFromContext.Cart = JsonSerializer.Serialize(newUserCart);
            var result = await _context.SaveChangesAsync();
            return true;
        }
    }
}
