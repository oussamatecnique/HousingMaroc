namespace HousingMaroc.Application.Common;

public interface IRepositoryBase<T, TKey> where T: class
{
    Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default);
    ValueTask<T?> FindAsync(TKey key, CancellationToken cancellationToken = default);
    void Add(T newEntity);
    void Update(T newEntity);
    void Remove(T newEntity);
}
