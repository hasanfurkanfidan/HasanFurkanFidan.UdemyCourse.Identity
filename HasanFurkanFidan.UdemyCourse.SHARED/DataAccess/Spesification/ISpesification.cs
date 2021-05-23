using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HasanFurkanFidan.UdemyCourse.SHARED.DataAccess.Spesification
{
    public interface ISpesification<T>
    {
        public Expression<Func<T, bool>> Criteria { get; }
        List<Expression<Func<T, object>>> Includes { get; }

    }
}
