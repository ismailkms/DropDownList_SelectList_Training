using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace DropDownList_SelectList_Training.Controllers
{
    public class CityController : Controller
    {
        ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        public async Task<IActionResult> Index()
        {
            List<City> cities = await _cityService.GetCityWithCountryAsync();
            return View(cities);
        }

        [HttpGet]
        public async Task<IActionResult> AddCity()
        {
            ViewBag.Countries = await _cityService.selectListCountryAsync();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddCity(City city)
        {
            try
            {
                await _cityService.InsertAsync(city);
                return RedirectToAction(nameof(Index), nameof(City));
            }
            catch (Exception ex)
            {
                ViewBag.Exception = $"Şehir eklerken bir hata oluştu!!! Hata: {ex.Message}";
                ViewBag.Countries = await _cityService.selectListCountryAsync();
                return View(city);
            }
        }

        public async Task<IActionResult> DeleteCity(int id)
        {
            City city = await _cityService.GetByIdAsync(id);
            if (city != null)
            {
                await _cityService.DeleteAsync(city);
            }
            return RedirectToAction(nameof(Index), nameof(City));
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCity(int id)
        {
            City city = await _cityService.GetByIdAsync(id);
            if (city != null)
            {
                ViewBag.Countries = await _cityService.selectListCountryAsync();
                return View(city);
            }
            return RedirectToAction(nameof(Index), nameof(City));
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCity(City city)
        {
            try
            {
                await _cityService.UpdateAsync(city);
                return RedirectToAction(nameof(Index), nameof(City));
            }
            catch (Exception ex)
            {
                ViewBag.Exception = $"Şehir düzenlerken bir hata oluştu!!! Hata: {ex.Message}";
                ViewBag.Countries = await _cityService.selectListCountryAsync();
                return View(city);
            }
        }
    }
}
