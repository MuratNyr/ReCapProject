using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car {Id=1,BrandId=1, ColorId=1,ModelYear="2010",DailyPrice=100000,Description="Hızlı Gitmez"},
                new Car {Id=2,BrandId=1, ColorId=5,ModelYear="2009",DailyPrice=250000,Description="Hızlı gider"},
                new Car {Id=3,BrandId=2, ColorId=2,ModelYear="2009",DailyPrice=500000,Description="Hızlı kalkar"},
                new Car {Id=4,BrandId=2, ColorId=6,ModelYear="2010",DailyPrice=167000,Description="Ucuza gider"},
                new Car {Id=5,BrandId=2, ColorId=3,ModelYear="2011",DailyPrice=345000,Description="ilk sahibinden"}
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(p => p.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAllByBrand(int brandId)
        {
            return _cars.Where(p => p.BrandId == brandId).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(p => p.Id == car.Id);

            carToUpdate.Id = car.Id;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
