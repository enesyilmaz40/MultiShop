using MultiShop.Business.EntityLayer.Concrete;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.BusinessLayer.Concrete
{
    public class CargoOperationManager : ICargoOperationsService
    {
        private readonly ICargoOperationDal _cargoOperationDal;

        public CargoOperationManager(ICargoOperationDal cargoOperationDal)
        {
            _cargoOperationDal = cargoOperationDal;
        }

        public void TDelete(int id)
        {
            _cargoOperationDal.Delete(id);
        }

        public List<CargoOperations> TGetAll()
        {
            return _cargoOperationDal.GetAll();
        }

        public CargoOperations TGetById(int id)
        {
            return _cargoOperationDal.GetById(id);
        }

        public void TInsert(CargoOperations entity)
        {
            _cargoOperationDal.Insert(entity);
        }

        public void TUpdate(CargoOperations entity)
        {
            _cargoOperationDal.Update(entity);
        }
    }
}
