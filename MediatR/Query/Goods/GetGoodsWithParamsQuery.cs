using MediatR;
using System.Collections.Generic;
using Store.Models.Goods;

namespace Store.MediatR.Query
{
    public class GetGoodsWithParamsQuery : IRequest<List<GoodsModel>>
    {
        public GetGoodsWithParamsQuery()
        {
            CategoryId = null;
            MinPrice = null;
            MaxPrice = null;
        }

        public GetGoodsWithParamsQuery(string categoryId, string minPrice, string maxPrice)
        {
            CategoryId = categoryId;
            MinPrice = minPrice;
            MaxPrice = maxPrice;
        }

        public string CategoryId { get; set; }
        public string MinPrice { get; set; }
        public string MaxPrice { get; set; }
    }
}

