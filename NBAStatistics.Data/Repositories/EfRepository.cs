﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

using NBAStatistics.Data.Repositories.Contracts;

namespace NBAStatistics.Data.Repositories
{
    public class EfRepository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        private readonly INBAStatisticsContext dbContext;
        private readonly IDbSet<TEntity> dbSet;

        public EfRepository(INBAStatisticsContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException(nameof(dbContext), "Database context cannot be null!");
            }

            this.dbContext = dbContext;
            this.dbSet = this.dbContext.Set<TEntity>();
        }

        public void Add(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                this.Add(entity);
            }
        }

        public void Add(TEntity entity)
        {
            this.ChangeState(entity, EntityState.Added);
        }

        public void Delete(TEntity entity)
        {
            this.ChangeState(entity, EntityState.Deleted);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> filterExpression)
        {
            var result = this.dbSet.Where(filterExpression);
            return result;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return this.dbSet;
        }

        public TEntity GetById(int id)
        {
            var result = this.dbSet.Find(id);
            return result;
        }

        public void Update(TEntity entity)
        {
            this.ChangeState(entity, EntityState.Modified);
        }

        private void ChangeState(TEntity entity, EntityState state)
        {
            var entry = this.dbContext.Entry<TEntity>(entity);
            if (entry.State == EntityState.Detached)
            {
                this.dbSet.Attach((TEntity)entry.Entity);
            }

            entry.State = state;
        }
    }
}
