﻿using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer;
using System.Collections.Generic;
using System.Linq;

using Microsoft.AspNetCore.Mvc;

namespace OdeToFoodWebApp.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        public IEnumerable<Restaurant> Restaurants { get; set; }


        private readonly IRestaurantService _restaurantService;

        public ListModel(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        public void OnGet()
        {
            Restaurants = _restaurantService.GetRestaurants().ToList();
        }

        //public void OnGet([FromServices] IRestaurantService _restaurantService)
        //{
        //    Restaurants = _restaurantService.GetRestaurants().ToList();
        //}
    }
}