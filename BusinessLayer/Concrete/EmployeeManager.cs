using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BusinessLayer.Concrete
{
    public class EmployeeManager : IEmployeeService
    {
        IEmployeeDal _employeeDal;

        public EmployeeManager(IEmployeeDal employeeDal)
        {
            _employeeDal = employeeDal;
        }

        public async Task DeleteAsync(Employee item)
        {
            await _employeeDal.DeleteAsync(item);
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            return await _employeeDal.GetAllAsync();
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            return await _employeeDal.GetByIdAsync(id);
        }

        public async Task InsertAsync(Employee item)
        {
            await _employeeDal.InsertAsync(item);
        }

        public async Task UpdateAsync(Employee item)
        {
            await _employeeDal.UpdateAsync(item);
        }

        public async Task<List<SelectListItem>> selectListDepartmentsAsync()
        {
            return await _employeeDal.selectListDepartmentsAsync();
        }

        public async Task<List<Employee>> GetEmployeesWithDepartmanAsync()
        {
            return await _employeeDal.GetEmployeesWithDepartmanAsync();
        }
    }
}
