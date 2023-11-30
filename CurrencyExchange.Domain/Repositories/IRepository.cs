using System.Linq.Expressions;

namespace CurrencyExchange.Domain.Repositories;
public interface IRepository<T> where T : class
{
    public Task SaveChangesAsync(CancellationToken cancellationToken = default);

    public Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);

    public Task<T> UpdateAsync(T entity, CancellationToken cancellationToken = default);

    public Task<bool> DeleteAsync(T entity, CancellationToken cancellationToken = default);

    public Task<T> GetAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default);

    public Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default);
    public Task<int> CountAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default);
}
