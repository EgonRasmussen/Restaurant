using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.DTO
{
    public class ListRestaurantDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public string ImageUrl { get; set; }

        public string CuisineName { get; set; }
    }
}
