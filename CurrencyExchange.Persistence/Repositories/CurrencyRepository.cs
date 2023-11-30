using CurrencyExchange.Domain.Entities;
using CurrencyExchange.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Persistence.Repositories;
public class CurrencyRepository : ICurrencyRepository
{
    private readonly CurrencyExchangeDbContext _context;

    public CurrencyRepository(CurrencyExchangeDbContext context)
    {
        _context = context;
    }

    public async Task<Currency> GetAsync(Expression<Func<Currency, bool>> expression, CancellationToken cancellationToken)
    {
        return await _context.Currencies.FirstOrDefaultAsync(expression, cancellationToken);
    }

    public async Task<IEnumerable<Currency>> ListAsync(Expression<Func<Currency, bool>> expression, CancellationToken cancellationToken)
    {
        return await _context.Currencies.Where(expression).ToListAsync(cancellationToken);
    }

    public async Task<int> CountAsync(Expression<Func<Currency, bool>> expression, CancellationToken cancellationToken)
    {
        return await _context.Currencies.Where(expression).CountAsync(cancellationToken);
    }
    public async Task<Currency> AddAsync(Currency entity, CancellationToken cancellationToken)
    {
        await _context.Currencies.AddAsync(entity, cancellationToken);

        return entity;
    }

    public async Task<Currency> UpdateAsync(Currency entity, CancellationToken cancellationToken)
    {
        _context.Currencies.Update(entity);

        return entity;
    }

    public async Task<bool> DeleteAsync(Currency entity, CancellationToken cancellationToken)
    {
        _context.Currencies.Remove(entity);

        return true;
    }
    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }

}