﻿
namespace Data.Concrete.Base
{
    #region usings
    using Data.Abstract.Base;
    using Data.Db;
    using Data.Models.Abstract;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    using System.Threading.Tasks;

    #endregion
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepositoryBase<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public TEntity? Get(Expression<Func<TEntity, bool>> filter)
        {
            using (var db = new ThesesContext())
            {
                var result = db.Set<TEntity>().SingleOrDefault(filter);
                return (result == null) ? null : result;
            }
        }

        public  List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var db = new ThesesContext())
            {
                return (filter == null) ? db.Set<TEntity>().ToList(): db.Set<TEntity>().Where(filter).ToList();
            }
        }
    }
}
