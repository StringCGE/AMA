using FundacionAMA.Domain.Interfaces.Repositories;

namespace FundacionAMA.Infrastructure.Persistence.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly FundacionAMADbContext _dbContext;

    public UnitOfWork(FundacionAMADbContext dbContext)
        =>
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));


    public async Task SaveChangesAsync()
        =>
        await _dbContext.SaveChangesAsync();
    public void SaveChanges()
        =>
        _dbContext.SaveChanges();

    public void Dispose()
        =>
        _dbContext.Dispose();


}
