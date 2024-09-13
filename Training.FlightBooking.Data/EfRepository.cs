using Ardalis.SharedKernel;
using Ardalis.Specification.EntityFrameworkCore;
using Training.FlightBooking.Data.Data;
using Training.IntegrationTest.Infrastructure.Data;

namespace Training.FlightBooking.Data;

public class EfRepository<T>(AppDbContext dbContext) : RepositoryBase<T>(dbContext), IReadRepository<T>, IRepository<T>
    where T : class, IAggregateRoot;