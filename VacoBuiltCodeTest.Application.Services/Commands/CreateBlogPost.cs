using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VacoBuiltCodeTest.Application.Services.Exceptions;
using VacoBuiltCodeTest.Core.Contracts;
using VacoBuiltCodeTest.Core.DataModels;
using VacoBuiltCodeTest.Core.Entities;
using VacoBuiltCodeTest.SharedKernel;

namespace VacoBuiltCodeTest.Application.Services.Commands
{
    public static class CreateBlogPost
    {
        public class Request : IRequest<Either<BlogPost, RequestValidationException>>
        {
            [FromBody]
            public string Title { get; set; }
            [FromBody]
            public string Contents { get; set; }
            [FromBody]
            public int CategoryId { get; set; }
        }

        public class Handler : IRequestHandler<Request, Either<BlogPost, RequestValidationException>>
        {
            private readonly IWriteRepository<BlogPostDataModel> writeRepository;

            public Handler(IWriteRepository<BlogPostDataModel> writeRepository)
            {
                this.writeRepository = writeRepository;
            }
            public async Task<Either<BlogPost, RequestValidationException>> Handle(Request request, CancellationToken cancellationToken)
            {
                var validator = new RequestValidator();
                var validationResult = await validator.ValidateAsync(request);

                if (!validationResult.IsValid)
                {
                    return new RequestValidationException(validationResult.Errors.Select(x => x.ErrorMessage));
                }

                try
                {
                    var result = await writeRepository.CreateAsync(new BlogPostDataModel
                    {
                        Title = request.Title,
                        Contents = request.Contents,
                        Timestamp = DateTime.Now,
                        CategoryId = request.CategoryId
                    });


                    // Implement Category updates
                    return new BlogPost(result.Id, result.Title, result.Contents, new Category(2, "General"), result.Timestamp);
                }
                catch (Exception e)
                {
                    // Being explicit about this, because if I had more time I would more than likely implement some sort of notification pattern
                    // in place of simply returning a validation exception or the created entity.
                    throw e;
                }
            }
        }

        public class RequestValidator : AbstractValidator<Request>
        {
            public RequestValidator()
            {
                RuleFor(x => x.Title).NotEmpty();
                RuleFor(x => x.Contents).NotEmpty();
                RuleFor(x => x.CategoryId).NotEmpty();
            }
        }
    }
}
