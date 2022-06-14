using MediatR;
using VacoBuiltCodeTest.Core.Contracts;
using VacoBuiltCodeTest.Core.DataModels;
using VacoBuiltCodeTest.Core.Entities;

namespace VacoBuiltCodeTest.Application.Services.Queries
{
    public static class GetBlogPostsOrderedByTimestamp
    {
        public sealed class Request : IRequest<IEnumerable<BlogPost>>
        {
        }

        internal sealed class Handler : IRequestHandler<Request, IEnumerable<BlogPost>>
        {
            private readonly IReadRepository<BlogPostDataModel> blogPostRepository;

            public Handler(IReadRepository<BlogPostDataModel> blogPostRepository)
            {
                this.blogPostRepository = blogPostRepository;
            }

            public async Task<IEnumerable<BlogPost>> Handle(Request request, CancellationToken cancellationToken)
            {
                var orderedBlogPosts = (await blogPostRepository.GetAll())?.OrderBy(x => x.Timestamp);

                if (orderedBlogPosts == null || !orderedBlogPosts.Any())
                {
                    return new List<BlogPost>();
                }

                return orderedBlogPosts.Select(x => new BlogPost(
                    x.Id,
                    x.Title,
                    x.Contents,
                    new Category(
                        x.Category.Id,
                        x.Category.Name
                        ),
                    x.Timestamp));
            }
        }
    }
}
