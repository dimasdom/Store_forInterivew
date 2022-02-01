using MediatR;
using System.Collections.Generic;
using Store.Models.Goods;

namespace Store.MediatR.Query
{
    public class GetUserCartQuery : IRequest<List<GoodsModel>>
    {
        public GetUserCartQuery(string userName)
        {
            UserName = userName;
        }

        public string UserName { get; set; }
    }
}
