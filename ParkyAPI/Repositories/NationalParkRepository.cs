using ParkyAPI.Data;
using ParkyAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkyAPI.Repositories
{
    public class NationalParkRepository : INationalParkRepository
    {
        private readonly ApplicationDbContext _db;
        public NationalParkRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public ICollection<NationalPark> GetAll()
        {
            return _db.NationalParks.OrderBy(c => c.Id).ToList();
        }

        public NationalPark GetById(int id)
        {
            return _db.NationalParks.FirstOrDefault(c => c.Id == id);
        }

        public ICollection<NationalPark> GetByName(string name)
        {
            return _db.NationalParks.Where(c => c.Name == name).ToList();
        }

        public void CreateNew(NationalPark nationalPark)
        {
            _db.NationalParks.Add(nationalPark);
        }
        public void DeleteById(NationalPark nationalPark) 
        {
            _db.NationalParks.Remove(nationalPark);
        }
        public void UpdateById(NationalPark nationalPark)
        {
            _db.NationalParks.Update(nationalPark);
        }

        public void Save()
        {
            _db.SaveChanges();
        }


    }      
}
