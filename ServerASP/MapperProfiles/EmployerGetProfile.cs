using AutoMapper;
using ServerASP.Models;
using ServerASP.Models.DTO.Outgoing;

namespace ServerASP.MapperProfiles
{
    public class EmployerGetProfile : Profile
    {
        public EmployerGetProfile()
        {
            CreateMap<Employer, EmployeeGetDTO>()
                .ForMember(
                dest => dest.FirstName,
                opt => opt.MapFrom(src => src.Firstname)
                    )
                .ForMember(
                    dest => dest.SurName,
                    opt => opt.MapFrom(src => src.Surname)
                    )
                .ForMember(
                    dest => dest.IsActive,
                    opt => opt.MapFrom(src => src.isActive)
                    )
                .ForMember(
                    dest => dest.PositionName,
                    opt => opt.MapFrom(src => src.Position!.PositionName)
                    );
        }
    }
}
