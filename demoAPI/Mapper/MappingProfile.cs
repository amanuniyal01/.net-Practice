using AutoMapper;
using demoAPI.Models.Dto;
using demoAPI.Models.Entity;

namespace demoAPI.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DistrictEntity, DistrictRequestDto>().ReverseMap();
            CreateMap<DistrictEntity, DistrictResponseDto>();

            CreateMap<StateEntity, StateRequestDto>().ReverseMap();
            CreateMap<StateEntity, StateResponseDto>();
        }
    }
}