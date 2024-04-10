using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework
{
    public class EfEmployeeRepository : GenericRepository<Employee>, IEmployeeDal
    {
        DropDownListDbContext _context;
        public EfEmployeeRepository(DropDownListDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Employee>> GetEmployeesWithDepartmanAsync()
        {
            return await _context.Employees.Include(e => e.Department).ToListAsync();
        }

        public async Task<List<SelectListItem>> selectListDepartmentsAsync()
        {
            return await _context.Departments.Select(d =>
                                        new SelectListItem
                                        {
                                            Text = d.Name,
                                            Value = d.Id.ToString()
                                        }).ToListAsync();
            //SelectListItem,ı Microsoft.AspNetCore.Mvc.Rendering kullanarak çekmeliyiz. System.Mvc kullanmamalıyız.
            //Microsoft.AspNetCore.Mvc.Rendering'i kullanmak için projeye Microsoft.AspNetCore.Mvc.ViewFeatures paketini eklememiz gerekiyor
        }
    }
}
