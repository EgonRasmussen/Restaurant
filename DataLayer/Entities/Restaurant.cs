using System.ComponentModel.DataAnnotations;

namespace DataLayer.Entities
{
    public class Restaurant
    {
        public int Id { get; set; }

        [Required, StringLength(80)]
        public string Name { get; set; }

        [Required, StringLength(255)]
        public string Location { get; set; }

        public int CuisineId { get; set; }      // FK
        public string ImageUrl { get; set; }

        public Cuisine Cuisine { get; set; }
    }
}

