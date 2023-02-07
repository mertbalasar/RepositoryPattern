using RepositoryPattern.Application.Commons.Abstractions.Data.Commons;
using RepositoryPattern.Application.Commons.Abstractions.Data.ContextRepositories;
using RepositoryPattern.Infrastructure.Persistence.ContextRepositories;
using RepositoryPattern.Infrastructure.Persistence.UnitOfWork;
using RepositoryPattern.Infrastructure.Persistence;

namespace RepositoryPattern.Presentation.DependencyInjection
{
    public static class DependencyInjection
    {
        public static void AddDatabase(this IServiceCollection services)
        {
            services.AddTransient(typeof(IMainContextRepository<>), typeof(MainContextRepository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
