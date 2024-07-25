using Hospital.Core.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Core.Repositories.Interfaces
{
    public interface IUnitOfWork : IAsyncDisposable
    {

        // Create Repo of Any Entity
        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseModel;

        Task<int> CompleteAsync();
    }
}
