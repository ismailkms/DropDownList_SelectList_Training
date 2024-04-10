using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class PersonManager : IPersonService
    {
        IPersonDal _personDal;

        public PersonManager(IPersonDal personDal)
        {
            _personDal = personDal;
        }

        public async Task DeleteAsync(Person item)
        {
            await _personDal.DeleteAsync(item);
        }

        public async Task<List<Person>> GetAllAsync()
        {
            return await _personDal.GetAllAsync();
        }

        public async Task<Person> GetByIdAsync(int id)
        {
            return await _personDal.GetByIdAsync(id);
        }

        public async Task<List<Person>> GetPersonWithCountryAndCityAsync()
        {
            return await _personDal.GetPersonWithCountryAndCityAsync();
        }

        public async Task InsertAsync(Person item)
        {
            await _personDal.InsertAsync(item);
        }

        public async Task<List<SelectListItem>> selectListCityAsync(int id)
        {
            return await _personDal.selectListCityAsync(id);
        }

        public async Task<List<SelectListItem>> selectListCountryAsync()
        {
            return await _personDal.selectListCountryAsync();
        }

        public async Task UpdateAsync(Person item)
        {
            await _personDal.UpdateAsync(item);
        }
    }
}
