using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ServiceLayer;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFoodWebApp.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        public string Message { get; set; }
        public IList<Restaurant> Restaurants { get; set; }
        


        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }


        private readonly IRestaurantService _restaurantService;
        private readonly ILogger<ListModel> logger;

        public ListModel(IRestaurantService restaurantService, ILogger<ListModel> logger)
        {
            this.logger = logger;
            _restaurantService = restaurantService;
        }

        public void OnGet()
        {
            this.logger.LogDebug("********************************* ListRestarant was called");
            Restaurants = _restaurantService.GetRestaurantsByName(SearchTerm).ToList();
        }
    }
}