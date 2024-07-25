using Hospital.Core.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Core.Specifications.BaseSpecification
{
    public interface ISpecifications<T> where T : BaseModel 
    {

        // From of Query

        // Where
        public Expression<Func<T, bool>> Criteira { get; set; }

        // Incl
        public List<Expression<Func<T, object>>> Includes { get; set; }


        public Expression<Func<T, object>> OrderBy { get; set; }

        public Expression<Func<T, object>> OrderByDesc { get; set; }


        public int Skip { get; set; }
        public int Take { get; set; }

        public bool IsPagiantionEnalbed { get; set; }
    }
}
