using DataLayer.Entities;
using ServiceLayer.DTO;
using System.Collections;
using System.Linq;

namespace ServiceLayer
{
    public interface IRestaurantService
    {
        IQueryable<ListRestaurantDto> GetRestaurants();
        IQueryable<ListRestaurantDto> GetRestaurantsByName(string name = null);
        DetailRestaurantDto GetRestaurantById(int restaurantId);
        Restaurant Update(Restaurant updatedRedstaurant);
        //Restaurant Add(Restaurant newRestaurant);
        //Restaurant Delete(int id);
        int GetCountOfRestaurants();
        int Commit();
    }
}
