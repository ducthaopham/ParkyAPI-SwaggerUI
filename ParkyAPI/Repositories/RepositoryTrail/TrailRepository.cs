using Microsoft.EntityFrameworkCore;
using ParkyAPI.Data;
using ParkyAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace ParkyAPI.Repositories.RepositoryTrail
{
    public class TrailRepository: ITrailRepository
    {
        private readonly ApplicationDbContext _db;
        public TrailRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public void CreateNew(Trail entity)
        {
            _db.Trails.Add(entity);
        }

        public void DeleteById(Trail entity)
        {
            _db.Trails.Remove(entity);
        }

        public List<Trail> GetAll()
        {
            return _db.Trails.Include(c => c.NationalPark).ToList();
        }

        public Trail GetById(int id)
        {
            return _db.Trails.Include(c => c.NationalPark).FirstOrDefault(c => c.Id == id);
        }

        public List<Trail> GetByName(string name)
        {
            return _db.Trails.Include(c => c.NationalPark).Where(c => c.Name == name).ToList();
        }

        public void UpdateById(Trail entity)
        {
            _db.Trails.Update(entity);
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
