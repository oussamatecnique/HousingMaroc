using HousingMaroc.Application.Common;

namespace HousingMaroc.Infrastructure.Common;

public abstract class RepositoryBase<T, TKey>(DbContext dbContext) : IRepositoryBase<T, TKey> where T : class
{
    protected DbSet<T> DbSet { get; } = dbContext.Set<T>();

    public virtual Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
        => DbSet.ToListAsync(cancellationToken).ContinueWith(task => task.Result.AsEnumerable(), cancellationToken);

    public virtual ValueTask<T?> FindAsync(TKey key, CancellationToken cancellationToken = default)
        => DbSet.FindAsync([key], cancellationToken);

    public virtual void Add(T newEntity) => DbSet.Add(newEntity);

    public virtual void Update(T newEntity) => DbSet.Update(newEntity);

    public virtual void Remove(T newEntity) => DbSet.Remove(newEntity);
}
