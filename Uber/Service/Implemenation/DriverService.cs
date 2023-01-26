using System.Collections.Generic;
using Uber.Domain.Models;
using Uber.Repository.Interfaces;
using Uber.Services.Interface;

namespace Uber.Services.Implemenation
{
    public class DriverService : IDriverService
    {
        private readonly IDriverRepository _driverRepository;
        public DriverService(IDriverRepository driverRepository)
        {
            _driverRepository = driverRepository;
        }

        public IEnumerable<Driver> GetAll()
        {
            return _driverRepository.GetAll();
        }

        public Driver GetById(int id)
        {
            return _driverRepository.GetById(id);
        }

        public void Create(Driver driver)
        {
            _driverRepository.Create(driver);
        }

        public void Update(Driver driver)
        {
            _driverRepository.Update(driver);
        }

        public void Delete(int id)
        {
            _driverRepository.Delete(id);
        }
    }
}
