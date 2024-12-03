using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Business.EntityLayer.Concrete;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoDetailDto;


namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoDetailsController : ControllerBase
    {
        private readonly ICargoDetailService _cargoDetailService;
        private readonly IMapper _mapper;

        public CargoDetailsController(ICargoDetailService cargoDetailService, IMapper mapper)
        {
            _cargoDetailService = cargoDetailService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult CargoDetailList()
        {
            var values = _cargoDetailService.TGetAll();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult CargoDetailGetById(int id)
        {
            var values = _cargoDetailService.TGetById(id);
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateCargoDetail(CreateCargoDetailDto createCargoDetailDto)
        {
            var value = _mapper.Map<CargoDetail>(createCargoDetailDto);
            _cargoDetailService.TInsert(value);
            return Ok("Kargo Müşteri Ekleme İşlemi Başarıyla Yapıldı.");
        }
        [HttpDelete]
        public IActionResult RemoveCargoDetail(int id)
        {
            _cargoDetailService.TDelete(id);
            return Ok("Kargo Müşteri Silme İşlemi Başarıyla Yapıldı.");
        }
        [HttpPut]
        public IActionResult UpdateCargoDetail(UpdateCargoDetailDto updateCargoDetailDto)
        {
            var value = _mapper.Map<CargoDetail>(updateCargoDetailDto);
            _cargoDetailService.TUpdate(value);
            return Ok("Kargo Müşteri Güncelleme İşlemi Başarıyla Yapıldı.");
        }
    }
}
