using Hospital.Core.Models.Domain;
using Hospital.Core.Repositories.Interfaces;
using Hospital.Repository.Data.Contexts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Repository.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HospitalDbContext _context;
        private Hashtable _repositories { get; set; }

        public UnitOfWork(HospitalDbContext context)
        {
            _context = context;
            _repositories = new Hashtable();
        }


        public async Task<int> CompleteAsync() => await _context.SaveChangesAsync();


        public ValueTask DisposeAsync() => _context.DisposeAsync();


        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseModel
        {
            var type = typeof(TEntity).Name;
            if (!_repositories.ContainsKey(type))
            {
                var repository = new GenericRepository<TEntity>(_context);
                _repositories.Add(type, repository);
            }
            return _repositories[type] as IGenericRepository<TEntity>;
        }
    }
}
