using Hospital.Core.Models.Domain;
using Hospital.Core.Specifications.BaseSpecification;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Repository.Specifications
{
    public class SpecificationEvaluator<TEntity> where TEntity : BaseModel
    {

        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpecifications<TEntity> spec)
        {
            var query = inputQuery; // _context.Set<anyEntities>()

            // _context.Set<Products>().Where(P=>P.id == 10)
            if (spec.Criteira is not null)
                query = query.Where(spec.Criteira);

            // _context.Set<Products>().Where(P=>P.id == 10).OrderBy(s=>s.name)
            if (spec.OrderBy is not null)
                query = query.OrderBy(spec.OrderBy);


            // _context.Set<Products>().Where(P=>P.id == 10).OrderByDescending(s=>s.name)
            if (spec.OrderByDesc is not null)
                query = query.OrderByDescending(spec.OrderByDesc);


            //_context.Products.Include(P=>P.Brand).Include(P=>P.Category).ToListAsync();
            //_context.Products.Where(P => P.Id == id).Include(P => P.Brand).Include(P => P.Category).FirstOrDefaultAsync() as T;
            query = spec.Includes.Aggregate(query, (currentQuery, includeExpression) => currentQuery.Include(includeExpression));



            return query;

        }

    }
}
