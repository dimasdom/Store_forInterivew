using MediatR;
using System.Collections.Generic;
using Store.Models.Goods;

namespace Store.MediatR.Query
{
    public class GetGoodsQuery : IRequest<List<GoodsModel>>
    {
        public GetGoodsQuery()
        {
        }

        public GetGoodsQuery(string categoryId, int minPrice, int maxPrice)
        {
            CategoryId = categoryId;
            MinPrice = minPrice;
            MaxPrice = maxPrice;
        }

        public string CategoryId { get; set; }
        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }
    }
}
