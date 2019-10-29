using AutoMapper;
using DataLayer.Entities;
using ServiceLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Profiles
{
    public class BlogsProfile : Profile
    {
        public BlogsProfile()
        {
            CreateMap<Restaurant, ListRestaurantDto>()
                .ForMember(dest => dest.CuisineName, opt => opt.MapFrom(src => src.Cuisine.CuisineName));

            CreateMap<Restaurant, DetailRestaurantDto>()
                .ForMember(dest => dest.CuisineName, opt => opt.MapFrom(src => src.Cuisine.CuisineName));
        }
    }
}
