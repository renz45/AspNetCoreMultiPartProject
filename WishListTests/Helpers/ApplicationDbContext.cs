using Microsoft.EntityFrameworkCore;

namespace WishListTests.Helpers
{
    public class ApplicationDbContext : DbContext
    {
        DbSet<Item> Items { get; set; }
    }
}
