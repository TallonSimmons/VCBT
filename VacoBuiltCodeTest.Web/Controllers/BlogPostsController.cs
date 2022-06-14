using MediatR;
using Microsoft.AspNetCore.Mvc;
using VacoBuiltCodeTest.Application.Services.Requests;

namespace VacoBuiltCodeTest.Web.Controllers
{
    [Route("/api/blogposts")]
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
    }
}
