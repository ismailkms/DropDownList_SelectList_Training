using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BusinessLayer.Concrete
{
    public class CityManager : ICityService
    {
        ICityDal _cityDal;

        public CityManager(ICityDal cityDal)
        {
            _cityDal = cityDal;
        }

        public async Task DeleteAsync(City item)
        {
           await _cityDal.DeleteAsync(item);
        }

        public async Task<List<City>> GetAllAsync()
        {
            return await _cityDal.GetAllAsync();
        }

        public async Task<City> GetByIdAsync(int id)
        {
            return await _cityDal.GetByIdAsync(id);
        }

        public async Task<List<City>> GetCityWithCountryAsync()
        {
            return await _cityDal.GetCityWithCountryAsync();
        }

        public async Task InsertAsync(City item)
        {
            await _cityDal.InsertAsync(item);
        }

        public async Task<List<SelectListItem>> selectListCountryAsync()
        {
            return await _cityDal.selectListCountryAsync();
        }

        public async Task UpdateAsync(City item)
        {
            await _cityDal.UpdateAsync(item);
        }
    }
}
