using VacoBuiltCodeTest.Core.Contracts;
using VacoBuiltCodeTest.Core.DataModels;

namespace VacoBuiltCodeTest.Infrastructure.Repositories
{
    public sealed class BlogPostRepository : IReadRepository<BlogPostDataModel>, IWriteRepository<BlogPostDataModel>
    {
        private HashSet<BlogPostDataModel> blogPosts = new HashSet<BlogPostDataModel>
            {
                new BlogPostDataModel
                {
                    Id = Guid.NewGuid(),
                    Title = "Test blog",
                    Contents = "This is a great post.",
                    Timestamp = DateTime.Now,
                    Category = new CategoryDataModel
                    {
                        Id = Guid.NewGuid(),
                        Name = "Technology"
                    }
                }
        };



        public Task<BlogPostDataModel> SaveAsync(BlogPostDataModel value)
        {
            blogPosts.Add(value);
            return Task.FromResult(value);
        }

        Task<IQueryable<BlogPostDataModel>> IReadRepository<BlogPostDataModel>.GetAll()
        {
            return Task.FromResult(blogPosts.AsQueryable());
        }
    }
}
