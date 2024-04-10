using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfPersonRepository : GenericRepository<Person>, IPersonDal
    {
        DropDownListDbContext _context;
        public EfPersonRepository(DropDownListDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Person>> GetPersonWithCountryAndCityAsync()
        {
            return await _context.People.Include(p => p.Country).Include(p => p.City).ToListAsync();
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

        public async Task<List<SelectListItem>> selectListCityAsync(int id)
        {
            return await _context.Cities
                .Where(c => c.CountryId == id)
                .Select(d =>
                       new SelectListItem
                       {
                           Text = d.Name,
                           Value = d.Id.ToString()
                       }).ToListAsync();
        }
    }
}
