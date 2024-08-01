using Admin.Models.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Admin.Data.Repositories;

public interface IRepository<TEntity, TContext> where TEntity : BaseEntity where TContext : DbContext
{
    TEntity? Get(int id);
    TEntity? Get(Expression<Func<TEntity, bool>> predicate);
    IQueryable<TEntity> GetAll();
    List<TEntity>? GetAll(Expression<Func<TEntity, bool>> predicate);
    void Delete(int id);
    void Delete(TEntity entity);
    void Update(TEntity entity);
    void Add(TEntity entity);
    void AddRange(IEnumerable<TEntity> entities);
    int SaveChanges();
}
