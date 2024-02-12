using Ardalis.SharedKernel;
using Ardalis.Specification.EntityFrameworkCore;
using Training.IntegrationTest.Infrastructure.Data;

namespace Training.IntegrationTest.Infrastructure;

public class EfRepository<T>(AppDbContext dbContext) : RepositoryBase<T>(dbContext), IReadRepository<T>, IRepository<T>
    where T : class, IAggregateRoot;