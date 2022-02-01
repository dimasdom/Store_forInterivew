using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Store.MediatR.Command;
using Store.Models.Context;

namespace Store.MediatR.Handler
{
    public class CreateGoodsHandler : IRequestHandler<CreateGoodsCommand, bool>
    {
        private readonly StoreContext _context;

        public CreateGoodsHandler(StoreContext context)
        {
            _context = context;
        }

        public Task<bool> Handle(CreateGoodsCommand request, CancellationToken cancellationToken)
        {
            _context.Goods.Add(request.Goods);
            _context.SaveChanges();
            return Task.FromResult(true);
        }
    }
}
