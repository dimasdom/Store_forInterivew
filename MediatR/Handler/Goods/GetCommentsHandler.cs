using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Store.MediatR.Query;
using Store.Models.Context;
using Store.Models.Goods;

namespace Store.MediatR.Handler
{
    public class GetCommentsHandler : IRequestHandler<GetCommentsQuery, List<CommentModel>>
    {
        private readonly StoreContext _context;

        public GetCommentsHandler(StoreContext context)
        {
            _context = context;
        }

        public async Task<List<CommentModel>> Handle(GetCommentsQuery request, CancellationToken cancellationToken)
        {
            var comments = _context.Comments.Where(x => x.GoodsId == request.GoodsId).ToList();
            return comments;
        }
    }
}
