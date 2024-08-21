using AutoMapper;
using Entities.Models;
using Entities.DTO;

namespace WebApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Cargo, CargoDto>();
            CreateMap<CargoCreateDto, Cargo>();
            CreateMap<CargoUpdateDto, Cargo>();

            CreateMap<Ship, ShipDto>();
            CreateMap<ShipCreateDto, Ship>();
            CreateMap<ShipUpdateDto, Ship>();
        }
    }
}
