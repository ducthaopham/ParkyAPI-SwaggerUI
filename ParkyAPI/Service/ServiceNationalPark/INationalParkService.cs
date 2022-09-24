
using AutoMapper;
using ParkyAPI.ModelViews.NationalParkViewModel;
using ParkyAPI.Repositories;
using System.Collections.Generic;

namespace ParkyAPI.Service.ServiceNationalPark
{
    public interface INationalParkService
    {
        public List<NationalParkVM> GetAll();
        public NationalParkVM GetById(int id);
        public List<NationalParkVM> GetByName(string name);
        public bool CreateNew(NationalParkCreateVM objVM);
        public bool DeleteById(int id);
        public bool UpdateById(int id, NationalParkVM objVM);

    }
}
