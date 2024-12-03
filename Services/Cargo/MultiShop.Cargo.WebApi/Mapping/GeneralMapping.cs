using AutoMapper;
using MultiShop.Business.EntityLayer.Concrete;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCompanyDtos;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCustomerDtos;
using MultiShop.Cargo.DtoLayer.Dtos.CargoDetailDto;
using MultiShop.Cargo.DtoLayer.Dtos.CargoOperationDto;

namespace MultiShop.Cargo.WebApi.Mapping
{
    public class GeneralMapping:Profile
    {
        public GeneralMapping()
        {
            CreateMap<CargoCompany, CreateCargoCompanyDto>().ReverseMap();
            CreateMap<CargoCompany, UpdateCargoCompanyDto>().ReverseMap();


            CreateMap<CargoCustomer, CreateCargoCustomerDto>().ReverseMap();
            CreateMap<CargoCustomer, UpdateCargoCustomerDto>().ReverseMap();

            CreateMap<CargoDetail, CreateCargoDetailDto>().ReverseMap();
            CreateMap<CargoDetail, UpdateCargoDetailDto>().ReverseMap();

            CreateMap<CargoOperations,CreateCargoOperationDto>().ReverseMap();
            CreateMap<CargoOperations,UpdateCargoOperationDto>().ReverseMap();
        }
    }
}
