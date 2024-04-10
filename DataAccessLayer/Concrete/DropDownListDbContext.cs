using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class DropDownListDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Person> People { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .AddJsonFile(Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\DropDownList_SelectList_Training\DropDownList_SelectList_Training\appsettings.json")), optional: true)
                .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DatabaseConnection"));
            //appsettings.json üzerinden connection string'i çektik

            //appsettings.json
            //"Modules": {
            //    "Products": {
            //        "ConnectionStrings": {
            //            "DatabaseConnection": "Server=myServer;Database=products;Trusted_Connection=True;"
            //        }
            //    }

            //Üstteki appsettings.json içeriğini alttaki gibi çağırabilirsin.
            //var prodDb = configuration.GetSection("Modules:Products").GetConnectionString("DatabaseConnection");

        }
    }
}
