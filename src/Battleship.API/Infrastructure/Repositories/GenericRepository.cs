using System;
using System.Linq.Expressions;
using Battleship.API.Core.Contracts.Repositories;
using Battleship.API.Infrastructure.DbContexts;

namespace Battleship.API.Infrastructure.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly BattleshipDbContext DbContext;

    public GenericRepository(BattleshipDbContext context)
    {
        DbContext = context;
    }

    public void Add(T entity)
    {
        DbContext.Set<T>().Add(entity);
    }

    public void AddRange(IEnumerable<T> entities)
    {
        DbContext.Set<T>().AddRange(entities);
    }

    public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
    {
        return DbContext.Set<T>().Where(expression);
    }

    public IEnumerable<T> GetAll()
    {
        return DbContext.Set<T>().ToList();
    }

    public T? GetById(int id)
    {
        return DbContext.Set<T>().Find(id);
    }

    public void Remove(T entity)
    {
        DbContext.Set<T>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<T> entities)
    {
        DbContext.Set<T>().RemoveRange(entities);
    }
}

