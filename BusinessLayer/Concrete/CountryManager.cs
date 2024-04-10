using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CountryManager : ICountryService
    {
        ICountryDal _countryDal;

        public CountryManager(ICountryDal countryDal)
        {
            _countryDal = countryDal;
        }

        public async Task DeleteAsync(Country item)
        {
            await _countryDal.DeleteAsync(item);
        }

        public async Task<List<Country>> GetAllAsync()
        {
            return await _countryDal.GetAllAsync();
        }

        public async Task<Country> GetByIdAsync(int id)
        {
            return await _countryDal.GetByIdAsync(id);
        }

        public async Task InsertAsync(Country item)
        {
            await _countryDal.InsertAsync(item);
        }

        public async Task UpdateAsync(Country item)
        {
            await _countryDal.UpdateAsync(item);
        }
    }
}
