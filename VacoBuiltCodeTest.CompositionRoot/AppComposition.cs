using MediatR;
using Microsoft.Extensions.DependencyInjection;
using VacoBuiltCodeTest.Application.Services.Requests;
using VacoBuiltCodeTest.Core.Contracts;
using VacoBuiltCodeTest.Core.DataModels;
using VacoBuiltCodeTest.Infrastructure;
using VacoBuiltCodeTest.Infrastructure.Repositories;

namespace VacoBuiltCodeTest.CompositionRoot
{
    public static class AppComposition
    {
        public static void ComposeApplication(this IServiceCollection services)
        {
            services
                .AddContext()
                .AddRepositories()
                .AddMediator();
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IReadRepository<BlogPostDataModel>, BlogPostRepository>();
            services.AddScoped<IWriteRepository<BlogPostDataModel>, BlogPostRepository>();
            return services;
        }

        private static IServiceCollection AddContext(this IServiceCollection services)
        {
            services.AddScoped<AppDbContext>();
            return services;
        }

        private static IServiceCollection AddMediator(this IServiceCollection services)
        {
            services.AddMediatR(typeof(GetBlogPostsGroupedByCategory).Assembly);

            return services;
        }
    }
}