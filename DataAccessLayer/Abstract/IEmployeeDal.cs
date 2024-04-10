using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DataAccessLayer.Abstract
{
    public interface IEmployeeDal : IGenericDal<Employee>
    {
        Task<List<SelectListItem>> selectListDepartmentsAsync();
        Task<List<Employee>> GetEmployeesWithDepartmanAsync();
    }
}
