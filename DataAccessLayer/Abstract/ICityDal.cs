using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DataAccessLayer.Abstract
{
    public interface ICityDal : IGenericDal<City>
    {
        Task<List<City>> GetCityWithCountryAsync();
        Task<List<SelectListItem>> selectListCountryAsync();
    }
}
