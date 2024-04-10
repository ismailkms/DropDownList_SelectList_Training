using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace DropDownList_SelectList_Training.Controllers
{
    public class CountryController : Controller
    {
        ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        public async Task<IActionResult> Index()
        {
            List<Country> countries = await _countryService.GetAllAsync();
            return View(countries);
        }

        [HttpGet]
        public IActionResult AddCountry()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddCountry(Country country)
        {
            try
            {
                await _countryService.InsertAsync(country);
                return RedirectToAction(nameof(Index), nameof(Country));
            }
            catch (Exception ex)
            {
                ViewBag.Exception = $"Ülke eklerken bir hata oluştu!!! Hata: {ex.Message}";
                return View(country);
            }
            
        }

        public async Task<IActionResult> DeleteCountry(int id)
        {
            Country country = await _countryService.GetByIdAsync(id);
            if (country != null)
            {
                await _countryService.DeleteAsync(country);
            }
            return RedirectToAction(nameof(Index), nameof(Country));
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCountry(int id)
        {
            Country country = await _countryService.GetByIdAsync(id);
            if(country != null)
            {
                return View(country);
            }
            return RedirectToAction(nameof(Index), nameof(Country));
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCountry(Country country)
        {
            try
            {
                await _countryService.UpdateAsync(country);
                return RedirectToAction(nameof(Index), nameof(Country));
            }
            catch (Exception ex)
            {
                ViewBag.Exception = $"Ülke düzenlerken bir hata oluştu!!! Hata: {ex.Message}";
                return View(country);
            }
            
        }
    }
}
