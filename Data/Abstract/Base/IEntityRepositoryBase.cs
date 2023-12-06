using Data.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Abstract.Base
{
    public interface IEntityRepositoryBase<TEntity>
        where TEntity : class ,IEntity , new()
    {
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity,bool >> filter = null);
        TEntity Get(Expression<Func<TEntity , bool>> filter);
        
    }
}
