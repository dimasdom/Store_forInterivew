using MediatR;
using System;
using System.Collections.Generic;
using Store.Models.Goods;

namespace Store.MediatR.Query
{
    public class GetCommentsQuery : IRequest<List<CommentModel>>
    {
        public GetCommentsQuery(Guid goodsId)
        {
            GoodsId = goodsId;
        }

        public Guid GoodsId { get; set; }
    }
}
