using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using WebApiBestPractices.Contracts;
using WebApiBestPractices.Entities;

namespace WebApiBestPractices.Repositories
{
    public class RepositoryBase<TModel> : IRepositoryBase<TModel> where TModel : class
    {
        protected AppDbContext DbContext { get; set; }

        public RepositoryBase(AppDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public IQueryable<TModel> FindAll()
        {
            return DbContext.Set<TModel>().AsNoTracking();
        }

        public IQueryable<TModel> FindByCondition(Expression<Func<TModel, bool>> expression)
        {
            return DbContext.Set<TModel>().Where(expression).AsNoTracking();
        }

        public void Create(TModel entity)
        {
            DbContext.Set<TModel>().Add(entity);
        }

        public void Update(TModel entity)
        {
            DbContext.Set<TModel>().Update(entity);
        }

        public void Delete(TModel entity)
        {
            DbContext.Set<TModel>().Remove(entity);
        }
    }
}
