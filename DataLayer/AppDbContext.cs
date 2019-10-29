using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Restaurant> Restaurants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cuisine>().HasData(
                new Cuisine { CuisineId = 1, CuisineName = "None" },
                new Cuisine { CuisineId = 2, CuisineName = "Italian" },
                new Cuisine { CuisineId = 3, CuisineName = "Mexican" },
                new Cuisine { CuisineId = 4, CuisineName = "Indian" }
                );

            modelBuilder.Entity<Restaurant>().HasData(
                new Restaurant { Id = 1, Name = "Scott's Pizza", Location = "Maryland", CuisineId = 2, ImageUrl = "http://simplyexploreculture.ca/content/locations/facilities-and-spaces/food-and-entertainment/@item/scotts.jpg", },
                new Restaurant { Id = 2, Name = "Cinnamon Club", Location = "London", CuisineId = 2, ImageUrl = "https://cdn.londonandpartners.com/asset/cinnamon-club-the-cinnamon-club-facade-4c28130c267968cb1c84350175e92e48.jpg" },
                new Restaurant { Id = 3, Name = "La Costa", Location = "California", CuisineId = 3, ImageUrl = "https://media-cdn.tripadvisor.com/media/photo-s/03/c6/a9/26/la-costa.jpg" },
                 new Restaurant { Id = 4, Name = "Noma", Location = "Copenhagen", CuisineId = 4, ImageUrl = "https://cdn.vox-cdn.com/thumbor/3RkUCxUVzhANhq_lMwOUL0NQ8mY=/0x0:1000x751/1200x800/filters:focal(660x66:820x226)/cdn.vox-cdn.com/uploads/chorus_image/image/55134001/noma-pop-up.0.0.jpg" },
                new Restaurant { Id = 5, Name = "Kong Hans Kælder", Location = "Copenhagen", CuisineId = 2, ImageUrl = "https://migogkbh.dk/wp-content/uploads/2019/01/Kong-Hans-K%C3%A6lder.png" },
                new Restaurant { Id = 6, Name = "Geranium", Location = "Copenhagen", CuisineId = 3, ImageUrl = "https://www.theworlds50best.com/filestore/jpg/Geranium-WORLD-2018-interior.jpg" }
           );
        }
    }

}
