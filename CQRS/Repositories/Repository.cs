using CQRS.Data.Context;
using CQRS.Repositories.Intefrafces;

namespace CQRS.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly AppDbContext _appDbContext;

        public Repository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Add(TEntity Model)
        {
            _appDbContext.Set<TEntity>().Add(Model);
        }

        public void Delete(TEntity Model)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int id)
        {
            var model = GetById(id);
            if (model != null) 
            _appDbContext.Set<TEntity>().Remove(model);
        }

        public List<TEntity> GetAll()
        {
            return _appDbContext.Set<TEntity>().AsQueryable().ToList();
        }

        public TEntity? GetById(int id)
        {
            return _appDbContext.Set<TEntity>().Find(id);
        }

        public void SaveChanges()
        {
            _appDbContext.SaveChanges();
        }

        public void Update(TEntity Model)
        {
            throw new NotImplementedException();
        }
    }
}
