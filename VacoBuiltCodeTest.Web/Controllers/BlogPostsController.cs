using MediatR;
using Microsoft.AspNetCore.Mvc;
using VacoBuiltCodeTest.Application.Services.Commands;
using VacoBuiltCodeTest.Application.Services.Queries;

namespace VacoBuiltCodeTest.Web.Controllers
{
    [Route("/posts")]
    public class BlogPostsController : Controller
    {
        private readonly IMediator mediator;

        public BlogPostsController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var blogPosts = await mediator.Send(new GetBlogPostsOrderedByTimestamp.Request());

            if (blogPosts == null || !blogPosts.Any())
            {
                return NotFound();
            }

            return Ok(blogPosts);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateBlogPost.Request request)
        {
            var result = await mediator.Send(request);
            IActionResult actionResult = StatusCode(500);

            result.Match(
                blogPost => actionResult = Ok(blogPost),
                exception => actionResult = BadRequest(exception.Errors));

            return actionResult;
        }

        [HttpPut("/posts/{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, string title, string contents, int categoryId)
        {
            // TODO: Fix this hack.
            // Couldn't solve model binding issues in time.
            var result = await mediator.Send(new UpdateBlogPost.Request
            {
                Id = id,
                Title = title,
                Contents = contents,
                CategoryId = categoryId
            });
            IActionResult actionResult = StatusCode(500);

            result.Match(
                blogPost => actionResult = Ok(blogPost),
                exception => actionResult = BadRequest(exception.Errors));

            return actionResult;
        }
    }
}
