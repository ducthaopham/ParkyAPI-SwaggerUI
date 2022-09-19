using ParkyAPI.Models;
using System;
using System.Collections.Generic;

namespace ParkyAPI.Repositories.RepositoryNationalPark
{
    public interface INationalParkRepository
    {
        ICollection<NationalPark> GetAll();
        ICollection<NationalPark> GetByName(string name);
        NationalPark GetById(int id);
        void Save();
        void CreateNew(NationalPark nationalPark);
        void DeleteById(NationalPark nationalPark);
        void UpdateById(NationalPark nationalPark);

    }
}
