using System.Collections.Generic;
using Store.Models.Goods;
using Store.Models.Order;

namespace Store.Models.DTOs
{
    public class OrderDetailsModel
    {
        public OrderDetailsModel(List<GoodsModel> goods, OrderModel orderDetails)
        {
            Goods = goods;
            OrderDetails = orderDetails;
        }

        public List<GoodsModel> Goods { get; set; }
        public OrderModel OrderDetails { get; set; }
    }
}
