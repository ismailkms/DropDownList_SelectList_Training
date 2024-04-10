using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public int? CountryId { get; set; }
        public int? CityId { get; set; }
        public Country Country { get; set; }
        public City City { get; set; }
    }
}
