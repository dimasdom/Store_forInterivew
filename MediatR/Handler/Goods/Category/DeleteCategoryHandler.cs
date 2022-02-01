using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Store.MediatR.Command;
using Store.Models.Context;
using Store.Models.Goods;

namespace Store.MediatR.Handler
{
    public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryCommand, bool>
    {
        private readonly StoreContext _context;

        public DeleteCategoryHandler(StoreContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var categoryToDelete = _context.Categories.Find(Guid.Parse(request.Id));
            _context.Categories.Remove(categoryToDelete);
            var GoodsWithCategory = _context.Goods.Where(x => x.CategoryId == Guid.Parse(request.Id)).ToList();
            foreach (GoodsModel goods in GoodsWithCategory)
            {
                var newgoods = _context.Goods.Find(goods.Id);
                newgoods.CategoryId = Guid.Parse("feebf306-793f-4525-c992-08d93175e7fb");
                _context.SaveChanges();
            }
            _context.SaveChanges();
            return true;
        }
    }
}
