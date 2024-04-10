using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class DepartmentManager : IDepartmentService
    {
        IDepartmentDal _departmentDal;

        public DepartmentManager(IDepartmentDal departmentDal)
        {
            _departmentDal = departmentDal;
        }

        public async Task DeleteAsync(Department item)
        {
            await _departmentDal.DeleteAsync(item);
        }

        public async Task<List<Department>> GetAllAsync()
        {
            return await _departmentDal.GetAllAsync();
        }

        public async Task<Department> GetByIdAsync(int id)
        {
            return await _departmentDal.GetByIdAsync(id);
        }

        public async Task InsertAsync(Department item)
        {
            await _departmentDal.InsertAsync(item);
        }

        public async Task UpdateAsync(Department item)
        {
            await _departmentDal.UpdateAsync(item);
        }
    }
}
