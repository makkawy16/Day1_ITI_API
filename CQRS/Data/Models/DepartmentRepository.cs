using CQRS.Data.Context;
using CQRS.Repositories;

namespace CQRS.Data.Models
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
