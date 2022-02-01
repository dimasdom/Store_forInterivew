using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Store.Models.Goods;
using Store.Models.Order;
using Store.Models.User;

namespace Store.Models.Context
{
    public class StoreContext : IdentityDbContext<UserModel>
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
        }

        public DbSet<GoodsModel> Goods { get; set; }
        public DbSet<OrderModel> Orders { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<CommentModel> Comments { get; set; }
    }
}
