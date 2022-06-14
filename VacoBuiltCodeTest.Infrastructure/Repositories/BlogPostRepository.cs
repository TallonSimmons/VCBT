using VacoBuiltCodeTest.Core.Contracts;
using VacoBuiltCodeTest.Core.DataModels;

namespace VacoBuiltCodeTest.Infrastructure.Repositories
{
    public sealed class BlogPostRepository : IReadRepository<BlogPostDataModel>
    {
        private readonly AppDbContext context;

        public BlogPostRepository(AppDbContext context)
        {
            this.context = context;
        }
        Task<IQueryable<BlogPostDataModel>> IReadRepository<BlogPostDataModel>.GetAll()
        {
            return Task.FromResult(new List<BlogPostDataModel>
            {
                new BlogPostDataModel
                {
                    Id = Guid.NewGuid(),
                    Title = "Test blog",
                    Contents = "This is a great post.",
                    Timestamp = DateTimeOffset.Now,
                    Category = new CategoryDataModel
                    {
                        Id = Guid.NewGuid(),
                        Name = "Technology"
                    }
                }
            }.AsQueryable());
        }
    }
}
