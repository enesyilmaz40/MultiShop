using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Business.EntityLayer.Concrete;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoOperationDto;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoOperationsController : ControllerBase
    {
        private readonly ICargoOperationsService _cargoOperationService;
        private readonly IMapper _mapper;

        public CargoOperationsController(ICargoOperationsService cargoOperationService, IMapper mapper)
        {
            _cargoOperationService = cargoOperationService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult CargoOperationList()
        {
            var values = _cargoOperationService.TGetAll();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult CargoOperationGetById(int id)
        {
            var values = _cargoOperationService.TGetById(id);
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateCargoOperation(CreateCargoOperationDto createCargoOperationDto)
        {
            var value = _mapper.Map<CargoOperations>(createCargoOperationDto);
            _cargoOperationService.TInsert(value);
            return Ok("Kargo Müşteri Ekleme İşlemi Başarıyla Yapıldı.");
        }
        [HttpDelete]
        public IActionResult RemoveCargoOperation(int id)
        {
            _cargoOperationService.TDelete(id);
            return Ok("Kargo Müşteri Silme İşlemi Başarıyla Yapıldı.");
        }
        [HttpPut]
        public IActionResult UpdateCargoOperation(UpdateCargoOperationDto updateCargoOperationDto)
        {
            var value = _mapper.Map<CargoOperations>(updateCargoOperationDto);
            _cargoOperationService.TUpdate(value);
            return Ok("Kargo Müşteri Güncelleme İşlemi Başarıyla Yapıldı.");
        }
    }
}
