using Microsoft.EntityFrameworkCore;
using VacoBuiltCodeTest.Core.DataModels;

namespace VacoBuiltCodeTest.Infrastructure
{
    public sealed class AppDbContext : DbContext
    {
        public DbSet<BlogPostDataModel> BlogPosts { get; set; }
        public DbSet<CategoryDataModel> Categories { get; set; }
    }
}
