using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BusinessLayer.Abstract
{
    public interface ICityService : IGenericService<City>
    {
        Task<List<City>> GetCityWithCountryAsync();
        Task<List<SelectListItem>> selectListCountryAsync();
    }
}
