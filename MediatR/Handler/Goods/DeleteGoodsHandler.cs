using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Store.MediatR.Command;
using Store.Models.Context;

namespace Store.MediatR.Handler
{
    public class DeleteGoodsHandler : IRequestHandler<DeleteGoodsCommand, bool>
    {
        private readonly StoreContext _context;

        public DeleteGoodsHandler(StoreContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteGoodsCommand request, CancellationToken cancellationToken)
        {
            var GoodsToRemove = await _context.Goods.FindAsync(request.Id);
            _context.Goods.Remove(GoodsToRemove);
            _context.SaveChanges();
            return true;
        }
    }
}
