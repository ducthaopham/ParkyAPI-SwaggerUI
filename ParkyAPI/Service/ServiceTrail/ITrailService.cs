
using ParkyAPI.ModelViews.TrailViewModel;
using System.Collections.Generic;

namespace ParkyAPI.Service.ServiceTrail
{
    public interface ITrailService
    {
        List<TrailNPNameVM> GetAll();
        List<TrailNPNameVM> GetByName(string name);
        TrailNPNameVM GetById(int id);
        bool CreateNew( TrailCreateVM model);
        bool UpdateById(int id, TrailVM model);
        bool DeleteById(int id);
       
    }
}
