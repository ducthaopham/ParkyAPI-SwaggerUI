
using ParkyAPI.ModelViews.TrailViewModel;
using System.Collections.Generic;

namespace ParkyAPI.Service.ServiceTrail
{
    public interface ITrailService
    {
        List<TrailNPNameVM> GetAll();
        List<TrailNPNameVM> GetByName(string name);
        TrailNPNameVM GetById(int id);
        TrailCreateVM CreateNew( TrailCreateVM model);
        TrailVM UpdateById(int id, TrailVM model);
        TrailCreateVM DeleteById(int id);
       
    }
}
