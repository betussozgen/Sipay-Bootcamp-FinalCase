using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FinalCase.DataAccess.Repository;

public class GenericRepository<Entity> : IGenericRepository<Entity> where Entity : class
{
    private readonly FinalCaseDbContext dbContext;

    public GenericRepository(FinalCaseDbContext dbContext)
    {
        this.dbContext = dbContext;

    }

    public void Save()
    {
        dbContext.SaveChanges();
    }

    public void Delete(Entity entity)
    {
        dbContext.Set<Entity>().Remove(entity);
    }

    public void DeleteById(int id)
    {
        var entity = dbContext.Set<Entity>().Find(id);
        Delete(entity);
    }

    public List<Entity> GetAll()
    {
        return dbContext.Set<Entity>().AsNoTracking().ToList();
    }

    public IQueryable<Entity> GetAllAsQueryable()
    {
        return dbContext.Set<Entity>().AsQueryable();
    }

    public Entity GetById(int id)
    {
        var entity = dbContext.Set<Entity>().Find(id);
        return entity;
    }



    public void Update(Entity entity)
    {
        dbContext.Set<Entity>().Update(entity);
    }

    public IEnumerable<Entity> Where(Expression<Func<Entity, bool>> expression)
    {
        return dbContext.Set<Entity>().Where(expression).AsQueryable();
    }

    public Entity GetByIdWithInclude(int id, params string[] includes)
    {
        var query = dbContext.Set<Entity>().AsQueryable();
        query = includes.Aggregate(query, (currenct, inc) => currenct.Include(inc));
        return query.FirstOrDefault();// todo
    }

    public List<Entity> GetAllWithInclude(params string[] includes)
    {
        var query = dbContext.Set<Entity>().AsQueryable();
        query = includes.Aggregate(query, (currenct, inc) => currenct.Include(inc));
        return query.ToList();
    }

    public IEnumerable<Entity> WhereWithInclude(Expression<Func<Entity, bool>> expression, params string[] includes)
    {
        var query = dbContext.Set<Entity>().AsQueryable();
        query.Where(expression);
        query = includes.Aggregate(query, (currenct, inc) => currenct.Include(inc));
        return query.ToList();
    }

    public void Insert(Entity entity)
    {
        throw new NotImplementedException();
    }
}

