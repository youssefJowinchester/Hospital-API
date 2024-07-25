using Hospital.Core.Models.Domain;
using Hospital.Core.Specifications.BaseSpecification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Core.Repositories.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : BaseModel
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task AddAsync(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);






        // GetAllSpec
        Task<IEnumerable<TEntity>> GetAllWithSpecAsync(ISpecifications<TEntity> spec);
        //GetByIdSpec
        Task<TEntity?> GetwithSpecAsync(ISpecifications<TEntity> spec);
        //GetCountSpec
        Task<int> GetCountAsync(ISpecifications<TEntity> spec);
      
    }
}
