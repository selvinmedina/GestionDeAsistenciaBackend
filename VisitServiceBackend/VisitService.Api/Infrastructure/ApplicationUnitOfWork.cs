using EntityFramework.Infrastructure.Core.UnitOfWork;

namespace VisitService.Api.Infrastructure
{
    public class ApplicationUnitOfWork : UnitOfWork
    {
        public ApplicationUnitOfWork(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
