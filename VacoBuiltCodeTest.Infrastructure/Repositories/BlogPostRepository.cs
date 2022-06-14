using VacoBuiltCodeTest.Core.Contracts;
using VacoBuiltCodeTest.Core.DataModels;

namespace VacoBuiltCodeTest.Infrastructure.Repositories
{
    public sealed class BlogPostRepository : IReadRepository<BlogPostDataModel>, IWriteRepository<BlogPostDataModel>
    {
        private static HashSet<BlogPostDataModel> blogPosts = new HashSet<BlogPostDataModel>
            {
                new BlogPostDataModel
                {
                    Id = 1,
                    Title = "Test blog",
                    Contents = "This is a great post.",
                    Timestamp = DateTime.Now,
                    Category = new CategoryDataModel
                    {
                        Id = 1,
                        Name = "Technology"
                    }
                }
        };



        public Task<BlogPostDataModel> CreateAsync(BlogPostDataModel value)
        {
            value.Id = blogPosts.OrderByDescending(x => x.Id).FirstOrDefault()?.Id ?? 1;
            blogPosts.Add(value);
            return Task.FromResult(value);
        }

        public Task<BlogPostDataModel> UpdateAsync(BlogPostDataModel value)
        {
            var targetPost = blogPosts.FirstOrDefault(x => x.Id == value.Id);

            if(targetPost == null)
            {
                return null;
            }

            targetPost.Title = value.Title;
            targetPost.Contents = value.Contents;
            targetPost.CategoryId = value.CategoryId;

            return Task.FromResult(targetPost);
        }

        Task<IQueryable<BlogPostDataModel>> IReadRepository<BlogPostDataModel>.GetAll()
        {
            return Task.FromResult(blogPosts.AsQueryable());
        }
    }
}
