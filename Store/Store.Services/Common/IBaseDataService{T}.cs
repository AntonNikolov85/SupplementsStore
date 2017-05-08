namespace Store.Services.Common
{
    using Models.EntityModels.Common;
    using System.Linq;
    using System.Data.Entity.Infrastructure;

    public interface IBaseDataService<T>
        where T : class, IDeletableEntity, IAuditInfo
    {
        void Add(T item);

        void Delete(object id);

        void Edit(T item);

        IQueryable<T> GetAll();

        T GetById(object id);

        void Save();

        void Dispose();

        DbEntityEntry<T> Entry(T entity);
    }
}
