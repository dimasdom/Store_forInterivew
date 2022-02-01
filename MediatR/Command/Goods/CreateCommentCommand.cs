using MediatR;
using System;

namespace Store.MediatR.Command
{
    public class CreateCommentCommand : IRequest<bool>
    {
        public CreateCommentCommand(string userName, Guid goodsId, string commentText)
        {
            UserName = userName;
            GoodsId = goodsId;
            CommentText = commentText;
        }

        public string UserName { get; set; }
        public Guid GoodsId { get; set; }
        public string CommentText { get; set; }
    }
}
