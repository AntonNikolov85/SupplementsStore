namespace Store.Data.Common
{
    using System.Linq;
    using Models.EntityModels.Common;
    using System.Data.Entity.Infrastructure;

    public interface IDbRepository<T>
        where T : class, IAuditInfo, IDeletableEntity
    {
        IQueryable<T> All();

        IQueryable<T> AllWithDeleted();

        T GetById(object id);

        void Add(T entity);

        void Delete(T entity);

        void Edit(T entity);

        void HardDelete(T entity);

        void Save();

        void Dispose();

        DbEntityEntry<T> Entry(T entity);
    }
}
