using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Store.MediatR.Command;
using Store.Models.Context;

namespace Store.MediatR.Handler
{
    public class ChangeOrderStatusHandler : IRequestHandler<ChangeOrderStatusCommand, bool>
    {
        private readonly StoreContext _context;

        public ChangeOrderStatusHandler(StoreContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(ChangeOrderStatusCommand request, CancellationToken cancellationToken)
        {
            var Order = await _context.Orders.FindAsync(request.OrderId);
            Order.Status = request.NewStatus;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
