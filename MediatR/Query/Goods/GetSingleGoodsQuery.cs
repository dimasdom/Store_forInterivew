using MediatR;
using System;
using Store.Models.Goods;

namespace Store.MediatR.Query
{
    public class GetSingleGoodsQuery : IRequest<GoodsModel>
    {
        public GetSingleGoodsQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
