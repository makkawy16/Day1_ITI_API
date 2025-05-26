using CQRS.TransientService;

namespace CQRS.Repositories.Intefrafces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        List<TEntity> GetAll();
        TEntity? GetById(int id);
        void Add(TEntity Model);
        void Update(TEntity Model);
        void Delete(TEntity Model);
        void DeleteById(int id);
        void SaveChanges();
    }
}
