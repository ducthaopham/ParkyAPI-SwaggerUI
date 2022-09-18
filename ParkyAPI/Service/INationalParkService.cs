
using AutoMapper;
using ParkyAPI.ModelViews.NationalParkViewModel;
using ParkyAPI.Repositories;
using System.Collections.Generic;

namespace ParkyAPI.Service
{
    public interface INationalParkService
    {
        public List<NationalParkVM> GetAll();
        public NationalParkVM GetById(int id);
        public List<NationalParkVM> GetByName(string name);
        public NationalParkCreateVM CreateNew(NationalParkCreateVM objVM);
        public NationalParkVM DeleteById(int id);
        public NationalParkVM UpdateById(int id, NationalParkVM objVM);

    }
}
