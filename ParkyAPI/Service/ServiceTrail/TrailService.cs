using AutoMapper;
using ParkyAPI.Models;
using ParkyAPI.ModelViews.NationalParkViewModel;
using ParkyAPI.ModelViews.TrailViewModel;
using ParkyAPI.Repositories.RepositoryNationalPark;
using ParkyAPI.Repositories.RepositoryTrail;
using System.Collections.Generic;
using System.Xml.Linq;

namespace ParkyAPI.Service.ServiceTrail
{
    public class TrailService : ITrailService
    {
        private readonly ITrailRepository _repo;
        private readonly INationalParkRepository _repoNP;
        private readonly IMapper _mapper;
        public TrailService(ITrailRepository repo, IMapper mapper, INationalParkRepository repoNP)
        {
            _repoNP = repoNP;
            _repo = repo;
            _mapper = mapper;
        }

        public List<TrailNPNameVM> GetAll()
        {
            var objs = _repo.GetAll();
            var objsVM = new List<TrailNPNameVM>();
            
            foreach(var obj in objs)
            {
                objsVM.Add(_mapper.Map<TrailNPNameVM>(obj));
            }
            return objsVM;
        }

        public TrailNPNameVM GetById(int id)
        {
            var obj = _repo.GetById(id);
            if (obj == null)
                return null;
            var objVM = _mapper.Map<TrailNPNameVM>(obj);
            return objVM;
        }

        public List<TrailNPNameVM> GetByName(string name)
        {
            var objs = _repo.GetByName(name);
            if (objs == null)
                return null;
            var objsVM = _mapper.Map<List<TrailNPNameVM>>(objs);
            return objsVM;
        }

        public bool  DeleteById(int id) 
        {
            var obj = _repo.GetById(id);
            if (obj == null)
                return false;

            _repo.DeleteById(obj);
            _repo.Save();
            var objVM = _mapper.Map<TrailCreateVM>(obj);
            return true;
        }
        public bool CreateNew(TrailCreateVM objVM) 
        {
            var objNP = _repoNP.GetById(objVM.NationalParkId);
            if (objNP == null)
                return false;
                

            var obj = _mapper.Map<Trail>(objVM);
            _repo.CreateNew(obj);
            _repo.Save();
            return true;
        }

        public bool UpdateById(int id, TrailVM objVM) 
        {
            var objNP = _repoNP.GetById(objVM.NationalParkId);
            if (objVM == null || objVM.Id != id || objNP == null)   
                return false;

            var obj = _mapper.Map<Trail>(objVM);
            _repo.UpdateById(obj);
            _repo.Save();
            return true ;
        }
    } 
}
