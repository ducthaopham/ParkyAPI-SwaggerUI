using AutoMapper;
using ParkyAPI.Models;
using ParkyAPI.ModelViews.NationalParkViewModel;

namespace ParkyAPI.Mapper
{
    public class ParkyMappings : Profile
    {
        public ParkyMappings()
        {
            CreateMap<NationalPark, NationalParkVM>().ReverseMap();
            CreateMap<NationalPark, NationalParkCreateVM>().ReverseMap();        
        }
    }
}
