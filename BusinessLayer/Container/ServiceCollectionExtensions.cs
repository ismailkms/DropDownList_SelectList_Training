using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Container
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {

            services.AddScoped<IEmployeeService, EmployeeManager>();
            services.AddScoped<IEmployeeDal, EfEmployeeRepository>();
           
            services.AddScoped<IDepartmentService, DepartmentManager>();
            services.AddScoped<IDepartmentDal, EfDepartmentRepository>();
           
            services.AddScoped<ICountryService, CountryManager>();
            services.AddScoped<ICountryDal, EfCountryRepository>();
           
            services.AddScoped<ICityService, CityManager>();
            services.AddScoped<ICityDal, EfCityRepository>();
          
            services.AddScoped<IPersonService, PersonManager>();
            services.AddScoped<IPersonDal, EfPersonRepository>();

            return services;
        }
    }
}
