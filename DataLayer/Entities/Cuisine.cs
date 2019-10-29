using System.Collections.Generic;

namespace DataLayer.Entities
{
    public class Cuisine
    {
        public int CuisineId { get; set; }
        public string CuisineName { get; set; }

        public ICollection<Restaurant> Restaurants { get; set; }
    }
}
