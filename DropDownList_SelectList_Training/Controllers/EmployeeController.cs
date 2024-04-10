using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace DropDownList_SelectList_Training.Controllers
{
    public class EmployeeController : Controller
    {
        IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task<IActionResult> Index()
        {
            List<Employee> employees = await _employeeService.GetEmployeesWithDepartmanAsync();
            return View(employees);
        }

        [HttpGet]
        public async Task<IActionResult> AddEmployee()
        {
            ViewBag.Departments = await _employeeService.selectListDepartmentsAsync();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddEmployee(Employee employee)
        {
            try
            {
                await _employeeService.InsertAsync(employee);
                return RedirectToAction(nameof(Index), nameof(Employee));
            }
            catch(Exception ex)
            {
                ViewBag.Exception = $"Çalışan eklerken bir hata oluştu!!! Hata: {ex.Message}";
                ViewBag.Departments = await _employeeService.selectListDepartmentsAsync();
                return View(employee);
            }
            
        }

        public async Task<IActionResult> DeleteEmployee(int id)
        {
            Employee employee = await _employeeService.GetByIdAsync(id);
            if (employee != null)
            {
                await _employeeService.DeleteAsync(employee);
            }
            return RedirectToAction(nameof(Index), nameof(Employee));
        }

        [HttpGet]
        public async Task<IActionResult> UpdateEmployee(int id)
        {
            Employee employee = await _employeeService.GetByIdAsync(id);
            if (employee != null)
            {
                ViewBag.Departments = await _employeeService.selectListDepartmentsAsync();
                return View(employee);
            }
            return RedirectToAction(nameof(Index), nameof(Employee));

        }
        [HttpPost]
        public async Task<IActionResult> UpdateEmployee(Employee employee)
        {
            try
            {
                await _employeeService.UpdateAsync(employee);
                return RedirectToAction(nameof(Index), nameof(Employee));
            }
            catch (Exception ex)
            {
                ViewBag.Exception = $"Çalışan düzenlerken bir hata oluştu!!! Hata: {ex.Message}";
                ViewBag.Departments = await _employeeService.selectListDepartmentsAsync();
                return View(employee);
            }
            
        }
    }
}
