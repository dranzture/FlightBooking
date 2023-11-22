using Ardalis.SharedKernel;
using Ardalis.Specification.EntityFrameworkCore;
using Training.IntegrationTest.Infrastructure.Data;

namespace Training.IntegrationTest.Infrastructure;

public class EfRepository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T> where T : class, IAggregateRoot
{
    public EfRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}