using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace DropDownList_SelectList_Training.Controllers
{
    public class DepartmentController : Controller
    {
        IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        public async Task<IActionResult> Index()
        {
            List<Department> departments = await _departmentService.GetAllAsync();
            return View(departments);
        }

        [HttpGet]
        public IActionResult AddDepartment()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddDepartment(Department department)
        {
            try
            {
                await _departmentService.InsertAsync(department);
                return RedirectToAction(nameof(Index), nameof(Department));
            }
            catch
            {
                return View(department);
            }
        }

        public async Task<IActionResult> DeleteDepartment(int id)
        {
            Department department = await _departmentService.GetByIdAsync(id);
            if (department != null)
            {
                await _departmentService.DeleteAsync(department);
            }
            return RedirectToAction(nameof(Index), nameof(Department));
        }

        [HttpGet]
        public async Task<IActionResult> UpdateDepartment(int id)
        {
            Department department = await _departmentService.GetByIdAsync(id);
            if (department != null)
            {
                return View(department);
            }
            return RedirectToAction(nameof(Index), nameof(Department));
        }
        [HttpPost]
        public async Task<IActionResult> UpdateDepartment(Department department)
        {
            try
            {
                await _departmentService.UpdateAsync(department);
                return RedirectToAction(nameof(Index), nameof(Department));
            }
            catch
            {
                return View(department);
            }
        }
    }
}
