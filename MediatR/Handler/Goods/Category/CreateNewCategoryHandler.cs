using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Store.MediatR.Command;
using Store.Models.Context;
using Store.Models.Goods;

namespace Store.MediatR.Handler
{
    public class CreateNewCategoryHandler : IRequestHandler<CreateNewCategoryCommand, bool>
    {
        private readonly StoreContext _context;

        public CreateNewCategoryHandler(StoreContext context)
        {
            _context = context;
        }

        public Task<bool> Handle(CreateNewCategoryCommand request, CancellationToken cancellationToken)
        {
            CategoryModel newCategory = new CategoryModel { Name = request.Name };
            _context.Categories.Add(newCategory);
            _context.SaveChanges();
            return Task.FromResult(true);
        }
    }
}
