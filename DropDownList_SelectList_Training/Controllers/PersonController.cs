using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DropDownList_SelectList_Training.Controllers
{
    public class PersonController : Controller
    {
        IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        public async Task<IActionResult> Index()
        {
            List<Person> people = await _personService.GetPersonWithCountryAndCityAsync();
            return View(people);
        }

        [HttpGet]
        public async Task<IActionResult> AddPerson()
        {
            ViewBag.Countries = await _personService.selectListCountryAsync();

            //Alternatif
            //ViewBag.Countries = new SelectList(await _personService.Countries, "Id", "Name");
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddPerson(Person person)
        {
            try
            {
                await _personService.InsertAsync(person);
                return RedirectToAction(nameof(Index), nameof(Person));
            }
            catch (Exception ex)
            {
                ViewBag.Exception = $"Kişi eklerken bir hata oluştu!!! Hata: {ex.Message}";
                ViewBag.Countries = await _personService.selectListCountryAsync();
                return View(person);
            }
        }

        public async Task<IActionResult> DeletePerson(int id)
        {
            Person person = await _personService.GetByIdAsync(id);
            if (person != null)
            {
                await _personService.DeleteAsync(person);
            }
            return RedirectToAction(nameof(Index), nameof(Person));
        }

        [HttpGet]
        public async Task<IActionResult> UpdatePerson(int id)
        {
            Person person = await _personService.GetByIdAsync(id);
            if (person != null)
            {
                ViewBag.Countries = await _personService.selectListCountryAsync();
                return View(person);
            }
            return RedirectToAction(nameof(Index), nameof(Person));
        }
        [HttpPost]
        public async Task<IActionResult> UpdatePerson(Person person)
        {
            try
            {
                await _personService.UpdateAsync(person);
                return RedirectToAction(nameof(Index), nameof(Person));
            }
            catch (Exception ex)
            {
                ViewBag.Exception = $"Kişi düzenlerken bir hata oluştu!!! Hata: {ex.Message}";
                ViewBag.Countries = await _personService.selectListCountryAsync();
                return View(person);
            }
        }

        public async Task<JsonResult> selectListCity(int id)
        {
            try
            {
                return Json(await _personService.selectListCityAsync(id));
            }
            catch
            {
                return Json(null);
            }
            
        }
    }
}
