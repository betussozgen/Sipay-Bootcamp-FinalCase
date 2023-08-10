﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FinalCase.DataAccess.Repository;


public interface IGenericRepository<Entity> where Entity : class
{
    void Save();
    Entity GetById(int id);
    Entity GetByIdWithInclude(int id, params string[] includes);
    void Insert(Entity entity);
    void Update(Entity entity);
    void Delete(Entity entity);
    void DeleteById(int id);
    List<Entity> GetAll();
    List<Entity> GetAllWithInclude(params string[] includes);
    IEnumerable<Entity> Where(Expression<Func<Entity, bool>> expression);
    IEnumerable<Entity> WhereWithInclude(Expression<Func<Entity, bool>> expression, params string[] includes);
    IQueryable<Entity> GetAllAsQueryable();
}

