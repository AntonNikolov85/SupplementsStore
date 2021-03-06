﻿namespace Store.Services.Common
{
    using Data.Common;
    using Models.EntityModels.Common;
    using System;
    using System.Data.Entity.Infrastructure;
    using System.Linq;

    public abstract class BaseDataService<T> : IBaseDataService<T>
        where T : class, IDeletableEntity, IAuditInfo
    {
        public BaseDataService(IDbRepository<T> dataSet)
        {
            this.Data = dataSet;
        }

        protected IDbRepository<T> Data { get; set; }

        public virtual void Add(T item)
        {
            this.Data.Add(item);
            this.Data.Save();
        }

        public virtual void Delete(object id)
        {
            var entity = this.Data.GetById(id);
            if (entity == null)
            {
                throw new InvalidOperationException("No entity with provided id found.");
            }

            this.Data.Delete(entity);
            this.Data.Save();
        }

        public virtual void Edit(T item)
        {
            this.Data.Edit(item);
            this.Data.Save();
        }

        public virtual IQueryable<T> GetAll()
        {
            return this.Data.All();
        }

        public virtual T GetById(object id)
        {
            return this.Data.GetById(id);
        }

        public virtual void Save()
        {
            this.Data.Save();
        }

        public void Dispose()
        {
            this.Data.Dispose();
        }

        public virtual DbEntityEntry<T> Entry(T entity)
        {
            return this.Data.Entry(entity);
        }
    }
}
