using System.Collections.Generic;
using Uber.Domain.Models;

namespace Uber.Services.Interface
{
    public interface IDriverService
    {
        IEnumerable<Driver> GetAll();
        Driver GetById(int id);
        void Create(Driver driver);
        void Update(Driver driver);
        void Delete(int id);
    }
}
