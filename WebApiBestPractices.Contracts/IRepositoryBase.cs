using System;
using System.Linq;
using System.Linq.Expressions;

namespace WebApiBestPractices.Contracts
{
    public interface IRepositoryBase<TModel> where TModel : class
    {
        IQueryable<TModel> FindAll();
        IQueryable<TModel> FindByCondition(Expression<Func<TModel, bool>> expression);

        void Create(TModel model);
        void Update(TModel model);
        void Delete(TModel model);

    }
}
