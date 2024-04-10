using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework
{
    public class EfDepartmentRepository : GenericRepository<Department>, IDepartmentDal
    {
        public EfDepartmentRepository(DropDownListDbContext context) : base(context)
        {
        }

    }
}
