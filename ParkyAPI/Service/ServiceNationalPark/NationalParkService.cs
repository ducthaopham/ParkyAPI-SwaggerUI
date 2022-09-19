using AutoMapper;
using ParkyAPI.Models;
using ParkyAPI.ModelViews.NationalParkViewModel;
using ParkyAPI.Repositories.RepositoryNationalPark;
using System.Collections.Generic;

namespace ParkyAPI.Service.ServiceNationalPark
{
    public class NationalParkService : INationalParkService
    {
        private readonly INationalParkRepository _repo;
        private readonly IMapper _mapper;
        public NationalParkService(INationalParkRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public List<NationalParkVM> GetAll()
        {
            var objs = _repo.GetAll();
            var objsVM = _mapper.Map<List<NationalParkVM>>(objs);
            return objsVM;
        }

        public NationalParkVM GetById(int id)
        {
            var obj = _repo.GetById(id);
            var objVM = _mapper.Map<NationalParkVM>(obj);
            return objVM;
        }

        public List<NationalParkVM> GetByName(string name)
        {
            var objs = _repo.GetByName(name);
            var objsVM = _mapper.Map<List<NationalParkVM>>(objs);
            return objsVM;
        }

        public NationalParkCreateVM CreateNew(NationalParkCreateVM objVM)
        {
            var obj = _mapper.Map<NationalPark>(objVM);
            _repo.CreateNew(obj);
            _repo.Save();
            return objVM;
        }

        public NationalParkVM DeleteById(int id)
        {
            var obj = _repo.GetById(id);
            if (obj == null)
                return null;

            var objVM = _mapper.Map<NationalParkVM>(obj);
            _repo.DeleteById(obj);
            _repo.Save();
            return objVM;
        }

        public NationalParkVM UpdateById(int id, NationalParkVM objVM)
        {

            if(objVM == null || objVM.Id != id)
                return null;
              
            var obj = _mapper.Map<NationalPark>(objVM);  
            _repo.UpdateById(obj);
            _repo.Save();
            return objVM;
        }
    }
}
