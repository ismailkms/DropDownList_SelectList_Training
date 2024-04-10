using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BusinessLayer.Abstract
{
    public interface IEmployeeService : IGenericService<Employee>
    {
        Task<List<SelectListItem>> selectListDepartmentsAsync();
        Task<List<Employee>> GetEmployeesWithDepartmanAsync();
    }
}
