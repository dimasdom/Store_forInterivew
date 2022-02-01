using System.Collections.Generic;
using Store.Models.Goods;

namespace Store.Models.DTOs
{
    public class ProductModel
    {
        public GoodsModel Goods { get; set; }
        public List<CommentModel> Comments { get; set; }
    }
}
