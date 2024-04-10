using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework
{
    public class EfCityRepository : GenericRepository<City>, ICityDal
    {
        DropDownListDbContext _context;
        public EfCityRepository(DropDownListDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<City>> GetCityWithCountryAsync()
        {
            return await _context.Cities.Include(c => c.Country).ToListAsync();
        }

        public async Task<List<SelectListItem>> selectListCountryAsync()
        {
            return await _context.Countries.Select(d =>
                                        new SelectListItem
                                        {
                                            Text = d.Name,
                                            Value = d.Id.ToString()
                                        }).ToListAsync();
            //SelectListItem,ı Microsoft.AspNetCore.Mvc.Rendering kullanarak çekmeliyiz. System.Mvc kullanmamalıyız.
            //Microsoft.AspNetCore.Mvc.Rendering'i kullanmak için projeye Microsoft.AspNetCore.Mvc.ViewFeatures paketini eklememiz gerekiyor
        }
    }
}
