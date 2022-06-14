using MediatR;
using Microsoft.AspNetCore.Mvc;
using VacoBuiltCodeTest.Application.Services.Commands;
using VacoBuiltCodeTest.Application.Services.Queries;

namespace VacoBuiltCodeTest.Web.Controllers
{
    [Route("/post")]
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
            var blogPosts = await mediator.Send(new GetBlogPostsGroupedByCategory.Request());

            if(blogPosts == null || !blogPosts.Any())
            {
                return NotFound();
            } 

            return Ok(blogPosts);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateBlogPost.Request request)
        {
            var result = await mediator.Send(request);
            IActionResult actionResult = StatusCode(500);

            result.Match(
                blogPost => actionResult = Ok(blogPost),
                exception => actionResult = BadRequest(exception.Errors));

            return actionResult;
        }
    }
}
