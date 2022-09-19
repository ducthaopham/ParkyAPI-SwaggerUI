using ParkyAPI.Models;
using System.Collections.Generic;

namespace ParkyAPI.Repositories.RepositoryTrail
{
    public interface ITrailRepository
    {
        List<Trail> GetAll();
        List<Trail> GetByName(string name);
        Trail GetById(int id);  
        void CreateNew(Trail entity);   
        void UpdateById(Trail entity);  
        void DeleteById(Trail entity);
        void Save();
    }
}
