using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Store.MediatR.Command;
using Store.Models.Context;

namespace Store.MediatR.Handler
{
    public class DeleteCommentHandler : IRequestHandler<DeleteCommentCommand, bool>
    {
        private readonly StoreContext _context;

        public DeleteCommentHandler(StoreContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = await _context.Comments.FindAsync(request.CommentId);
            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
