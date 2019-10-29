using AutoMapper;
using AutoMapper.QueryableExtensions;
using DataLayer;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.DTO;
using System.Linq;

namespace ServiceLayer
{
    public class RestaurantService : IRestaurantService
    {
        private readonly AppDbContext _ctx;
        private readonly IMapper _mapper;

        public RestaurantService(AppDbContext ctx, IMapper mapper)
        {
            ctx.Database.EnsureCreated();   // lav til kommentar for at Add-demo
            _ctx = ctx;
            _mapper = mapper;
        }

        public IQueryable<ListRestaurantDto> GetRestaurants()
        {
            var restaurantsQuery = _ctx.Restaurants
                .AsNoTracking()
                .ProjectTo<ListRestaurantDto>(_mapper.ConfigurationProvider);
            return restaurantsQuery;
        }

        public IQueryable<ListRestaurantDto> GetRestaurantsByName(string name = null)
        {
            return _ctx.Restaurants
                    .AsNoTracking()
                .Where(r => string.IsNullOrEmpty(name) || r.Name.StartsWith(name))
                .OrderBy(r => r.Name)
                .ProjectTo<ListRestaurantDto>(_mapper.ConfigurationProvider);
        }

        public DetailRestaurantDto GetRestaurantById(int restaurantId)
        {
            Restaurant rest = _ctx.Restaurants
                .Include(r => r.Cuisine)
                .Where(r => r.Id == restaurantId)
                .FirstOrDefault();
            return _mapper.Map<Restaurant, DetailRestaurantDto>(rest);
        }

        public Restaurant Update(Restaurant updatedRedstaurant)
        {
            _ctx.Restaurants.Update(updatedRedstaurant);
            //_ctx.Entry<Restaurant>(updatedRedstaurant).Property(x => x.ImageUrl).IsModified = false;

            //var entity = _ctx.Restaurants.Attach(updatedRedstaurant);
            //entity.State = EntityState.Modified;

            return updatedRedstaurant;
        }

        //public Restaurant Add(Restaurant newRestaurant)
        //{
        //    _ctx.Restaurants.Add(newRestaurant);
        //    return newRestaurant;
        //}

        //public Restaurant Delete(int id)
        //{
        //    var restaurant = GetRestaurantById(id);
        //    if (restaurant != null)
        //    {
        //        _ctx.Restaurants.Remove(restaurant);
        //    }
        //    return restaurant;
        //}

        public int GetCountOfRestaurants()
        {
            return _ctx.Restaurants.Count();
        }

        public int Commit()
        {
            _ctx.SaveChanges();
            return 0;
        }
    }
}
