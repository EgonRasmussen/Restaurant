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
            modelBuilder.Entity<Restaurant>().HasData(
                new Restaurant { Id = 1, Name = "Scott's Pizza", Location = "Maryland", Cuisine = CuisineType.Italian, ImageUrl = "https://www.newyork.dk/wp-content/uploads/2019/04/pizza_ny.jpg" },
                new Restaurant { Id = 2, Name = "Cinnamon Club", Location = "London", Cuisine = CuisineType.Italian, ImageUrl = "https://cdn.londonandpartners.com/asset/cinnamon-club-the-cinnamon-club-facade-4c28130c267968cb1c84350175e92e48.jpg" },
                new Restaurant { Id = 3, Name = "La Costa", Location = "California", Cuisine = CuisineType.Mexican, ImageUrl = "https://media-cdn.tripadvisor.com/media/photo-s/03/c6/a9/26/la-costa.jpg" },
                 new Restaurant { Id = 4, Name = "Noma", Location = "Copenhagen", Cuisine = CuisineType.Indian, ImageUrl = "https://cdn.vox-cdn.com/thumbor/3RkUCxUVzhANhq_lMwOUL0NQ8mY=/0x0:1000x751/1200x800/filters:focal(660x66:820x226)/cdn.vox-cdn.com/uploads/chorus_image/image/55134001/noma-pop-up.0.0.jpg" },
                new Restaurant { Id = 5, Name = "Kong Hans Kælder", Location = "Copenhagen", Cuisine = CuisineType.Italian, ImageUrl = "https://migogkbh.dk/wp-content/uploads/2019/01/Kong-Hans-K%C3%A6lder.png" },
                new Restaurant { Id = 6, Name = "Geranium", Location = "Copenhagen", Cuisine = CuisineType.Mexican, ImageUrl = "https://www.theworlds50best.com/filestore/jpg/Geranium-WORLD-2018-interior.jpg" }
           );
        }
    }

}
