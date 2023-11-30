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
public class UserRepository : IUserRepository
{
    private readonly CurrencyExchangeDbContext _context;

    public UserRepository(CurrencyExchangeDbContext context)
    {
        _context = context;
    }

    public async Task<User> GetAsync(Expression<Func<User, bool>> expression, CancellationToken cancellationToken)
    {
        return await _context.Users.Include(x => x.Accounts).FirstOrDefaultAsync(expression, cancellationToken);
    }

    public async Task<IEnumerable<User>> ListAsync(Expression<Func<User, bool>> expression, CancellationToken cancellationToken)
    {
        return await _context.Users.Where(expression).ToListAsync(cancellationToken);
    }

    public async Task<int> CountAsync(Expression<Func<User, bool>> expression, CancellationToken cancellationToken)
    {
        return await _context.Users.Where(expression).CountAsync(cancellationToken);
    }
    public async Task<User> AddAsync(User entity, CancellationToken cancellationToken)
    {
        await _context.Users.AddAsync(entity, cancellationToken);

        return entity;
    }

    public async Task<User> UpdateAsync(User entity, CancellationToken cancellationToken)
    {
        _context.Users.Update(entity);

        return entity;
    }

    public async Task<bool> DeleteAsync(User entity, CancellationToken cancellationToken)
    {
        _context.Users.Remove(entity);

        return true;
    }
    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }

}

