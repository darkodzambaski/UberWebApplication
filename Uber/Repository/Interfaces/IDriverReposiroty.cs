using System.Collections.Generic;
using Uber.Domain.Models;

namespace Uber.Repository.Interfaces
{
    public interface IDriverRepository
    {
        IEnumerable<Driver> GetAll();
        Driver GetById(int id);
        void Create(Driver driver);
        void Update(Driver driver);
        void Delete(int id);
    }

}
