using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Store.MediatR.Command;
using Store.Models.Context;
using Store.Models.Goods;

namespace Store.MediatR.Handler
{
    public class CreateCommentHandler : IRequestHandler<CreateCommentCommand, bool>
    {
        private readonly StoreContext _context;

        public CreateCommentHandler(StoreContext context)
        {
            _context = context;
        }

        public Task<bool> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = new CommentModel { CommentText = request.CommentText, UserName = request.UserName, GoodsId = request.GoodsId, Date = DateTime.Now };
            _context.Comments.Add(comment);
            _context.SaveChanges();
            return Task.FromResult(true);
        }
    }
}
