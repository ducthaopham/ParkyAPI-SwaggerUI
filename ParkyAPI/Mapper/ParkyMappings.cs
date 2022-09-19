using AutoMapper;
using ParkyAPI.Models;
using ParkyAPI.ModelViews.NationalParkViewModel;
using ParkyAPI.ModelViews.TrailViewModel;

namespace ParkyAPI.Mapper
{
    public class ParkyMappings : Profile
    {
        public ParkyMappings()
        {
            CreateMap<NationalPark, NationalParkVM>().ReverseMap();
            CreateMap<NationalPark, NationalParkCreateVM>().ReverseMap();
            CreateMap<NationalPark, NationalParkVM1>().ReverseMap();
           
            CreateMap<Trail, TrailCreateVM>().ReverseMap();
            CreateMap<Trail, TrailVM>().ReverseMap();
            CreateMap<Trail, TrailNPNameVM>();
        }
    }
}
