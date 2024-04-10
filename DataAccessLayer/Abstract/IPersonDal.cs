using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IPersonDal : IGenericDal<Person>
    {
        Task<List<Person>> GetPersonWithCountryAndCityAsync();
        Task<List<SelectListItem>> selectListCountryAsync();
        Task<List<SelectListItem>> selectListCityAsync(int id);
    }
}
