using MediatR;
using System.Collections.Generic;
using Store.Models.Goods;

namespace Store.MediatR.Query
{
    public class GetCategoriesQuery : IRequest<List<CategoryModel>>
    {

    }
}
