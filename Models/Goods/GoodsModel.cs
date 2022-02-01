using System;

namespace Store.Models.Goods
{
    public class GoodsModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public Guid CategoryId { get; set; }


    }
}
