using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Store.MediatR.Query;
using Store.Models.Context;
using Store.Models.Goods;

namespace Store.MediatR.Handler
{
    public class GetCategoriesHandler : IRequestHandler<GetCategoriesQuery, List<CategoryModel>>
    {
        private readonly StoreContext _context;

        public GetCategoriesHandler(StoreContext context)
        {
            _context = context;
        }

        public async Task<List<CategoryModel>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = _context.Categories.ToList();
            return categories;
        }
    }
}
