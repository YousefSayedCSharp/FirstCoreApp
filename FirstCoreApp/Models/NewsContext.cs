
using Microsoft.EntityFrameworkCore;

namespace FirstCoreApp.Models
{
    public class NewsContext : DbContext
    {
        public NewsContext(DbContextOptions<NewsContext> options)
            : base(options)
        {
        }

        public DbSet<News> News { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Teammember> Teammembers { get; set; }
        public DbSet<ContactUs> Contacts { get; set; }
    }

}
